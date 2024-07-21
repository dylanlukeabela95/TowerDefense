using Strings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UpgradesSection.SetActive(false);
            isInSkillTree = false;
        }

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
            for (int i = 0; i < skillTree.transform.childCount; i++)
            {
                if (skillTree.transform.GetChild(i).name != "Lines")
                {
                    skillTree.transform.GetChild(i).GetComponent<Image>().color = Color.gray;
                    skillTree.transform.GetChild(i).GetComponent<Button>().enabled = false;
                }
            }

            foreach (var upgradeName in currentTower.GetComponent<Tower>().UpgradeNames)
            {
                if(upgradeName.Contains("Level1"))
                {
                    GameObject node = null;
                    List<GameObject> nextNodes = new List<GameObject>();
                    switch (currentTower.GetComponent<Tower>().TowerEnum)
                    {
                        case TowerEnum.DamageTower:
                            node = DamageTowerNodes.Find(a => a.name.Contains("Level1"));
                            if(currentTower.GetComponent<Tower>().UpgradeLevel == 1)
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
                
                if(upgradeName.Contains("Level2"))
                {
                    var nodes = new List<GameObject>();

                    switch(currentTower.GetComponent<Tower>().TowerEnum)
                    {
                        case TowerEnum.DamageTower:
                            nodes = DamageTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                            break;
                        case TowerEnum.FreezeTower:
                            nodes = FreezeTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                            break;
                        case TowerEnum.PoisonTower:
                            nodes = PoisonTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                            break;
                        case TowerEnum.BombTower:
                            nodes = BombTowerNodes.Where(a => a.name.Contains("Level2")).ToList();
                            break;
                    }

                    if(nodes.Count > 0)
                    {
                        foreach(var node in nodes)
                        {
                            if(node.name == upgradeName)
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
            switch(currentTower.GetComponent<Tower>().TowerEnum)
            {
                case TowerEnum.DamageTower:
                    foreach(var child in DamageTowerNodes)
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
        ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().UpgradeLevel++;
        ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().UpgradeNames.Add(node.name);
        node.GetComponent<Image>().color = Color.green;
        node.GetComponent<Button>().enabled = false;

        if(areThereNodes)
        {
            foreach(var adjacentNode in otherNodes)
            {
                adjacentNode.GetComponent<Button>().enabled = false;
                adjacentNode.GetComponent<Image>().color = Color.gray;
            }
        }
    }

    void MakeNextNodesAvailable(int level, GameObject currentTower)
    {
        var nextNodes = new List<GameObject>();

        switch (level)
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
                switch(currentTower.GetComponent<Tower>().TowerEnum)
                {
                    case TowerEnum.DamageTower:
                        if (currentTower.GetComponent<Tower>().UpgradeNames[1].Contains("Level2"))
                        {
                            string selectedNode = currentTower.GetComponent<Tower>().UpgradeNames.Find(a => a.Contains("Level2"));

                            var node = DamageTowerNodes.Find(a => a.name == selectedNode);

                            if(node.name == "DamageTower_Level2_Damage")
                            {
                                nextNodes = DamageTowerMiddleBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if(node.name == "DamageTower_Level2_FireRate")
                            {
                                nextNodes = DamageTowerLeftBranch.Where(a => a.name.Contains("Level3")).ToList();
                            }
                            else if(node.name == "DamageTower_Level2_Range")
                            {
                                nextNodes = DamageTowerRightBranch.Where(a => a.name.Contains("Level3")).ToList();
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
        else if(currentTower.GetComponent<PoisonTower>())
        {
             return PoisonTowerSkillTree;
        }
        else if(currentTower.GetComponent<BombTower>())
        {
            return BombTowerSkillTree;
        }

        return null;
    }

    #region OnClick

    public void OnClick_UpgradeNode(GameObject node)
    {
        var nodeName = node.name;

        var nodeSplit = nodeName.Split('_');

        GameObject adjacentNode1 = null;
        GameObject adjacentNode2 = null;

        List<GameObject> otherNodes = new List<GameObject>();

        var currentTower = ReferencesManager.GameManager.currentTower;

        switch (nodeSplit[0])
        {
            case "DamageTower":
                switch (nodeSplit[1])
                {
                    case "Level1":
                        currentTower.GetComponent<DamageTower>().Damage += ReferencesManager.UpgradesManager.DamageTowerDamage["Level 1"];
                        ApplyChangesAfterNode(node, false);
                        MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                        break;
                    case "Level2":
                        switch (nodeSplit[2])
                        {
                            case "Damage":
                                currentTower.GetComponent<DamageTower>().Damage += ReferencesManager.UpgradesManager.DamageTowerDamage["Level 2"];

                                adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                                adjacentNode2 = DamageTowerRightBranch.Find(a => a.name.Contains("Level2"));

                                otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                                ApplyChangesAfterNode(node, true, otherNodes);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                                break;
                            case "FireRate":
                                currentTower.GetComponent<DamageTower>().FireRate -= ReferencesManager.UpgradesManager.DamageTowerFireRate["Level 2"];

                                adjacentNode1 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level2"));
                                adjacentNode2 = DamageTowerRightBranch.Find(a => a.name.Contains("Level2"));

                                otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                                ApplyChangesAfterNode(node, true, otherNodes);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                                break;
                            case "Range":
                                currentTower.GetComponent<DamageTower>().Range += ReferencesManager.UpgradesManager.DamageTowerRange["Level 2"];

                                adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                                adjacentNode2 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level2"));

                                otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                                ApplyChangesAfterNode(node, true, otherNodes);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);

                                ReferencesManager.TowerManager.SetRangeIndicator(currentTower.GetComponent<DamageTower>().Range, currentTower);
                                break;
                        }
                        break;
                    case "Level3":
                        switch (nodeSplit[2])
                        {
                            case "Projectile":
                                currentTower.GetComponent<DamageTower>().ProjectileCount += ReferencesManager.UpgradesManager.DamageTowerProjectile["Level 3"];
                                currentTower.GetComponent<DamageTower>().AddStat("Projectile Count");

                                ApplyChangesAfterNode(node, false);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                                break;
                        }
                        break;
                    case "Level3.1":
                        switch (nodeSplit[2])
                        {
                            case "Burst":
                                currentTower.GetComponent<DamageTower>().TwoRoundBurstChance += ReferencesManager.UpgradesManager.DamageTowerBurstChance["Level 3.1"];

                                adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level3.2"));

                                otherNodes = new List<GameObject>() { adjacentNode1 };

                                ApplyChangesAfterNode(node, true, otherNodes);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                                break;
                            case "Critical":
                                currentTower.GetComponent<DamageTower>().CriticalChance += ReferencesManager.UpgradesManager.DamageTowerCriticalChance["Level 3.1"];

                                adjacentNode1 = DamageTowerRightBranch.Find(a => a.name.Contains("Level3.2"));

                                otherNodes = new List<GameObject>() { adjacentNode1 };

                                ApplyChangesAfterNode(node, true, otherNodes);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                                break;
                        }
                        break;
                    case "Level3.2":
                        switch(nodeSplit[2])
                        {
                            case "FireRate":
                                currentTower.GetComponent<DamageTower>().FireRate -= ReferencesManager.UpgradesManager.DamageTowerFireRate["Level 3.2"];

                                adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level3.1"));

                                otherNodes = new List<GameObject>() { adjacentNode1 };

                                ApplyChangesAfterNode(node, true, otherNodes);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                                break;

                            case "Range":
                                currentTower.GetComponent<DamageTower>().Range += ReferencesManager.UpgradesManager.DamageTowerRange["Level 3.2"];

                                adjacentNode1 = DamageTowerRightBranch.Find(a => a.name.Contains("Level3.1"));

                                otherNodes = new List<GameObject>() { adjacentNode1 };

                                ApplyChangesAfterNode(node, true, otherNodes);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);

                                ReferencesManager.TowerManager.SetRangeIndicator(currentTower.GetComponent<DamageTower>().Range, currentTower);
                                break;
                        }
                        break;
                    case "Level4":
                        switch (nodeSplit[2])
                        {
                            case "FireRate":
                                currentTower.GetComponent<DamageTower>().FireRate -= ReferencesManager.UpgradesManager.DamageTowerFireRate["Level 4"];

                                ApplyChangesAfterNode(node, false);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                                break;

                            case "Range":
                                currentTower.GetComponent<DamageTower>().Range += ReferencesManager.UpgradesManager.DamageTowerRange["Level 4"];

                                ApplyChangesAfterNode(node, false);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);

                                ReferencesManager.TowerManager.SetRangeIndicator(currentTower.GetComponent<DamageTower>().Range, currentTower);
                                break;
                        }
                        break;
                    case "Level4.1":
                        switch (nodeSplit[2])
                        {
                            case "Projectile":
                                currentTower.GetComponent<DamageTower>().ProjectileCount += ReferencesManager.UpgradesManager.DamageTowerProjectile["Level 4.1"];
                                currentTower.GetComponent<DamageTower>().Damage = Mathf.FloorToInt(currentTower.GetComponent<DamageTower>().Damage * (ReferencesManager.UpgradesManager.DamageTowerDamage["Level 4.1"] * 1.0f) / 100);

                                adjacentNode1 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level4.2"));

                                otherNodes = new List<GameObject>() { adjacentNode1 };

                                ApplyChangesAfterNode(node, true, otherNodes);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                                break;
                        }
                        break;
                    case "Level4.2":
                        switch (nodeSplit[2])
                        {
                            case "Damage":
                                currentTower.GetComponent<DamageTower>().Damage += ReferencesManager.UpgradesManager.DamageTowerDamage["Level 4.2"];

                                adjacentNode1 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level4.1"));

                                otherNodes = new List<GameObject>() { adjacentNode1 };

                                ApplyChangesAfterNode(node, true, otherNodes);
                                MakeNextNodesAvailable(currentTower.GetComponent<Tower>().UpgradeLevel, currentTower);
                                break;
                        }
                        break;
                    case "Level5":
                        switch(nodeSplit[2])
                        {
                            case "Damage":
                                currentTower.GetComponent<DamageTower>().Damage += ReferencesManager.UpgradesManager.DamageTowerDamage["Level 5"];
                                ApplyChangesAfterNode(node, false);
                                break;
                            case "Burst":
                                currentTower.GetComponent<DamageTower>().ThreeRoundBurstChance -= ReferencesManager.UpgradesManager.DamageTowerBurstChance["Level 5"];
                                ApplyChangesAfterNode(node, false);
                                break;
                            case "Infinity":
                                currentTower.GetComponent<DamageTower>().Range = ReferencesManager.UpgradesManager.DamageTowerRange["Level 5"];
                                ApplyChangesAfterNode(node, false);
                                ReferencesManager.TowerManager.SetRangeIndicator(currentTower.GetComponent<DamageTower>().Range, currentTower);
                                break;
                        }
                        break;
                }
                break;
        }
    }

    #endregion
}
