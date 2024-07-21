using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Upgrades : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    [Header("Upgrades Section")]
    public GameObject UpgradesSection;

    [Header("Skill Trees")]
    public GameObject DamageTowerSkillTree;
    public GameObject FreezeTowerSkillTree;
    public GameObject PoisonTowerSkillTree;
    public GameObject BombTowerSkillTree;

    [Header("Skill Tree Title")]
    public TextMeshProUGUI SkillTreeText;

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();   
        UpgradesSection.SetActive(false);
        ShowHideSkillTree(false, false, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSkillTree(TowerEnum towerEnum)
    {
        UpgradesSection.SetActive(true);
        switch (towerEnum)
        {
            case TowerEnum.DamageTower:
                SkillTreeText.text = StringsDatabase.SkillTree.DamageSkillTree;
                ShowHideSkillTree(true, false, false, false);
                break;
            case TowerEnum.FreezeTower:
                SkillTreeText.text = StringsDatabase.SkillTree.FreezeSkillTree;
                ShowHideSkillTree(false, true, false, false);
                break;
            case TowerEnum.PoisonTower:
                SkillTreeText.text = StringsDatabase.SkillTree.PoisonSkillTree;
                ShowHideSkillTree(false, false, true, false);
                break;
            case TowerEnum.BombTower:
                SkillTreeText.text = StringsDatabase.SkillTree.BombSkillTree;
                ShowHideSkillTree(false, false, false, true);
                break;

        }
    }

    public void ShowHideSkillTree(bool damage, bool freeze, bool poison, bool bomb)
    {
        DamageTowerSkillTree.SetActive(damage);
        FreezeTowerSkillTree.SetActive(freeze);
        PoisonTowerSkillTree.SetActive(poison);
        BombTowerSkillTree.SetActive(bomb);
    }

    public void SetUpSkillTreeOptions(GameObject currentTower)
    {
        if(currentTower.GetComponent<Tower>().UpgradeNames != null && currentTower.GetComponent<Tower>().UpgradeNames.Count > 0)
        {
            foreach(var upgradeName in currentTower.GetComponent<Tower>().UpgradeNames)
            {
                GameObject.Find(upgradeName).GetComponent<Image>().color = Color.green;
                GameObject.Find(upgradeName).GetComponent<Button>().enabled = false;
            }
        }
        else
        {
            switch(currentTower.GetComponent<Tower>().TowerEnum)
            {
                case TowerEnum.DamageTower:
                    for(int i=0; i<DamageTowerSkillTree.transform.childCount; i++)
                    {
                        var child = DamageTowerSkillTree.transform.GetChild(i);

                        if (child.name != "Lines")
                        {
                            if (child.GetComponent<Image>().color == Color.green)
                            {
                                child.GetComponent<Image>().color = Color.white;
                                child.GetComponent<Button>().enabled = true;

                                if(!child.GetComponent<Button>().interactable)
                                {
                                    child.GetComponent<Button>().interactable = true;
                                }
                            }
                        }
                    }
                    break;
                case TowerEnum.FreezeTower:
                    for (int i = 0; i < FreezeTowerSkillTree.transform.childCount; i++)
                    {
                        var child = FreezeTowerSkillTree.transform.GetChild(i);
                        if (child.name != "Lines")
                        {
                            if (child.GetComponent<Image>().color == Color.green)
                            {
                                child.GetComponent<Image>().color = Color.white;
                                child.GetComponent<Button>().enabled = true;

                                if (!child.GetComponent<Button>().interactable)
                                {
                                    child.GetComponent<Button>().interactable = true;
                                }
                            }
                        }
                    }
                    break;
                case TowerEnum.PoisonTower:
                    for (int i = 0; i < PoisonTowerSkillTree.transform.childCount; i++)
                    {
                        var child = PoisonTowerSkillTree.transform.GetChild(i);
                        if (child.name != "Lines")
                        {
                            if (child.GetComponent<Image>().color == Color.green)
                            {
                                child.GetComponent<Image>().color = Color.white;
                                child.GetComponent<Button>().enabled = true;

                                if (!child.GetComponent<Button>().interactable)
                                {
                                    child.GetComponent<Button>().interactable = true;
                                }
                            }
                        }
                    }
                    break;
                case TowerEnum.BombTower:
                    for (int i = 0; i < BombTowerSkillTree.transform.childCount; i++)
                    {
                        var child = BombTowerSkillTree.transform.GetChild(i);
                        if (child.name != "Lines")
                        {
                            if (child.GetComponent<Image>().color == Color.green)
                            {
                                child.GetComponent<Image>().color = Color.white;
                                child.GetComponent<Button>().enabled = true;

                                if (!child.GetComponent<Button>().interactable)
                                {
                                    child.GetComponent<Button>().interactable = true;
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }

    void ApplyChangesAfterNode(GameObject node, bool areThereNodes, List<GameObject> otherNodes = null)
    {
        ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().UpgradeLevel++;
        ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().UpgradeNames.Add(node.name);
        node.GetComponent<Image>().color = Color.green;
        node.GetComponent<Button>().enabled = false;

        if(areThereNodes)
        {
            foreach(var adjacentNode in otherNodes)
            {
                adjacentNode.GetComponent<Button>().interactable = false;
            }
        }
    }

    #region OnClick

    public void OnClick_UpgradeNode(GameObject node)
    {
        var nodeName = node.name;

        var nodeSplit = nodeName.Split('_');

        List<GameObject> otherNodes = new List<GameObject>();

        switch(nodeSplit[0])
        {
            case "DamageTower":
                switch(nodeSplit[1])
                {
                    case "Level1":
                        ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().Damage += ReferencesManager.UpgradesManager.DamageTowerDamage["Level 1"];
                        ApplyChangesAfterNode(node, false);
                        break;
                    case "Level2":
                        switch(nodeSplit[2])
                        {
                            case "Damage":
                                ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().Damage += ReferencesManager.UpgradesManager.DamageTowerDamage["Level 2"];
                                otherNodes = new List<GameObject>() { GameObject.Find("DamageTower_Level2_FireRate"), GameObject.Find("DamageTower_Level2_Range") };
                                ApplyChangesAfterNode(node, true, otherNodes);
                                break;
                            case "FireRate":
                                ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().FireRate -= ReferencesManager.UpgradesManager.DamageTowerFireRate["Level 2"];
                                otherNodes = new List<GameObject>() { GameObject.Find("DamageTower_Level2_Damage"), GameObject.Find("DamageTower_Level2_Range") };
                                ApplyChangesAfterNode(node, true, otherNodes);
                                break;
                            case "Range":
                                ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().Range += ReferencesManager.UpgradesManager.DamageTowerRange["Level 2"];
                                otherNodes = new List<GameObject>() { GameObject.Find("DamageTower_Level2_Damage"), GameObject.Find("DamageTower_Level2_FireRate") };
                                ApplyChangesAfterNode(node, true, otherNodes);
                                break;
                        }
                        break;
                }
                break;
        }
    }

    #endregion
}
