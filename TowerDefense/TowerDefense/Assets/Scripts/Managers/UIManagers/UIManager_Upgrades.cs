using Stats_Descriptions;
using Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatComparison
{
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public string OldStat { get; set; }
    public string NewStat { get; set; }
    public bool Increased { get; set; }
    public StatComparison()
    {

    }
}

public class UIManager_Upgrades : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public bool isInSkillTree;

    [Header("Upgrades Section")]
    public GameObject UpgradesSection;

    [Header("Skill Trees")]
    public GameObject DamageTowerSkillTree;
    public GameObject FreezeTowerSkillTree;
    public GameObject PoisonTowerSkillTree;
    public GameObject BombTowerSkillTree;

    [Header("Nodes")]
    public List<GameObject> DamageTowerNodes;
    public List<GameObject> FreezeTowerNodes;
    public List<GameObject> PoisonTowerNodes;
    public List<GameObject> BombTowerNodes;

    [Header("Skill Tree Title")]
    public TextMeshProUGUI SkillTreeText;

    [Header("Branches")]
    [Header("Damage Tower")]
    public List<GameObject> DamageTowerLeftBranch = new List<GameObject>();
    public List<GameObject> DamageTowerMiddleBranch = new List<GameObject>();
    public List<GameObject> DamageTowerRightBranch = new List<GameObject>();

    [Header("Freeze Tower")]
    public List<GameObject> FreezeTowerLeftBranch = new List<GameObject>();
    public List<GameObject> FreezeTowerMiddleBranch = new List<GameObject>();
    public List<GameObject> FreezeTowerRightBranch = new List<GameObject>();

    [Header("Poison Tower")]
    public List<GameObject> PoisonTowerLeftBranch = new List<GameObject>();
    public List<GameObject> PoisonTowerMiddleBranch = new List<GameObject>();
    public List<GameObject> PoisonTowerRightBranch = new List<GameObject>();

    [Header("Bomb Tower")]
    public List<GameObject> BombTowerLeftBranch = new List<GameObject>();
    public List<GameObject> BombTowerMiddleBranch = new List<GameObject>();
    public List<GameObject> BombTowerRightBranch = new List<GameObject>();

    GameObject CurrentNode;
    public GameObject SideMenu;
    public GameObject UpgradeStat;
    public GameObject SelectedNode;

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
        UpgradesSection.SetActive(false);
        ShowHideSkillTree(false, false, false, false);
        SideMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UpgradesSection.activeSelf && !isInSkillTree)
        {
            isInSkillTree = true;
        }
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

    public void SetUpSkillTreeOptions(GameObject currentTower, GameObject skillTree)
    {
        if (currentTower.GetComponent<Tower>().UpgradeNames != null && currentTower.GetComponent<Tower>().UpgradeNames.Count > 0)
        {
            //set all nodes to false
            for (int i = 0; i < skillTree.transform.childCount; i++)
            {
                if (skillTree.transform.GetChild(i).name != "Lines")
                {
                    skillTree.transform.GetChild(i).GetComponent<Image>().color = Color.gray;
                    skillTree.transform.GetChild(i).GetComponent<Button>().enabled = false;
                }
            }

            var count = 2;

            foreach (var upgradeName in currentTower.GetComponent<Tower>().UpgradeNames)
            {
                if (upgradeName.Contains("Level1"))
                {
                    GameObject node = null;
                    List<GameObject> nextNodes = new List<GameObject>();
                    switch (currentTower.GetComponent<Tower>().TowerEnum)
                    {
                        case TowerEnum.DamageTower:
                            node = DamageTowerNodes.Find(a => a.name.Contains("Level1"));
                            if (currentTower.GetComponent<Tower>().UpgradeLevel == 1)
                            {
                                nextNodes = DamageTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                            }
                            break;
                        case TowerEnum.FreezeTower:
                            node = FreezeTowerNodes.Find(a => a.name.Contains("Level1"));
                            if (currentTower.GetComponent<Tower>().UpgradeLevel == 1)
                            {
                                nextNodes = FreezeTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                            }
                            break;
                        case TowerEnum.PoisonTower:
                            node = PoisonTowerNodes.Find(a => a.name.Contains("Level1"));
                            if (currentTower.GetComponent<Tower>().UpgradeLevel == 1)
                            {
                                nextNodes = PoisonTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                            }
                            break;
                        case TowerEnum.BombTower:
                            node = BombTowerNodes.Find(a => a.name.Contains("Level1"));
                            if (currentTower.GetComponent<Tower>().UpgradeLevel == 1)
                            {
                                nextNodes = BombTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                            }
                            break;
                    }

                    if (nextNodes.Count > 0)
                    {
                        foreach (var newNode in nextNodes)
                        {
                            newNode.GetComponent<Image>().color = Color.white;
                            newNode.GetComponent<Button>().enabled = true;
                        }
                    }

                    node.GetComponent<Image>().color = Color.green;
                    node.GetComponent<Button>().enabled = false;
                }
                else if (upgradeName.Contains("Level" + count))
                {
                    var nodes = new List<GameObject>();

                    switch (currentTower.GetComponent<Tower>().TowerEnum)
                    {
                        case TowerEnum.DamageTower:
                            nodes = DamageTowerNodes.Where(a => a.name.Contains("Level" + count)).ToList();
                            break;
                        case TowerEnum.FreezeTower:
                            nodes = FreezeTowerNodes.Where(a => a.name.Contains("Level" + count)).ToList();
                            break;
                        case TowerEnum.PoisonTower:
                            nodes = PoisonTowerNodes.Where(a => a.name.Contains("Level" + count)).ToList();
                            break;
                        case TowerEnum.BombTower:
                            nodes = BombTowerNodes.Where(a => a.name.Contains("Level" + count)).ToList();
                            break;
                    }

                    count++;

                    MakeNextNodesAvailable(currentTower);

                    if (nodes.Count > 0)
                    {
                        foreach (var node in nodes)
                        {
                            if (node.name == upgradeName)
                            {
                                node.GetComponent<Image>().color = Color.green;
                            }
                            else
                            {
                                node.GetComponent<Image>().color = Color.gray;
                            }

                            node.GetComponent<Button>().enabled = false;
                        }
                    }
                }
            }
        }
        else
        {
            switch (currentTower.GetComponent<Tower>().TowerEnum)
            {
                case TowerEnum.DamageTower:
                    foreach (var child in DamageTowerNodes)
                    {
                        if (child.name.Contains("Level1"))
                        {
                            child.GetComponent<Image>().color = Color.white;
                            child.GetComponent<Button>().enabled = true;
                        }
                        else
                        {
                            child.GetComponent<Image>().color = Color.gray;
                            child.GetComponent<Button>().enabled = false;
                        }
                    }
                    break;
                case TowerEnum.FreezeTower:
                    foreach (var child in FreezeTowerNodes)
                    {
                        if (child.name.Contains("Level1"))
                        {
                            child.GetComponent<Image>().color = Color.white;
                            child.GetComponent<Button>().enabled = true;
                        }
                        else
                        {
                            child.GetComponent<Image>().color = Color.gray;
                            child.GetComponent<Button>().enabled = false;
                        }
                    }
                    break;
                case TowerEnum.PoisonTower:
                    foreach (var child in PoisonTowerNodes)
                    {
                        if (child.name.Contains("Level1"))
                        {
                            child.GetComponent<Image>().color = Color.white;
                            child.GetComponent<Button>().enabled = true;
                        }
                        else
                        {
                            child.GetComponent<Image>().color = Color.gray;
                            child.GetComponent<Button>().enabled = false;
                        }
                    }
                    break;
                case TowerEnum.BombTower:
                    foreach (var child in BombTowerNodes)
                    {
                        if (child.name.Contains("Level1"))
                        {
                            child.GetComponent<Image>().color = Color.white;
                            child.GetComponent<Button>().enabled = true;
                        }
                        else
                        {
                            child.GetComponent<Image>().color = Color.gray;
                            child.GetComponent<Button>().enabled = false;
                        }
                    }
                    break;
            }
        }
    }

    void ApplyChangesAfterNode(GameObject node, bool areThereNodes, List<GameObject> otherNodes = null)
    {
        ReferencesManager.GameManager.currentTower.GetComponent<Tower>().UpgradeLevel++;
        ReferencesManager.GameManager.currentTower.GetComponent<Tower>().UpgradeNames.Add(node.name);
        node.GetComponent<Image>().color = Color.green;
        node.GetComponent<Button>().enabled = false;

        if (areThereNodes)
        {
            foreach (var adjacentNode in otherNodes)
            {
                adjacentNode.GetComponent<Button>().enabled = false;
                adjacentNode.GetComponent<Image>().color = Color.gray;
            }
        }
    }

    void MakeNextNodesAvailable(GameObject currentTower)
    {
        var nextNodes = new List<GameObject>();

        switch (currentTower.GetComponent<Tower>().UpgradeLevel)
        {
            case 1:
                switch (currentTower.GetComponent<Tower>().TowerEnum)
                {
                    case TowerEnum.DamageTower:
                        nextNodes = DamageTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                        break;
                    case TowerEnum.FreezeTower:
                        nextNodes = FreezeTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                        break;
                    case TowerEnum.PoisonTower:
                        nextNodes = PoisonTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                        break;
                    case TowerEnum.BombTower:
                        nextNodes = BombTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                        break;
                }
                break;
            case 2:
                switch (currentTower.GetComponent<Tower>().TowerEnum)
                {
                    case TowerEnum.DamageTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[1].Contains("Level2"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level2"));

                            var node = DamageTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "DamageTower_Level2_Damage")
                            {
                                nextNodes = DamageTowerMiddleBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if (node.name == "DamageTower_Level2_FireRate")
                            {
                                nextNodes = DamageTowerLeftBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if (node.name == "DamageTower_Level2_Range")
                            {
                                nextNodes = DamageTowerRightBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                        }
                        break;
                    case TowerEnum.FreezeTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[1].Contains("Level2"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level2"));

                            var node = FreezeTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "FreezeTower_Level2_IceDamage")
                            {
                                nextNodes = FreezeTowerMiddleBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if (node.name == "FreezeTower_Level2_FireRate")
                            {
                                nextNodes = FreezeTowerLeftBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if (node.name == "FreezeTower_Level2_SlowEffect")
                            {
                                nextNodes = FreezeTowerRightBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                        }
                        break;
                    case TowerEnum.PoisonTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[1].Contains("Level2"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level2"));

                            var node = PoisonTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "PoisonTower_Level2_PoisonDamageOverTime")
                            {
                                nextNodes = PoisonTowerMiddleBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if (node.name == "PoisonTower_Level2_PoisonDuration")
                            {
                                nextNodes = PoisonTowerLeftBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if (node.name == "PoisonTower_Level2_Range")
                            {
                                nextNodes = PoisonTowerRightBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                        }
                        break;
                    case TowerEnum.BombTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[1].Contains("Level2"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level2"));

                            var node = BombTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "BombTower_Level2_SplashDamage")
                            {
                                nextNodes = BombTowerMiddleBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if (node.name == "BombTower_Level2_Damage")
                            {
                                nextNodes = BombTowerLeftBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if (node.name == "BombTower_Level2_Range")
                            {
                                nextNodes = BombTowerRightBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                        }
                        break;
                }
                break;
            case 3:
                switch (currentTower.GetComponent<Tower>().TowerEnum)
                {
                    case TowerEnum.DamageTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[2].Contains("Level3"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level3"));

                            var node = DamageTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "DamageTower_Level3_Projectile")
                            {
                                nextNodes = DamageTowerMiddleBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                            else if (node.name == "DamageTower_Level3.1_Burst" || node.name == "DamageTower_Level3.2_FireRate")
                            {
                                nextNodes = DamageTowerLeftBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                            else if (node.name == "DamageTower_Level3.1_Critical" || node.name == "DamageTower_Level3.2_Range")
                            {
                                nextNodes = DamageTowerRightBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                        }
                        break;
                    case TowerEnum.FreezeTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[2].Contains("Level3"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level3"));

                            var node = FreezeTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "FreezeTower_Level3.1_IceDamage" || node.name == "FreezeTower_Level3.2_Frostbite")
                            {
                                nextNodes = FreezeTowerMiddleBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                            else if (node.name == "FreezeTower_Level3.1_SlowDuration" || node.name == "FreezeTower_Level3.2_FireRate")
                            {
                                nextNodes = FreezeTowerLeftBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                            else if (node.name == "FreezeTower_Level3_Range")
                            {
                                nextNodes = FreezeTowerRightBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                        }
                        break;
                    case TowerEnum.PoisonTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[2].Contains("Level3"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level3"));

                            var node = PoisonTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "PoisonTower_Level3.1_Damage")
                            {
                                nextNodes = PoisonTowerMiddleBranch.Where(a => a.name.Contains("Level4.1")).ToList();
                            }
                            else if (node.name == "PoisonTower_Level3.2_PoisonDamageOverTime")
                            {
                                nextNodes = PoisonTowerMiddleBranch.Where(a => a.name.Contains("Level4.2")).ToList();
                            }
                            else if (node.name == "PoisonTower_Level3.1_PoisonDuration" || node.name == "PoisonTower_Level3.2_PoisonTickRate")
                            {
                                nextNodes = PoisonTowerLeftBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                            else if (node.name == "PoisonTower_Level3.1_FireRate" || node.name == "PoisonTower_Level3.2_Range")
                            {
                                nextNodes = PoisonTowerRightBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                        }
                        break;
                    case TowerEnum.BombTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[2].Contains("Level3"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level3"));

                            var node = BombTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "BombTower_Level3.1_DoubleExplosionChance")
                            {
                                nextNodes = BombTowerMiddleBranch.Where(a => a.name.Contains("Level4.1")).ToList();
                            }
                            else if (node.name == "BombTower_Level3.2_SplashDamage")
                            {
                                nextNodes = BombTowerMiddleBranch.Where(a => a.name.Contains("Level4.2")).ToList();
                            }
                            else if (node.name == "BombTower_Level3.1_Damage" || node.name == "BombTower_Level3.2_FireRate")
                            {
                                nextNodes = BombTowerLeftBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                            else if (node.name == "BombTower_Level3.1_SplashRadius")
                            {
                                nextNodes = BombTowerRightBranch.Where(a => a.name.Contains("Level4.1")).ToList();
                            }
                            else if (node.name == "BombTower_Level3.2_Range")
                            {
                                nextNodes = BombTowerRightBranch.Where(a => a.name.Contains("Level4.2")).ToList();
                            }
                        }
                        break;
                }
                break;
            case 4:
                switch (currentTower.GetComponent<Tower>().TowerEnum)
                {
                    case TowerEnum.DamageTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[3].Contains("Level4"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level4"));

                            var node = DamageTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "DamageTower_Level4.1_Projectile_Damage" || node.name == "DamageTower_Level4.2_Damage")
                            {
                                nextNodes = DamageTowerMiddleBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                            else if (node.name == "DamageTower_Level4_FireRate")
                            {
                                nextNodes = DamageTowerLeftBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                            else if (node.name == "DamageTower_Level4_Range")
                            {
                                nextNodes = DamageTowerRightBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                        }
                        break;
                    case TowerEnum.FreezeTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[3].Contains("Level4"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level4"));

                            var node = FreezeTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "FreezeTower_Level4_IceDamage_Damage")
                            {
                                nextNodes = FreezeTowerMiddleBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                            else if (node.name == "FreezeTower_Level4_SlowDuration")
                            {
                                nextNodes = FreezeTowerLeftBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                            else if (node.name == "FreezeTower_Level4.1_SlowEffect" || node.name == "FreezeTower_Level4.2_Range")
                            {
                                nextNodes = FreezeTowerRightBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                        }
                        break;
                    case TowerEnum.PoisonTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[3].Contains("Level4"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level4"));

                            var node = PoisonTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "PoisonTower_Level4.1_Damage" || node.name == "PoisonTower_Level4.2_PoisonTickRate")
                            {
                                nextNodes = PoisonTowerMiddleBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                            else if (node.name == "PoisonTower_Level4_PoisonDuration")
                            {
                                nextNodes = PoisonTowerLeftBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                            else if (node.name == "PoisonTower_Level4_Range")
                            {
                                nextNodes = PoisonTowerRightBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                        }
                        break;
                    case TowerEnum.BombTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[3].Contains("Level4"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level4"));

                            var node = BombTowerNodes.Find(a => a.name == selectedNode);

                            if (node.name == "BombTower_Level4.1_DoubleExplosionChance" || node.name == "BombTower_Level4.2_SplashDamage")
                            {
                                nextNodes = BombTowerMiddleBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                            else if (node.name == "BombTower_Level4_Damage")
                            {
                                nextNodes = BombTowerLeftBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                            else if (node.name == "BombTower_Level4.1_SplashRadius" || node.name == "BombTower_Level4.2_Range")
                            {
                                nextNodes = BombTowerRightBranch.Where(a => a.name.Contains("Level5")).ToList();
                            }
                        }
                        break;
                }
                break;
        }


        foreach (var node in nextNodes)
        {
            node.GetComponent<Image>().color = Color.white;
            node.GetComponent<Button>().enabled = true;
        }
    }

    public GameObject ReturnTypeSkillTree(GameObject currentTower)
    {
        if (currentTower.GetComponent<DamageTower>())
        {
            return DamageTowerSkillTree;
        }
        else if (currentTower.GetComponent<FreezeTower>())
        {
            return FreezeTowerSkillTree;
        }
        else if (currentTower.GetComponent<PoisonTower>())
        {
            return PoisonTowerSkillTree;
        }
        else if (currentTower.GetComponent<BombTower>())
        {
            return BombTowerSkillTree;
        }

        return null;
    }

    void AlterStat(string stat, GameObject currentTower, GameObject node, Dictionary<string, object> upgradeCollection, string key, bool hasOtherNodes = false, List<GameObject> otherNodes = null)
    {
        switch (stat)
        {
            case StringsDatabase.Stats.Damage:
                currentTower.GetComponent<Tower>().Damage += (int)upgradeCollection[key];
                break;
            case StringsDatabase.Stats.FireRate:
                currentTower.GetComponent<Tower>().FireRate -= (float)upgradeCollection[key];
                break;
            case StringsDatabase.Stats.Range:
                currentTower.GetComponent<Tower>().Range += (float)upgradeCollection[key];
                ReferencesManager.TowerManager.SetRangeIndicator(currentTower.GetComponent<Tower>().Range, currentTower);
                break;
            case StringsDatabase.Stats.ProjectileCount:
                currentTower.GetComponent<DamageTower>().ProjectileCount += (int)upgradeCollection[key];

                if (!currentTower.GetComponent<DamageTower>().Stats.Contains("Projectile Count"))
                {
                    currentTower.GetComponent<DamageTower>().AddStat("Projectile Count");
                }
                break;
            case StringsDatabase.Stats.TwoRoundBurstChance:
                currentTower.GetComponent<DamageTower>().TwoRoundBurstChance += (int)upgradeCollection[key];

                if (!currentTower.GetComponent<DamageTower>().Stats.Contains("Two Round Burst Chance"))
                {
                    currentTower.GetComponent<DamageTower>().AddStat("Two Round Burst Chance");
                }
                break;
            case StringsDatabase.Stats.ThreeRoundBurstChance:
                currentTower.GetComponent<DamageTower>().ThreeRoundBurstChance += (int)upgradeCollection[key];

                if (!currentTower.GetComponent<DamageTower>().Stats.Contains("Three Round Burst Chance"))
                {
                    currentTower.GetComponent<DamageTower>().AddStat("Three Round Burst Chance");
                }
                break;
            case StringsDatabase.Stats.CriticalChance:
                currentTower.GetComponent<DamageTower>().CriticalChance += (int)upgradeCollection[key];
                if (!currentTower.GetComponent<DamageTower>().Stats.Contains("Critical Chance"))
                {
                    currentTower.GetComponent<DamageTower>().AddStat("Critical Chance");
                    currentTower.GetComponent<DamageTower>().AddStat("Critical Damage");
                }
                break;
            case StringsDatabase.Stats.IceDamage:
                if (!currentTower.GetComponent<FreezeTower>().CanFrostbite)
                {
                    currentTower.GetComponent<FreezeTower>().IceDamage += (int)upgradeCollection[key];
                }
                else
                {
                    currentTower.GetComponent<FreezeTower>().FrostbiteDamage += Mathf.FloorToInt(((int)upgradeCollection[key] * 1.0f) / 2);
                }
                break;
            case StringsDatabase.Stats.SlowDuration:
                currentTower.GetComponent<FreezeTower>().SlowDuration += (float)upgradeCollection[key];
                break;
            case StringsDatabase.Stats.SlowEffect:
                currentTower.GetComponent<FreezeTower>().SlowEffect += (float)upgradeCollection[key];
                break;
            case StringsDatabase.Stats.Frostbite:
                currentTower.GetComponent<FreezeTower>().CanFrostbite = (bool)upgradeCollection[key];

                if (currentTower.GetComponent<FreezeTower>().FrostbiteDamage == 0)
                {
                    currentTower.GetComponent<FreezeTower>().FrostbiteDamage = Mathf.FloorToInt((currentTower.GetComponent<FreezeTower>().IceDamage * 1.0f) / 2);
                    currentTower.GetComponent<FreezeTower>().FrostbiteTickRate = 0.5f;
                }

                if (currentTower.GetComponent<FreezeTower>().Stats.Contains("Ice Damage"))
                {
                    currentTower.GetComponent<FreezeTower>().RemoveStat("Ice Damage");
                    currentTower.GetComponent<FreezeTower>().AddStat("Frostbite Damage");
                    currentTower.GetComponent<FreezeTower>().AddStat("Frostbite Tick Rate");
                }
                break;
            case StringsDatabase.Stats.Icicle:
                currentTower.GetComponent<FreezeTower>().CanIcicle = true;
                currentTower.GetComponent<FreezeTower>().IcicleChance = (int)upgradeCollection[key];
                currentTower.GetComponent<FreezeTower>().IcicleDamage = 10;

                if (!currentTower.GetComponent<FreezeTower>().Stats.Contains("Icicle Damage"))
                {
                    currentTower.GetComponent<FreezeTower>().AddStat("Icicle Damage");
                    currentTower.GetComponent<FreezeTower>().AddStat("Icicle Chance");
                }
                break;
            case StringsDatabase.Stats.Immobilize:
                currentTower.GetComponent<FreezeTower>().CanImmobilize = true;
                currentTower.GetComponent<FreezeTower>().ImmobilizeChance = (int)upgradeCollection[key];

                if (!currentTower.GetComponent<FreezeTower>().Stats.Contains("Immobilize Chance"))
                {
                    currentTower.GetComponent<FreezeTower>().AddStat("Immobilize Chance");
                }
                break;
            case StringsDatabase.Stats.PoisonDamageOverTime:
                currentTower.GetComponent<PoisonTower>().PoisonDamageOverTime += (int)upgradeCollection[key];
                break;
            case StringsDatabase.Stats.PoisonDuration:
                currentTower.GetComponent<PoisonTower>().PoisonDuration += (float)upgradeCollection[key];
                break;
            case StringsDatabase.Stats.PoisonTickRate:
                currentTower.GetComponent<PoisonTower>().PoisonTickRate -= (float)upgradeCollection[key];
                break;
            case StringsDatabase.Stats.PoisonCriticalChance:
                ReferencesManager.GameManager.PoisonCriticalChance += (int)upgradeCollection[key];

                if (ReferencesManager.GameManager.PoisonCriticalChance > 0 && !ReferencesManager.StatsManager.PoisonTowerStats.Contains(StringsDatabase.Stats_Display.PoisonCriticalChance))
                {
                    ReferencesManager.StatsManager.AddToList(ReferencesManager.StatsManager.PoisonTowerStats, StringsDatabase.Stats_Display.PoisonCriticalChance);
                    ReferencesManager.StatsManager.AddToList(ReferencesManager.StatsManager.PoisonTowerStats, StringsDatabase.Stats_Display.PoisonCriticalDamage);

                    var poisonTowers = ReferencesManager.GameManager.AllTowers.Where(a => a.name.Contains("PoisonTower"));
                    foreach (var poisonTower in poisonTowers)
                    {
                        poisonTower.GetComponent<PoisonTower>().Stats.Add(StringsDatabase.Stats_Display.PoisonCriticalChance);
                        poisonTower.GetComponent<PoisonTower>().Stats.Add(StringsDatabase.Stats_Display.PoisonCriticalDamage);
                    }
                }
                break;
            case StringsDatabase.Stats.PoisonSpread:
                currentTower.GetComponent<PoisonTower>().PoisonSpread = true;
                currentTower.GetComponent<PoisonTower>().PoisonSpreadRadius = (float)upgradeCollection[key];

                if (!currentTower.GetComponent<PoisonTower>().Stats.Contains(StringsDatabase.Stats_Display.PoisonSpreadRadius))
                {
                    currentTower.GetComponent<PoisonTower>().AddStat(StringsDatabase.Stats_Display.PoisonSpreadRadius);
                }
                break;
            case StringsDatabase.Stats.SplashDamage:
                currentTower.GetComponent<BombTower>().SplashDamage += (int)upgradeCollection[key];
                break;
            case StringsDatabase.Stats.SplashRadius:
                currentTower.GetComponent<BombTower>().SplashRadius += (float)upgradeCollection[key];
                break;
            case StringsDatabase.Stats.DoubleExplosionChance:
                currentTower.GetComponent<BombTower>().DoubleExplosionChance += (int)upgradeCollection[key];

                if (!currentTower.GetComponent<BombTower>().Stats.Contains(StringsDatabase.Stats_Display.DoubleExplosionChance))
                {
                    currentTower.GetComponent<BombTower>().Stats.Add(StringsDatabase.Stats_Display.DoubleExplosionChance);
                }
                break;
            case StringsDatabase.Stats.Rocket:
                currentTower.GetComponent<BombTower>().RocketChance = (int)upgradeCollection[key];
                currentTower.GetComponent<BombTower>().RocketDamage = ReferencesManager.UpgradesManager.RocketDamage;
                
                if (!currentTower.GetComponent<BombTower>().Stats.Contains(StringsDatabase.Stats_Display.RocketChance))
                {
                    currentTower.GetComponent<BombTower>().Stats.Add(StringsDatabase.Stats_Display.RocketChance);
                    currentTower.GetComponent<BombTower>().Stats.Add(StringsDatabase.Stats_Display.RocketDamage);
                }
                break;
        }

        if (hasOtherNodes)
        {
            ApplyChangesAfterNode(node, true, otherNodes);
        }
        else
        {
            ApplyChangesAfterNode(node, false);
        }

        MakeNextNodesAvailable(currentTower);
    }

    void DamageUpgrades(string[] nodeSplit, GameObject currentTower, GameObject node, GameObject adjacentNode1, GameObject adjacentNode2, List<GameObject> otherNodes)
    {
        Dictionary<string, object> damageTowerDamageDictionary = new Dictionary<string, object>();
        Dictionary<string, object> damageTowerFireRateDictionary = new Dictionary<string, object>();
        Dictionary<string, object> damageTowerRangeDictionary = new Dictionary<string, object>();
        Dictionary<string, object> damageTowerProjectileDictionary = new Dictionary<string, object>();
        Dictionary<string, object> damageTowerBurstDictionary = new Dictionary<string, object>();
        Dictionary<string, object> damageTowerCriticalDictionary = new Dictionary<string, object>();

        switch (nodeSplit[1])
        {
            case "Level1":
                damageTowerDamageDictionary = ReferencesManager.UpgradesManager.DamageTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                AlterStat(StringsDatabase.Stats.Damage, currentTower, node, damageTowerDamageDictionary, "Level1");
                break;
            case "Level2":
                switch (nodeSplit[2])
                {
                    case "Damage":
                        damageTowerDamageDictionary = ReferencesManager.UpgradesManager.DamageTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = DamageTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, damageTowerDamageDictionary, "Level2", true, otherNodes);
                        break;
                    case "FireRate":
                        damageTowerFireRateDictionary = ReferencesManager.UpgradesManager.DamageTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = DamageTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, damageTowerFireRateDictionary, "Level2", true, otherNodes);
                        break;
                    case "Range":
                        damageTowerRangeDictionary = ReferencesManager.UpgradesManager.DamageTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, damageTowerRangeDictionary, "Level2", true, otherNodes);
                        break;
                }
                break;
            case "Level3":
                switch (nodeSplit[2])
                {
                    case "Projectile":
                        damageTowerProjectileDictionary = ReferencesManager.UpgradesManager.DamageTowerProjectile.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.ProjectileCount, currentTower, node, damageTowerProjectileDictionary, "Level3");
                        break;
                }
                break;
            case "Level3.1":
                switch (nodeSplit[2])
                {
                    case "Burst":
                        damageTowerBurstDictionary = ReferencesManager.UpgradesManager.DamageTowerBurstChance.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.TwoRoundBurstChance, currentTower, node, damageTowerBurstDictionary, "Level3.1", true, otherNodes);

                        break;
                    case "Critical":
                        damageTowerCriticalDictionary = ReferencesManager.UpgradesManager.DamageTowerCriticalChance.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerRightBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.CriticalChance, currentTower, node, damageTowerCriticalDictionary, "Level3.1", true, otherNodes);

                        break;
                }
                break;
            case "Level3.2":
                switch (nodeSplit[2])
                {
                    case "FireRate":
                        damageTowerFireRateDictionary = ReferencesManager.UpgradesManager.DamageTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, damageTowerFireRateDictionary, "Level3.2", true, otherNodes);
                        break;

                    case "Range":
                        damageTowerRangeDictionary = ReferencesManager.UpgradesManager.DamageTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerRightBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, damageTowerRangeDictionary, "Level3.2", true, otherNodes);
                        break;
                }
                break;
            case "Level4":
                switch (nodeSplit[2])
                {
                    case "FireRate":
                        damageTowerFireRateDictionary = ReferencesManager.UpgradesManager.DamageTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, damageTowerFireRateDictionary, "Level4");
                        break;

                    case "Range":
                        damageTowerRangeDictionary = ReferencesManager.UpgradesManager.DamageTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, damageTowerRangeDictionary, "Level4");
                        break;
                }
                break;
            case "Level4.1":
                switch (nodeSplit[2])
                {
                    case "Projectile":
                        damageTowerProjectileDictionary = ReferencesManager.UpgradesManager.DamageTowerProjectile.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level4.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.ProjectileCount, currentTower, node, damageTowerProjectileDictionary, "Level4.1", true, otherNodes);
                        currentTower.GetComponent<DamageTower>().Damage = Mathf.FloorToInt(currentTower.GetComponent<DamageTower>().Damage * (ReferencesManager.UpgradesManager.DamageTowerDamage["Level4.1"] * 1.0f) / 100);
                        break;
                }
                break;
            case "Level4.2":
                switch (nodeSplit[2])
                {
                    case "Damage":
                        damageTowerDamageDictionary = ReferencesManager.UpgradesManager.DamageTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level4.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, damageTowerDamageDictionary, "Level4.2", true, otherNodes);
                        break;
                }
                break;
            case "Level5":
                switch (nodeSplit[2])
                {
                    case "Damage":
                        damageTowerDamageDictionary = ReferencesManager.UpgradesManager.DamageTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, damageTowerDamageDictionary, "Level5");
                        break;
                    case "Burst":
                        damageTowerBurstDictionary = ReferencesManager.UpgradesManager.DamageTowerBurstChance.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.ThreeRoundBurstChance, currentTower, node, damageTowerBurstDictionary, "Level5");
                        break;
                    case "Infinity":
                        damageTowerRangeDictionary = ReferencesManager.UpgradesManager.DamageTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, damageTowerRangeDictionary, "Level5");
                        break;
                }
                break;
        }
    }

    public void FreezeUpgrades(string[] nodeSplit, GameObject currentTower, GameObject node, GameObject adjacentNode1, GameObject adjacentNode2, List<GameObject> otherNodes)
    {
        Dictionary<string, object> freezeTowerIceDamageDictionary = new Dictionary<string, object>();
        Dictionary<string, object> freezeTowerDamageDictionary = new Dictionary<string, object>();
        Dictionary<string, object> freezeTowerFireRateDictionary = new Dictionary<string, object>();
        Dictionary<string, object> freezeTowerSlowEffectDictionary = new Dictionary<string, object>();
        Dictionary<string, object> freezeTowerRangeDictionary = new Dictionary<string, object>();
        Dictionary<string, object> freezeTowerSlowDurationDictionary = new Dictionary<string, object>();
        Dictionary<string, object> freezeTowerFrostbiteDictionary = new Dictionary<string, object>();
        Dictionary<string, object> freezeTowerIcicleDictionary = new Dictionary<string, object>();
        Dictionary<string, object> freezeTowerImmobilizeDictionary = new Dictionary<string, object>();

        switch (nodeSplit[1])
        {
            case "Level1":
                freezeTowerIceDamageDictionary = ReferencesManager.UpgradesManager.FreezeTowerIceDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                AlterStat(StringsDatabase.Stats.IceDamage, currentTower, node, freezeTowerIceDamageDictionary, "Level1");
                break;
            case "Level2":
                switch (nodeSplit[2])
                {
                    case "IceDamage":
                        freezeTowerIceDamageDictionary = ReferencesManager.UpgradesManager.FreezeTowerIceDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = FreezeTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.IceDamage, currentTower, node, freezeTowerIceDamageDictionary, "Level2", true, otherNodes);
                        break;
                    case "FireRate":
                        freezeTowerFireRateDictionary = ReferencesManager.UpgradesManager.FreezeTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerMiddleBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = FreezeTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, freezeTowerFireRateDictionary, "Level2", true, otherNodes);
                        break;
                    case "SlowEffect":
                        freezeTowerSlowEffectDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowEffect.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = FreezeTowerMiddleBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.SlowEffect, currentTower, node, freezeTowerSlowEffectDictionary, "Level2", true, otherNodes);
                        break;
                }
                break;
            case "Level3":
                switch (nodeSplit[2])
                {
                    case "Range":
                        freezeTowerRangeDictionary = ReferencesManager.UpgradesManager.FreezeTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, freezeTowerRangeDictionary, "Level3");
                        break;
                }
                break;
            case "Level3.1":
                switch (nodeSplit[2])
                {
                    case "IceDamage":
                        freezeTowerIceDamageDictionary = ReferencesManager.UpgradesManager.FreezeTowerIceDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerMiddleBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.IceDamage, currentTower, node, freezeTowerIceDamageDictionary, "Level3.1", true, otherNodes);
                        break;
                    case "SlowDuration":
                        freezeTowerSlowDurationDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerLeftBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.SlowDuration, currentTower, node, freezeTowerSlowDurationDictionary, "Level3.1", true, otherNodes);
                        break;
                }
                break;
            case "Level3.2":
                switch (nodeSplit[2])
                {
                    case "Frostbite":
                        freezeTowerFrostbiteDictionary = ReferencesManager.UpgradesManager.FreezeTowerFrostbite.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerMiddleBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Frostbite, currentTower, node, freezeTowerFrostbiteDictionary, "Level3.2", true, otherNodes);

                        currentTower.GetComponent<FreezeTower>().IceDamage = 0;
                        break;
                    case "FireRate":
                        freezeTowerFireRateDictionary = ReferencesManager.UpgradesManager.FreezeTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerLeftBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, freezeTowerFireRateDictionary, "Level3.2", true, otherNodes);
                        break;
                }
                break;
            case "Level4":
                switch (nodeSplit[2])
                {
                    case "IceDamage":
                        freezeTowerIceDamageDictionary = ReferencesManager.UpgradesManager.FreezeTowerIceDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        if (currentTower.GetComponent<FreezeTower>().IceDamage > 0)
                        {
                            AlterStat(StringsDatabase.Stats.IceDamage, currentTower, node, freezeTowerIceDamageDictionary, "Level4");
                        }
                        else
                        {
                            currentTower.GetComponent<FreezeTower>().FrostbiteDamage += Mathf.CeilToInt(ReferencesManager.UpgradesManager.FreezeTowerIceDamage["Level4"] * 1.0f / 2);
                        }

                        freezeTowerDamageDictionary = ReferencesManager.UpgradesManager.FreezeTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, freezeTowerDamageDictionary, "Level4");
                        break;
                    case "SlowDuration":
                        freezeTowerSlowDurationDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.SlowDuration, currentTower, node, freezeTowerSlowDurationDictionary, "Level4");
                        break;
                }
                break;
            case "Level4.1":
                switch (nodeSplit[2])
                {
                    case "SlowEffect":
                        freezeTowerSlowEffectDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowEffect.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerRightBranch.Find(a => a.name.Contains("Level4.2"));

                        otherNodes = new List<GameObject> { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.SlowEffect, currentTower, node, freezeTowerSlowEffectDictionary, "Level4.1", true, otherNodes);
                        break;
                }
                break;
            case "Level4.2":
                switch (nodeSplit[2])
                {
                    case "Range":
                        freezeTowerRangeDictionary = ReferencesManager.UpgradesManager.FreezeTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerRightBranch.Find(a => a.name.Contains("Level4.1"));

                        otherNodes = new List<GameObject> { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, freezeTowerRangeDictionary, "Level4.2", true, otherNodes);
                        break;
                }
                break;
            case "Level5":
                switch (nodeSplit[2])
                {
                    case "Icicle":
                        freezeTowerIcicleDictionary = ReferencesManager.UpgradesManager.FreezeTowerIcicle.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.Icicle, currentTower, node, freezeTowerIcicleDictionary, "Level5");
                        break;
                    case "SlowDuration":
                        freezeTowerSlowDurationDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.SlowDuration, currentTower, node, freezeTowerSlowDurationDictionary, "Level5");
                        break;
                    case "Immobilize":
                        freezeTowerImmobilizeDictionary = ReferencesManager.UpgradesManager.FreezeTowerImmobilize.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.Immobilize, currentTower, node, freezeTowerImmobilizeDictionary, "Level5");
                        break;
                }
                break;
        }
    }

    public void PoisonUpgrades(string[] nodeSplit, GameObject currentTower, GameObject node, GameObject adjacentNode1, GameObject adjacentNode2, List<GameObject> otherNodes)
    {
        Dictionary<string, object> poisonTowerDamageOverTimeDictionary = new Dictionary<string, object>();
        Dictionary<string, object> poisonTowerDurationDictionary = new Dictionary<string, object>();
        Dictionary<string, object> poisonTowerRangeDictionary = new Dictionary<string, object>();
        Dictionary<string, object> poisonTowerDamageDictionary = new Dictionary<string, object>();
        Dictionary<string, object> poisonTowerFireRateDictionary = new Dictionary<string, object>();
        Dictionary<string, object> poisonTowerTickRateDictionary = new Dictionary<string, object>();
        Dictionary<string, object> poisonTowerPoisonCriticalChanceDictionary = new Dictionary<string, object>();
        Dictionary<string, object> poisonTowerSpreadDictionary = new Dictionary<string, object>();

        switch (nodeSplit[1])
        {
            case "Level1":
                poisonTowerDamageOverTimeDictionary = ReferencesManager.UpgradesManager.PoisonTowerDamageOverTime.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                AlterStat(StringsDatabase.Stats.PoisonDamageOverTime, currentTower, node, poisonTowerDamageOverTimeDictionary, "Level1");
                break;
            case "Level2":
                switch (nodeSplit[2])
                {
                    case "PoisonDamageOverTime":
                        poisonTowerDamageOverTimeDictionary = ReferencesManager.UpgradesManager.PoisonTowerDamageOverTime.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = PoisonTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.PoisonDamageOverTime, currentTower, node, poisonTowerDamageOverTimeDictionary, "Level2", true, otherNodes);
                        break;
                    case "PoisonDuration":
                        poisonTowerDurationDictionary = ReferencesManager.UpgradesManager.PoisonTowerDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerMiddleBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = PoisonTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.PoisonDuration, currentTower, node, poisonTowerDurationDictionary, "Level2", true, otherNodes);
                        break;
                    case "Range":
                        poisonTowerRangeDictionary = ReferencesManager.UpgradesManager.PoisonTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = PoisonTowerMiddleBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, poisonTowerRangeDictionary, "Level2", true, otherNodes);
                        break;
                }
                break;
            case "Level3.1":
                switch (nodeSplit[2])
                {
                    case "Damage":
                        poisonTowerDamageDictionary = ReferencesManager.UpgradesManager.PoisonTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerMiddleBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, poisonTowerDamageDictionary, "Level3.1", true, otherNodes);
                        break;
                    case "PoisonDuration":
                        poisonTowerDurationDictionary = ReferencesManager.UpgradesManager.PoisonTowerDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerLeftBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.PoisonDuration, currentTower, node, poisonTowerDurationDictionary, "Level3.1", true, otherNodes);
                        break;
                    case "FireRate":
                        poisonTowerFireRateDictionary = ReferencesManager.UpgradesManager.PoisonTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerRightBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, poisonTowerFireRateDictionary, "Level3.1", true, otherNodes);
                        break;
                }
                break;
            case "Level3.2":
                switch (nodeSplit[2])
                {
                    case "PoisonDamageOverTime":
                        poisonTowerDamageOverTimeDictionary = ReferencesManager.UpgradesManager.PoisonTowerDamageOverTime.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerMiddleBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.PoisonDamageOverTime, currentTower, node, poisonTowerDamageOverTimeDictionary, "Level3.2", true, otherNodes);
                        break;
                    case "PoisonTickRate":
                        poisonTowerTickRateDictionary = ReferencesManager.UpgradesManager.PoisonTowerTickRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerLeftBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.PoisonTickRate, currentTower, node, poisonTowerTickRateDictionary, "Level3.2", true, otherNodes);
                        break;
                    case "Range":
                        poisonTowerRangeDictionary = ReferencesManager.UpgradesManager.PoisonTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerRightBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, poisonTowerRangeDictionary, "Level3.2", true, otherNodes);
                        break;
                }
                break;
            case "Level4":
                switch (nodeSplit[2])
                {
                    case "PoisonDuration":
                        poisonTowerDurationDictionary = ReferencesManager.UpgradesManager.PoisonTowerDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.PoisonDuration, currentTower, node, poisonTowerDurationDictionary, "Level4");
                        break;
                    case "Range":
                        poisonTowerRangeDictionary = ReferencesManager.UpgradesManager.PoisonTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, poisonTowerRangeDictionary, "Level4");
                        break;
                }
                break;
            case "Level4.1":
                switch (nodeSplit[2])
                {
                    case "Damage":
                        poisonTowerDamageDictionary = ReferencesManager.UpgradesManager.PoisonTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerMiddleBranch.Find(a => a.name.Contains("Level4.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, poisonTowerDamageDictionary, "Level4.1", true, otherNodes);
                        break;
                }
                break;
            case "Level4.2":
                switch (nodeSplit[2])
                {
                    case "PoisonTickRate":
                        poisonTowerTickRateDictionary = ReferencesManager.UpgradesManager.PoisonTowerTickRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = PoisonTowerMiddleBranch.Find(a => a.name.Contains("Level4.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.PoisonTickRate, currentTower, node, poisonTowerTickRateDictionary, "Level4.2", true, otherNodes);
                        break;
                }
                break;
            case "Level5":
                switch (nodeSplit[2])
                {
                    case "PoisonDOTCrit":
                        poisonTowerPoisonCriticalChanceDictionary = ReferencesManager.UpgradesManager.PoisonTowerPoisonCriticalChance.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.PoisonCriticalChance, currentTower, node, poisonTowerPoisonCriticalChanceDictionary, "Level5");
                        break;
                    case "PoisonDuration":
                        poisonTowerDurationDictionary = ReferencesManager.UpgradesManager.PoisonTowerDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.PoisonDuration, currentTower, node, poisonTowerDurationDictionary, "Level5");
                        break;
                    case "PoisonSpread":
                        poisonTowerSpreadDictionary = ReferencesManager.UpgradesManager.PoisonTowerPoisonSpreadRadius.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.PoisonSpread, currentTower, node, poisonTowerSpreadDictionary, "Level5");
                        break;
                }
                break;
        }
    }

    public void BombUpgrades(string[] nodeSplit, GameObject currentTower, GameObject node, GameObject adjacentNode1, GameObject adjacentNode2, List<GameObject> otherNodes)
    {
        Dictionary<string, object> bombTowerSplashDamageDictionary = new Dictionary<string, object>();
        Dictionary<string, object> bombTowerDamageDictionary = new Dictionary<string, object>();
        Dictionary<string, object> bombTowerRangeDictionary = new Dictionary<string, object>();
        Dictionary<string, object> bombTowerDoubleExplosionChanceDictionary = new Dictionary<string, object>();
        Dictionary<string, object> bombTowerSplashRadiusDictionary = new Dictionary<string, object>();
        Dictionary<string, object> bombTowerFireRateDictionary = new Dictionary<string, object>();
        Dictionary<string, object> bombTowerRocketDictionary = new Dictionary<string, object>();

        switch (nodeSplit[1])
        {
            case "Level1":
                bombTowerSplashDamageDictionary = ReferencesManager.UpgradesManager.BombTowerSplashDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                AlterStat(StringsDatabase.Stats.SplashDamage, currentTower, node, bombTowerSplashDamageDictionary, "Level1");
                break;
            case "Level2":
                switch (nodeSplit[2])
                {
                    case "SplashDamage":
                        bombTowerSplashDamageDictionary = ReferencesManager.UpgradesManager.BombTowerSplashDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = BombTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = BombTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.SplashDamage, currentTower, node, bombTowerSplashDamageDictionary, "Level2", true, otherNodes);
                        break;
                    case "Damage":
                        bombTowerDamageDictionary = ReferencesManager.UpgradesManager.BombTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = BombTowerMiddleBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = BombTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, bombTowerDamageDictionary, "Level2", true, otherNodes);
                        break;
                    case "Range":
                        bombTowerRangeDictionary = ReferencesManager.UpgradesManager.BombTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = BombTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = BombTowerMiddleBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, bombTowerRangeDictionary, "Level2", true, otherNodes);
                        break;
                }
                break;
            case "Level3.1":
                switch (nodeSplit[2])
                {
                    case "DoubleExplosionChance":
                        bombTowerDoubleExplosionChanceDictionary = ReferencesManager.UpgradesManager.BombTowerDoubleExplosionChance.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerMiddleBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.DoubleExplosionChance, currentTower, node, bombTowerDoubleExplosionChanceDictionary, "Level3.1", true, otherNodes);
                        break;
                    case "SplashRadius":
                        bombTowerSplashRadiusDictionary = ReferencesManager.UpgradesManager.BombTowerSplashRadius.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerRightBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.SplashRadius, currentTower, node, bombTowerSplashRadiusDictionary, "Level3.1", true, otherNodes);
                        break;
                    case "Damage":
                        bombTowerDamageDictionary = ReferencesManager.UpgradesManager.BombTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerLeftBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, bombTowerDamageDictionary, "Level3.1", true, otherNodes);
                        break;
                }
                break;
            case "Level3.2":
                switch (nodeSplit[2])
                {
                    case "SplashDamage":
                        bombTowerSplashDamageDictionary = ReferencesManager.UpgradesManager.BombTowerSplashDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerMiddleBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.SplashDamage, currentTower, node, bombTowerSplashDamageDictionary, "Level3.2", true, otherNodes);
                        break;
                    case "Range":
                        bombTowerRangeDictionary = ReferencesManager.UpgradesManager.BombTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerRightBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, bombTowerRangeDictionary, "Level3.2", true, otherNodes);
                        break;
                    case "FireRate":
                        bombTowerFireRateDictionary = ReferencesManager.UpgradesManager.BombTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerLeftBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, bombTowerFireRateDictionary, "Level3.2", true, otherNodes);
                        break;
                }
                break;
            case "Level4":
                bombTowerDamageDictionary = ReferencesManager.UpgradesManager.BombTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                AlterStat(StringsDatabase.Stats.Damage, currentTower, node, bombTowerDamageDictionary, "Level4");
                break;
            case "Level4.1":
                switch (nodeSplit[2])
                {
                    case "DoubleExplosionChance":
                        bombTowerDoubleExplosionChanceDictionary = ReferencesManager.UpgradesManager.BombTowerDoubleExplosionChance.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerMiddleBranch.Find(a => a.name.Contains("Level4.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.DoubleExplosionChance, currentTower, node, bombTowerDoubleExplosionChanceDictionary, "Level4.1", true, otherNodes);
                        break;
                    case "SplashRadius":
                        bombTowerSplashRadiusDictionary = ReferencesManager.UpgradesManager.BombTowerSplashRadius.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerRightBranch.Find(a => a.name.Contains("Level4.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.SplashRadius, currentTower, node, bombTowerSplashRadiusDictionary, "Level4.1", true, otherNodes);
                        break;
                }
                break;
            case "Level4.2":
                switch (nodeSplit[2])
                {
                    case "SplashDamage":
                        bombTowerSplashDamageDictionary = ReferencesManager.UpgradesManager.BombTowerSplashDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerMiddleBranch.Find(a => a.name.Contains("Level4.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.SplashDamage, currentTower, node, bombTowerSplashDamageDictionary, "Level4.2", true, otherNodes);
                        break;
                    case "Range":
                        bombTowerRangeDictionary = ReferencesManager.UpgradesManager.BombTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        adjacentNode1 = BombTowerRightBranch.Find(a => a.name.Contains("Level4.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, bombTowerRangeDictionary, "Level4.2", true, otherNodes);
                        break;
                }
                break;
            case "Level5":
                switch (nodeSplit[2])
                {
                    case "SplashDamage":
                        bombTowerSplashDamageDictionary = ReferencesManager.UpgradesManager.BombTowerSplashDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.SplashDamage, currentTower, node, bombTowerSplashDamageDictionary, "Level5");
                        break;
                    case "FireRate":
                        bombTowerFireRateDictionary = ReferencesManager.UpgradesManager.BombTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, bombTowerFireRateDictionary, "Level5");
                        break;
                    case "Rocket":
                        bombTowerRocketDictionary = ReferencesManager.UpgradesManager.BombTowerRocketChance.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.Rocket, currentTower, node, bombTowerRocketDictionary, "Level5");
                        break;
                }
                break;
        }
    }

    private StatComparison AddOldNewStats(object oldTowerStat, object newTowerStat, string statName, string statDescription, bool increased)
    {
        string oldStat = oldTowerStat.ToString();
        string newStat = newTowerStat.ToString();

        StatComparison statComparison = new StatComparison();

        if (
                statName == StringsDatabase.Stats_Display.FireRate ||
                statName == StringsDatabase.Stats_Display.PoisonTickRate
           )
        {
            oldStat = Convert.ToDouble(oldTowerStat).ToString("F2");
            newStat = Convert.ToDouble(newTowerStat).ToString("F2");

            statComparison = new StatComparison()
            {
                OldStat = oldStat,
                NewStat = newStat,
                StatName = statName,
                Increased = increased
            };
        }
        else
        {
            statComparison = new StatComparison()
            {
                OldStat = oldStat,
                NewStat = newStat,
                StatName = statName,
                Increased = increased
            };
        }

        if (statName.Contains("Rate"))
        {
            statComparison.OldStat += " / s";
            statComparison.NewStat += " / s";
        }
        else if (
                    statName == StringsDatabase.Stats_Display.Range ||
                    statName.Contains("Radius")
               )
        {
            int range = int.Parse(newStat);

            statComparison.OldStat += " m";
            if (range > 100)
            {
                statComparison.NewStat = "Infinite";
            }
            else
            {
                statComparison.NewStat += " m";
            }
        }
        else if (statName.Contains("Duration"))
        {
            statComparison.OldStat += " s";
            statComparison.NewStat += " s";
        }
        else if (statName.Contains("Chance") || statName == StringsDatabase.Stats_Display.SlowEffect)
        {
            statComparison.OldStat += " %";
            statComparison.NewStat += " %";
        }

        statComparison.StatDescription = statDescription;

        return statComparison;
    }

    List<StatComparison> GetNewStat(string stat, GameObject currentTower, GameObject node)
    {
        List<StatComparison> statsComparison = new List<StatComparison>();
        UpgradesManager upgradesManager = ReferencesManager.UpgradesManager;
        object oldStat;
        object newStat;
        string statName;
        string statDescription;
        bool increased = true;

        var split = node.name.Split('_');
        var level = split[1];

        switch (stat)
        {
            case StringsDatabase.Stats_Display.Damage:
                oldStat = (int)currentTower.GetComponent<Tower>().Damage;
                newStat = (int)0;
                statName = StringsDatabase.Stats_Display.Damage;
                statDescription = StatsDescriptions_General.DamageStatDescription;

                if (currentTower.name.Contains("DamageTower"))
                {
                    newStat = (int)(currentTower.GetComponent<Tower>().Damage + (int)upgradesManager.DamageTowerDamage[level]);
                }
                else if (currentTower.name.Contains("FreezeTower"))
                {
                    newStat = (int)(currentTower.GetComponent<Tower>().Damage + (int)upgradesManager.FreezeTowerDamage[level]);
                }
                else if (currentTower.name.Contains("PoisonTower"))
                {
                    newStat = (int)(currentTower.GetComponent<Tower>().Damage + (int)upgradesManager.PoisonTowerDamage[level]);
                }
                else if (currentTower.name.Contains("BombTower"))
                {
                    newStat = (int)(currentTower.GetComponent<Tower>().Damage + (int)upgradesManager.BombTowerDamage[level]);
                }

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.FireRate:
                oldStat = Mathf.Ceil((1 * 1.0f / (float)currentTower.GetComponent<Tower>().FireRate) * 100) / 100;
                newStat = (float)0f;
                statName = StringsDatabase.Stats_Display.FireRate;
                statDescription = StatsDescriptions_General.FireRateStatDescription;

                if (currentTower.name.Contains("DamageTower"))
                {
                    newStat = (float)(currentTower.GetComponent<Tower>().FireRate - (float)upgradesManager.DamageTowerFireRate[level]);
                }
                else if (currentTower.name.Contains("FreezeTower"))
                {
                    newStat = (float)(currentTower.GetComponent<Tower>().FireRate - (float)upgradesManager.FreezeTowerFireRate[level]);
                }
                else if (currentTower.name.Contains("PoisonTower"))
                {
                    newStat = (float)(currentTower.GetComponent<Tower>().FireRate - (float)upgradesManager.PoisonTowerFireRate[level]);
                }
                else if (currentTower.name.Contains("BombTower"))
                {
                    newStat = (float)(currentTower.GetComponent<Tower>().FireRate - (float)upgradesManager.BombTowerFireRate[level]);
                }

                newStat = Mathf.Ceil((1 * 1.0f / (float)newStat) * 100) / 100;

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.Range:
                oldStat = (float)currentTower.GetComponent<Tower>().Range;
                newStat = (float)0f;
                statName = StringsDatabase.Stats_Display.Range;
                statDescription = StatsDescriptions_General.RangeStatDescription;

                if (currentTower.name.Contains("DamageTower"))
                {
                    newStat = (float)(currentTower.GetComponent<Tower>().Range + (float)upgradesManager.DamageTowerRange[level]);
                    if(level == "Level5")
                    {
                        statDescription = StatsDescriptions_DamageTower.RangeInfiniteStatDescription;
                    }
                }
                else if (currentTower.name.Contains("FreezeTower"))
                {
                    newStat = (float)(currentTower.GetComponent<Tower>().Range + (float)upgradesManager.FreezeTowerRange[level]);
                }
                else if (currentTower.name.Contains("PoisonTower"))
                {
                    newStat = (float)(currentTower.GetComponent<Tower>().Range + (float)upgradesManager.PoisonTowerRange[level]);
                }
                else if (currentTower.name.Contains("BombTower"))
                {
                    newStat = (float)(currentTower.GetComponent<Tower>().Range + (float)upgradesManager.BombTowerRange[level]);
                }

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.ProjectileCount:
                oldStat = (int)currentTower.GetComponent<DamageTower>().ProjectileCount;
                newStat = (int)(currentTower.GetComponent<DamageTower>().ProjectileCount + (int)upgradesManager.DamageTowerProjectile[level]);
                statName = StringsDatabase.Stats_Display.ProjectileCount;
                statDescription = StatsDescriptions_DamageTower.ProjectileStatDescription;

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));

                if (level == "Level4.1")
                {
                    statDescription = StatsDescriptions_DamageTower.ProjectileDamageStatDescription;
                    statsComparison[0].StatDescription = statDescription;

                    oldStat = (int)currentTower.GetComponent<DamageTower>().Damage;
                    newStat = (int)Mathf.FloorToInt((currentTower.GetComponent<Tower>().Damage * 1.0f / 2));
                    statName = StringsDatabase.Stats_Display.Damage;
                    increased = false;

                    statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, "",  increased));
                }
                break;
            case StringsDatabase.Stats_Display.TwoRoundBurstChance:
                oldStat = (int)currentTower.GetComponent<DamageTower>().TwoRoundBurstChance;
                newStat = (int)(currentTower.GetComponent<DamageTower>().TwoRoundBurstChance + (int)upgradesManager.DamageTowerBurstChance[level]);
                statName = StringsDatabase.Stats_Display.TwoRoundBurstChance;
                statDescription = StatsDescriptions_DamageTower.TwoBurstStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.ThreeRoundBurstChance:
                oldStat = (int)currentTower.GetComponent<DamageTower>().ThreeRoundBurstChance;
                newStat = (int)(currentTower.GetComponent<DamageTower>().ThreeRoundBurstChance + (int)upgradesManager.DamageTowerBurstChance[level]);
                statName = StringsDatabase.Stats_Display.ThreeRoundBurstChance;
                statDescription = StatsDescriptions_DamageTower.ThreeBurstStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.CriticalChance:
                oldStat = (int)currentTower.GetComponent<DamageTower>().CriticalChance;
                newStat = (int)(currentTower.GetComponent<DamageTower>().CriticalChance + (int)upgradesManager.DamageTowerCriticalChance[level]);
                statName = StringsDatabase.Stats_Display.CriticalChance;
                statDescription = StatsDescriptions_DamageTower.CriticalStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName,statDescription, increased));

                oldStat = (int)0;
                newStat = (int)(currentTower.GetComponent<DamageTower>().Damage * 2);
                statName = StringsDatabase.Stats_Display.CriticalDamage;

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.IceDamage:
                if ((int)currentTower.GetComponent<FreezeTower>().IceDamage > 0)
                {
                    oldStat = (int)currentTower.GetComponent<FreezeTower>().IceDamage;
                    newStat = (int)((currentTower.GetComponent<FreezeTower>().IceDamage + (int)upgradesManager.FreezeTowerIceDamage[level]));
                    statName = StringsDatabase.Stats_Display.IceDamage;
                }
                else
                {
                    oldStat = (int)currentTower.GetComponent<FreezeTower>().FrostbiteDamage;
                    newStat = (int)((currentTower.GetComponent<FreezeTower>().FrostbiteDamage + Mathf.CeilToInt((int)upgradesManager.FreezeTowerIceDamage[level]) * 1.0f / 2));
                    statName = StringsDatabase.Stats_Display.Frostbite;
                }
                statDescription = StringsDatabase.Stats_Display.IceDamage;

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription,  increased));
                break;
            case StringsDatabase.Stats_Display.SlowDuration:
                oldStat = (float)currentTower.GetComponent<FreezeTower>().SlowDuration;
                newStat = (float)((currentTower.GetComponent<FreezeTower>().SlowDuration + (float)upgradesManager.FreezeTowerSlowDuration[level]));
                statName = StringsDatabase.Stats_Display.SlowDuration;
                statDescription = StatsDescriptions_FreezeTower.SlowDurationStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription,  increased));
                break;
            case StringsDatabase.Stats_Display.SlowEffect:
                oldStat = (float)currentTower.GetComponent<FreezeTower>().SlowEffect;
                newStat = (float)((currentTower.GetComponent<FreezeTower>().SlowEffect + (float)upgradesManager.FreezeTowerSlowEffect[level]));
                statName = StringsDatabase.Stats_Display.SlowEffect;
                statDescription = StatsDescriptions_FreezeTower.SlowEffectStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.Frostbite:
                oldStat = (int)currentTower.GetComponent<FreezeTower>().IceDamage;
                newStat = (int)0;
                statName = StringsDatabase.Stats_Display.IceDamage;
                increased = false;
                statDescription = StatsDescriptions_FreezeTower.FrostbiteStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));

                oldStat = (int)currentTower.GetComponent<FreezeTower>().FrostbiteDamage;
                newStat = (int)((currentTower.GetComponent<FreezeTower>().FrostbiteDamage + Mathf.FloorToInt((currentTower.GetComponent<FreezeTower>().IceDamage * 1.0f) / 2)));
                statName = StringsDatabase.Stats_Display.FrostbiteDamage;
                increased = true;

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, "", increased));

                oldStat = (float)currentTower.GetComponent<FreezeTower>().FrostbiteTickRate;
                newStat = (float)(0.5f);
                statName = StringsDatabase.Stats_Display.FrostbiteTickRate;

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, "", increased));
                break;
            case StringsDatabase.Stats.Icicle:
                oldStat = (int)currentTower.GetComponent<FreezeTower>().IcicleChance;
                newStat = (int)((currentTower.GetComponent<FreezeTower>().IcicleChance + (int)upgradesManager.FreezeTowerIcicle[level]));
                statName = StringsDatabase.Stats_Display.IcicleChance;
                statDescription = StatsDescriptions_FreezeTower.IcicleStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));

                oldStat = (int)currentTower.GetComponent<FreezeTower>().IcicleDamage;
                newStat = (int)((currentTower.GetComponent<FreezeTower>().IcicleDamage + 10));
                statName = StringsDatabase.Stats_Display.IcicleDanage;

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, "", increased));

                break;
            case StringsDatabase.Stats_Display.ImmobilizeChance:
                oldStat = (int)currentTower.GetComponent<FreezeTower>().ImmobilizeChance;
                newStat = (int)((currentTower.GetComponent<FreezeTower>().ImmobilizeChance + (int)upgradesManager.FreezeTowerImmobilize[level]));
                statName = StringsDatabase.Stats_Display.ImmobilizeChance;
                statDescription = StatsDescriptions_FreezeTower.ImmobilizeStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.PoisonDamageOverTime:
                oldStat = (int)currentTower.GetComponent<PoisonTower>().PoisonDamageOverTime;
                newStat = (int)((currentTower.GetComponent<PoisonTower>().PoisonDamageOverTime + (int)upgradesManager.PoisonTowerDamageOverTime[level]));
                statName = StringsDatabase.Stats_Display.PoisonDamageOverTime;
                statDescription = StatsDescriptions_PoisonTower.PoisonDamageOverTimeStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.PoisonDuration:
                oldStat = (float)currentTower.GetComponent<PoisonTower>().PoisonDuration;
                newStat = (float)((currentTower.GetComponent<PoisonTower>().PoisonDuration + (float)upgradesManager.PoisonTowerDuration[level]));
                statName = StringsDatabase.Stats_Display.PoisonDuration;
                statDescription = StatsDescriptions_PoisonTower.PoisonDurationStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.PoisonTickRate:
                oldStat = (1 * 1.0f) / (float)currentTower.GetComponent<PoisonTower>().PoisonTickRate;
                newStat = (1 * 1.0f) / (float)((currentTower.GetComponent<PoisonTower>().PoisonTickRate - (float)upgradesManager.PoisonTowerTickRate[level]));
                statName = StringsDatabase.Stats_Display.PoisonTickRate;
                statDescription = StatsDescriptions_PoisonTower.PoisonTickRateStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.PoisonCriticalChance:
                oldStat = ReferencesManager.GameManager.PoisonCriticalChance;
                newStat = ReferencesManager.GameManager.PoisonCriticalChance + (int)upgradesManager.PoisonTowerPoisonCriticalChance[level];
                statName = StringsDatabase.Stats_Display.PoisonCriticalChance;
                statDescription = StatsDescriptions_PoisonTower.PoisonDOTCriticalStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));

                oldStat = 0;
                newStat = currentTower.GetComponent<PoisonTower>().PoisonDamageOverTime * 2;
                statName = StringsDatabase.Stats_Display.PoisonCriticalDamage;

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, "", increased));
                break;
            case StringsDatabase.Stats_Display.PoisonSpreadRadius:
                oldStat = 0;
                newStat = 4;
                statName = StringsDatabase.Stats_Display.PoisonSpreadRadius;
                statDescription = StatsDescriptions_PoisonTower.PoisonSpreadStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.SplashDamage:
                oldStat = currentTower.GetComponent<BombTower>().SplashDamage;
                newStat = currentTower.GetComponent<BombTower>().SplashDamage + (int)upgradesManager.BombTowerSplashDamage[level];
                statName = StringsDatabase.Stats_Display.SplashDamage;
                statDescription = StatsDescriptions_BombTower.SplashDamageStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.SplashRadius:
                oldStat = currentTower.GetComponent<BombTower>().SplashRadius;
                newStat = currentTower.GetComponent<BombTower>().SplashRadius + (float)upgradesManager.BombTowerSplashRadius[level];
                statName = StringsDatabase.Stats_Display.SplashRadius;
                statDescription = StatsDescriptions_BombTower.SplashRadiusStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats_Display.DoubleExplosionChance:
                oldStat = currentTower.GetComponent<BombTower>().DoubleExplosionChance;
                newStat = currentTower.GetComponent<BombTower>().DoubleExplosionChance + (int)upgradesManager.BombTowerDoubleExplosionChance[level];
                statName = StringsDatabase.Stats_Display.DoubleExplosionChance;
                statDescription = StatsDescriptions_BombTower.DoubleExplosionChanceStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));
                break;
            case StringsDatabase.Stats.Rocket:
                oldStat = currentTower.GetComponent<BombTower>().RocketChance;
                newStat = currentTower.GetComponent<BombTower>().RocketChance + (int)upgradesManager.BombTowerRocketChance[level];
                statName = StringsDatabase.Stats_Display.RocketChance;
                statDescription = StatsDescriptions_BombTower.RocketStatDescription;
                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, statDescription, increased));

                oldStat = currentTower.GetComponent<BombTower>().RocketDamage;
                newStat = (int)upgradesManager.RocketDamage;
                statName = StringsDatabase.Stats_Display.RocketDamage;

                statsComparison.Add(AddOldNewStats(oldStat, newStat, statName, "", increased));
                break;
        }

        return statsComparison;
    }
    

    public void SetUpgradeStats(GameObject currentTower, GameObject node)
    {
        var statName = GetUpgradeTitle();

        if (SideMenu.transform.Find(StringsDatabase.UI_Upgrades.UpgradeStats).childCount > 0)
        {
            for (int i = 0; i < SideMenu.transform.Find(StringsDatabase.UI_Upgrades.UpgradeStats).childCount; i++)
            {
                Destroy(SideMenu.transform.Find(StringsDatabase.UI_Upgrades.UpgradeStats).GetChild(i).gameObject);
            }
        }

        var towerStats = GetNewStat(statName, currentTower, node);

        if (towerStats != null && towerStats.Count > 0)
        {
            foreach (var towerStat in towerStats)
            {
                SideMenu.transform.Find(StringsDatabase.UI_Upgrades.UpgradeTitle).GetComponent<TextMeshProUGUI>().text = towerStat.StatName;
                SideMenu.transform.Find(StringsDatabase.UI_Upgrades.UpgradeDescription).GetComponent<TextMeshProUGUI>().text = towerStat.StatDescription;
                GameObject upgradeStat = Instantiate(UpgradeStat, transform.position, Quaternion.identity, SideMenu.transform.Find(StringsDatabase.UI_Upgrades.UpgradeStats));
                upgradeStat.transform.Find(StringsDatabase.UI_Upgrades.UpgradeStatTitle).GetComponent<TextMeshProUGUI>().text = towerStat.StatName;
                upgradeStat.transform.Find(StringsDatabase.UI_Upgrades.StatsContainer).transform.Find(StringsDatabase.UI_Upgrades.UpgradeStatChanges_Old).GetComponent<TextMeshProUGUI>().text = towerStat.OldStat;

                upgradeStat.transform.Find(StringsDatabase.UI_Upgrades.StatsContainer).transform.Find(StringsDatabase.UI_Upgrades.UpgradeStatChanges_New).GetComponent<TextMeshProUGUI>().text = towerStat.NewStat;

                if (towerStat.Increased)
                {
                    upgradeStat.transform.Find(StringsDatabase.UI_Upgrades.StatsContainer).transform.Find(StringsDatabase.UI_Upgrades.UpgradeStatChanges_New).GetComponent<TextMeshProUGUI>().color = Color.green;
                }
                else
                {
                    upgradeStat.transform.Find(StringsDatabase.UI_Upgrades.StatsContainer).transform.Find(StringsDatabase.UI_Upgrades.UpgradeStatChanges_New).GetComponent<TextMeshProUGUI>().color = Color.red;
                }
            }
        }

        SetCostText(node);
    }

    public string GetUpgradeTitle()
    {
        var split = CurrentNode.transform.name.Split("_");

        switch (split[2])
        {
            case StringsDatabase.Stats.Damage:
                return StringsDatabase.Stats_Display.Damage;
            case StringsDatabase.Stats.FireRate:
                return StringsDatabase.Stats_Display.FireRate;
            case StringsDatabase.Stats.Range:
            case "Infinity":
                return StringsDatabase.Stats_Display.Range;
            case "Projectile":
                return StringsDatabase.Stats_Display.ProjectileCount;
            case "Burst":
                if (split[1] == "Level3.1")
                {
                    return StringsDatabase.Stats_Display.TwoRoundBurstChance;
                }
                else
                {
                    return StringsDatabase.Stats_Display.ThreeRoundBurstChance;
                }
            case "Critical":
                return StringsDatabase.Stats_Display.CriticalChance;
            case StringsDatabase.Stats.IceDamage:
                return StringsDatabase.Stats_Display.IceDamage;
            case StringsDatabase.Stats.SlowDuration:
                return StringsDatabase.Stats_Display.SlowDuration;
            case StringsDatabase.Stats.SlowEffect:
                return StringsDatabase.Stats_Display.SlowEffect;
            case StringsDatabase.Stats.Frostbite:
                return StringsDatabase.Stats.Frostbite;
            case StringsDatabase.Stats.Icicle:
                return StringsDatabase.Stats.Icicle;
            case StringsDatabase.Stats.Immobilize:
                return StringsDatabase.Stats_Display.ImmobilizeChance;
            case StringsDatabase.Stats.PoisonDamageOverTime:
                return StringsDatabase.Stats_Display.PoisonDamageOverTime;
            case StringsDatabase.Stats.PoisonDuration:
                return StringsDatabase.Stats_Display.PoisonDuration;
            case StringsDatabase.Stats.PoisonTickRate:
                return StringsDatabase.Stats_Display.PoisonTickRate;
            case "PoisonDOTCrit":
                return StringsDatabase.Stats_Display.PoisonCriticalChance;
            case StringsDatabase.Stats.PoisonSpread:
                return StringsDatabase.Stats_Display.PoisonSpreadRadius;
            case StringsDatabase.Stats.SplashDamage:
                return StringsDatabase.Stats_Display.SplashDamage;
            case StringsDatabase.Stats.SplashRadius:
                return StringsDatabase.Stats_Display.SplashRadius;
            case StringsDatabase.Stats.DoubleExplosionChance:
                return StringsDatabase.Stats_Display.DoubleExplosionChance;
            case StringsDatabase.Stats.Rocket:
                return StringsDatabase.Stats.Rocket;
            default:
                return string.Empty;
        }
    }

    private void SetUpgradeCostValue(int cost)
    {
        TextMeshProUGUI coinAmount = SideMenu.transform.Find(StringsDatabase.UI_Upgrades.UpgradeButton).transform.Find(StringsDatabase.UI_Upgrades.CostUpgrade).transform.Find(StringsDatabase.UI_Upgrades.CoinAmount).GetComponent<TextMeshProUGUI>();
        coinAmount.text = cost.ToString();

        if (ReferencesManager.GameManager.coins < cost)
        {
            coinAmount.color = Color.red;
        }
        else
        {
            coinAmount.color = Color.black;
        }
    }

    void DisplaySideMenuOnNodeClick(GameObject node)
    {
        CurrentNode = node;
        var currentTower = ReferencesManager.GameManager.currentTower;

        //Show Side Menu
        SideMenu.SetActive(true);
        Instantiate(SelectedNode, node.transform.position, Quaternion.identity, node.transform);

        //Show which node is selected
        SetUpgradeStats(currentTower, node);
    }

    private void SetCostText(GameObject node)
    {
        TowerEnum? towerEnum = TowerEnum.DamageTower;
        UpgradesEnum_Level? level = UpgradesEnum_Level.Level1;
        UpgradesEnum_Branch? branch = UpgradesEnum_Branch.MiddleBranch;
        int cost = 0;

        List<List<GameObject>> leftBranches = new List<List<GameObject>>() { DamageTowerLeftBranch, FreezeTowerLeftBranch, PoisonTowerLeftBranch, BombTowerLeftBranch };
        List<List<GameObject>> middleBranches = new List<List<GameObject>>() { DamageTowerMiddleBranch, FreezeTowerMiddleBranch, PoisonTowerMiddleBranch, BombTowerMiddleBranch };
        List<List<GameObject>> rightBranches = new List<List<GameObject>>() { DamageTowerRightBranch, FreezeTowerRightBranch, PoisonTowerRightBranch, BombTowerRightBranch };

        towerEnum = TowerEnumHandler.GetTowerEnum(node);

        level = UpgradeEnum_LevelHandler.GetLevel(node);

        branch = UpgradeEnum_BranchHandler.GetBranch(node, leftBranches, middleBranches, rightBranches);

        if (level == UpgradesEnum_Level.Level1)
        {
            cost = ReferencesManager.CostManager.GetUpgradeCost(towerEnum, UpgradesEnum_Level.Level1);
        }
        else
        {
            cost = ReferencesManager.CostManager.GetUpgradeCost(towerEnum, level, branch);
        }

        SetUpgradeCostValue(cost);
    }

    #region OnClick

    public void OnClick_UpgradeNode(GameObject node)
    {
        if (CurrentNode != null && CurrentNode != node)
        {
            Destroy(CurrentNode.transform.GetChild(0).gameObject);

            DisplaySideMenuOnNodeClick(node);
        }
        else if(CurrentNode == null)
        {
            DisplaySideMenuOnNodeClick(node);
        }

        TextMeshProUGUI sideMenuCoins = SideMenu.transform.Find(StringsDatabase.UI_Upgrades.CostSection).transform.Find(StringsDatabase.UI_Upgrades.CoinsText).GetComponent<TextMeshProUGUI>();

        if (sideMenuCoins.text == "9999" || (sideMenuCoins.text != "9999" && sideMenuCoins.text != ReferencesManager.GameManager.coins.ToString()))
        {
            ReferencesManager.UIManager_Cost.UpdateCoins(sideMenuCoins, ReferencesManager.GameManager.coins);
        }
    }

    public void OnClick_UpgradeButton()
    {
        int cost = int.Parse(SideMenu.transform.Find(StringsDatabase.UI_Upgrades.UpgradeButton).transform.Find(StringsDatabase.UI_Upgrades.CostUpgrade).transform.Find(StringsDatabase.UI_Upgrades.CoinAmount).GetComponent<TextMeshProUGUI>().text);

        if (ReferencesManager.GameManager.coins >= cost)
        {
            SideMenu.SetActive(false);
            Destroy(CurrentNode.transform.GetChild(0).gameObject);
            var nodeSplit = CurrentNode.name.Split('_');

            GameObject adjacentNode1 = null;
            GameObject adjacentNode2 = null;

            List<GameObject> otherNodes = new List<GameObject>();

            var currentTower = ReferencesManager.GameManager.currentTower;

            switch (nodeSplit[0])
            {
                case "DamageTower":
                    DamageUpgrades(nodeSplit, currentTower, CurrentNode, adjacentNode1, adjacentNode2, otherNodes);
                    break;
                case "FreezeTower":
                    FreezeUpgrades(nodeSplit, currentTower, CurrentNode, adjacentNode1, adjacentNode2, otherNodes);
                    break;
                case "PoisonTower":
                    PoisonUpgrades(nodeSplit, currentTower, CurrentNode, adjacentNode1, adjacentNode2, otherNodes);
                    break;
                case "BombTower":
                    BombUpgrades(nodeSplit, currentTower, CurrentNode, adjacentNode1, adjacentNode2, otherNodes);
                    break;
            }

            CurrentNode = null;

            ReferencesManager.GameManager.ReduceCoins(cost);
            ReferencesManager.UIManager_Cost.UpdateCoins();
        }
    }

    public void OnClick_SideMenuClose()
    {
        SideMenu.SetActive(false);
        Destroy(CurrentNode.transform.GetChild(0).gameObject);
        CurrentNode = null;
    }

    public void OnClick_SkillTreeClose()
    {
        ShowHideSkillTree(false, false, false, false);
        UpgradesSection.SetActive(false);
        isInSkillTree = false;

        ReferencesManager.GameManager.currentTower.GetComponent<Tower>().DeselectTower();

        if(SideMenu.activeSelf)
        {
            OnClick_SideMenuClose();
        }
    }

    #endregion
}
