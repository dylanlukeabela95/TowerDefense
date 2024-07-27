using Strings;
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
                else if(upgradeName.Contains("Level"+count))
                {
                    var nodes = new List<GameObject>();

                    switch(currentTower.GetComponent<Tower>().TowerEnum)
                    {
                        case TowerEnum.DamageTower:
                            nodes = DamageTowerNodes.Where(a => a.name.Contains("Level"+count)).ToList();
                            break;
                        case TowerEnum.FreezeTower:
                            nodes = FreezeTowerNodes.Where(a => a.name.Contains("Level"+count)).ToList();
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
        ReferencesManager.GameManager.currentTower.GetComponent<Tower>().UpgradeLevel++;
        ReferencesManager.GameManager.currentTower.GetComponent<Tower>().UpgradeNames.Add(node.name);
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
                                nextNodes =BombTowerLeftBranch.Where(a => a.name.Contains("Level3")).ToList();
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

                            if (node.name == "PoisonTower_Level3.1_Damage" || node.name == "PoisonTower_Level3.2_PoisonDamageOverTime")
                            {
                                nextNodes = PoisonTowerMiddleBranch.Where(a => a.name.Contains("Level4")).ToList();
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

                            if (node.name == "BombTower_Level3.1_DoubleExplosionChance" || node.name == "BombTower_Level3.2_SplashDamage")
                            {
                                nextNodes = BombTowerMiddleBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                            else if (node.name == "BombTower_Level3.1_Damage" || node.name == "BombTower_Level3.2_FireRate")
                            {
                                nextNodes = BombTowerLeftBranch.Where(a => a.name.Contains("Level4")).ToList();
                            }
                            else if (node.name == "BombTower_Level3.1_SplashRadius" || node.name == "BombTower_Level3.2_Range")
                            {
                                nextNodes = BombTowerRightBranch.Where(a => a.name.Contains("Level4")).ToList();
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

    void AlterStat(string stat, GameObject currentTower, GameObject node, Dictionary<string, object> upgradeCollection, string key, bool hasOtherNodes = false, List<GameObject> otherNodes = null)
    {
        switch(stat)
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
            case StringsDatabase.Stats.ImmobilizeChance:
                currentTower.GetComponent<FreezeTower>().CanImmobilize = true;
                currentTower.GetComponent<FreezeTower>().ImmobilizeChance = (int)upgradeCollection[key];

                if (!currentTower.GetComponent<FreezeTower>().Stats.Contains("Immobilize Chance"))
                {
                    currentTower.GetComponent<FreezeTower>().AddStat("Immobilize Chance");
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
                AlterStat(StringsDatabase.Stats.Damage, currentTower, node, damageTowerDamageDictionary, "Level 1");
                break;
            case "Level2":
                switch (nodeSplit[2])
                {
                    case "Damage":
                        damageTowerDamageDictionary = ReferencesManager.UpgradesManager.DamageTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = DamageTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, damageTowerDamageDictionary, "Level 2", true, otherNodes);
                        break;
                    case "FireRate":
                        damageTowerFireRateDictionary = ReferencesManager.UpgradesManager.DamageTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = DamageTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, damageTowerFireRateDictionary, "Level 2", true, otherNodes);
                        break;
                    case "Range":
                        damageTowerRangeDictionary = ReferencesManager.UpgradesManager.DamageTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = DamageTowerMiddleBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, damageTowerRangeDictionary, "Level 2", true, otherNodes);
                        break;
                }
                break;
            case "Level3":
                switch (nodeSplit[2])
                {
                    case "Projectile":
                        damageTowerProjectileDictionary = ReferencesManager.UpgradesManager.DamageTowerProjectile.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.ProjectileCount, currentTower, node, damageTowerProjectileDictionary, "Level 3");
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

                        AlterStat(StringsDatabase.Stats.TwoRoundBurstChance, currentTower, node, damageTowerBurstDictionary, "Level 3.1", true, otherNodes);

                        break;
                    case "Critical":
                        damageTowerCriticalDictionary = ReferencesManager.UpgradesManager.DamageTowerCriticalChance.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerRightBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.CriticalChance, currentTower, node, damageTowerCriticalDictionary, "Level 3.1", true, otherNodes);
                        
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

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, damageTowerFireRateDictionary, "Level 3.2", true, otherNodes);
                        break;

                    case "Range":
                        damageTowerRangeDictionary = ReferencesManager.UpgradesManager.DamageTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = DamageTowerRightBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, damageTowerRangeDictionary, "Level 3.2", true, otherNodes);
                        break;
                }
                break;
            case "Level4":
                switch (nodeSplit[2])
                {
                    case "FireRate":
                        damageTowerFireRateDictionary = ReferencesManager.UpgradesManager.DamageTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, damageTowerFireRateDictionary, "Level 4");
                        break;

                    case "Range":
                        damageTowerRangeDictionary = ReferencesManager.UpgradesManager.DamageTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, damageTowerRangeDictionary, "Level 4");
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

                        AlterStat(StringsDatabase.Stats.ProjectileCount, currentTower, node, damageTowerProjectileDictionary, "Level 4.1", true, otherNodes);
                        currentTower.GetComponent<DamageTower>().Damage = Mathf.FloorToInt(currentTower.GetComponent<DamageTower>().Damage * (ReferencesManager.UpgradesManager.DamageTowerDamage["Level 4.1"] * 1.0f) / 100);
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

                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, damageTowerDamageDictionary, "Level 4.2", true, otherNodes);
                        break;
                }
                break;
            case "Level5":
                switch (nodeSplit[2])
                {
                    case "Damage":
                        damageTowerDamageDictionary = ReferencesManager.UpgradesManager.DamageTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, damageTowerDamageDictionary, "Level 5");
                        break;
                    case "Burst":
                        damageTowerBurstDictionary = ReferencesManager.UpgradesManager.DamageTowerBurstChance.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.ThreeRoundBurstChance, currentTower, node, damageTowerBurstDictionary, "Level 5");
                        break;
                    case "Infinity":
                        damageTowerRangeDictionary = ReferencesManager.UpgradesManager.DamageTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, damageTowerRangeDictionary, "Level 5");
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
                AlterStat(StringsDatabase.Stats.IceDamage, currentTower, node, freezeTowerIceDamageDictionary, "Level 1");
                break;
            case "Level2":
                switch(nodeSplit[2])
                {
                    case "IceDamage":
                        freezeTowerIceDamageDictionary = ReferencesManager.UpgradesManager.FreezeTowerIceDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = FreezeTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.IceDamage, currentTower, node, freezeTowerIceDamageDictionary, "Level 2", true, otherNodes);
                        break;
                    case "FireRate":
                        freezeTowerFireRateDictionary = ReferencesManager.UpgradesManager.FreezeTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerMiddleBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = FreezeTowerRightBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, freezeTowerFireRateDictionary, "Level 2", true, otherNodes);
                        break;
                    case "SlowEffect":
                        freezeTowerSlowEffectDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowEffect.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerLeftBranch.Find(a => a.name.Contains("Level2"));
                        adjacentNode2 = FreezeTowerMiddleBranch.Find(a => a.name.Contains("Level2"));

                        otherNodes = new List<GameObject>() { adjacentNode1, adjacentNode2 };

                        AlterStat(StringsDatabase.Stats.SlowEffect, currentTower, node, freezeTowerSlowEffectDictionary, "Level 2", true, otherNodes);
                        break;
                }
                break;
            case "Level3":
                switch(nodeSplit[2])
                {
                    case "Range":
                        freezeTowerRangeDictionary = ReferencesManager.UpgradesManager.FreezeTowerRange.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, freezeTowerRangeDictionary, "Level 3");
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

                        AlterStat(StringsDatabase.Stats.IceDamage, currentTower, node, freezeTowerIceDamageDictionary, "Level 3.1", true, otherNodes);
                        break;
                    case "SlowDuration":
                        freezeTowerSlowDurationDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerLeftBranch.Find(a => a.name.Contains("Level3.2"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.SlowDuration, currentTower, node, freezeTowerSlowDurationDictionary, "Level 3.1", true, otherNodes);
                        break;
                }
                break;
            case "Level3.2":
                switch(nodeSplit[2])
                {
                    case "Frostbite":
                        freezeTowerFrostbiteDictionary = ReferencesManager.UpgradesManager.FreezeTowerFrostbite.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerMiddleBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.Frostbite, currentTower, node, freezeTowerFrostbiteDictionary, "Level 3.2", true, otherNodes);
                        break;
                    case "FireRate":
                        freezeTowerFireRateDictionary = ReferencesManager.UpgradesManager.FreezeTowerFireRate.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerLeftBranch.Find(a => a.name.Contains("Level3.1"));

                        otherNodes = new List<GameObject>() { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.FireRate, currentTower, node, freezeTowerFireRateDictionary, "Level 3.2", true, otherNodes);
                        break;
                }
                break;
            case "Level4":
                switch(nodeSplit[2])
                {
                    case "IceDamage":
                        freezeTowerIceDamageDictionary = ReferencesManager.UpgradesManager.FreezeTowerIceDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
                        freezeTowerDamageDictionary = ReferencesManager.UpgradesManager.FreezeTowerDamage.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.IceDamage, currentTower, node, freezeTowerIceDamageDictionary, "Level 4");
                        AlterStat(StringsDatabase.Stats.Damage, currentTower, node, freezeTowerDamageDictionary, "Level 4");
                        break;
                    case "SlowDuration":
                        freezeTowerSlowDurationDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.SlowDuration, currentTower, node, freezeTowerSlowDurationDictionary, "Level 4");
                        break;
                }
                break;
            case "Level4.1":
                switch(nodeSplit[2])
                {
                    case "SlowEffect":
                        freezeTowerSlowEffectDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowEffect.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        adjacentNode1 = FreezeTowerRightBranch.Find(a => a.name.Contains("Level4.2"));

                        otherNodes = new List<GameObject> { adjacentNode1 };

                        AlterStat(StringsDatabase.Stats.SlowEffect, currentTower, node, freezeTowerSlowEffectDictionary, "Level 4.1", true, otherNodes);
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

                        AlterStat(StringsDatabase.Stats.Range, currentTower, node, freezeTowerRangeDictionary, "Level 4.2", true, otherNodes);
                        break;
                }
                break;
            case "Level5":
                switch (nodeSplit[2])
                {
                    case "Icicle":
                        freezeTowerIcicleDictionary = ReferencesManager.UpgradesManager.FreezeTowerIcicle.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.Icicle, currentTower, node, freezeTowerIcicleDictionary, "Level 5");
                        break;
                    case "SlowDuration":
                        freezeTowerSlowDurationDictionary = ReferencesManager.UpgradesManager.FreezeTowerSlowDuration.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.SlowDuration, currentTower, node, freezeTowerSlowDurationDictionary, "Level 5");
                        break;
                    case "Immobilize":
                        freezeTowerImmobilizeDictionary = ReferencesManager.UpgradesManager.FreezeTowerImmobilize.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);

                        AlterStat(StringsDatabase.Stats.ImmobilizeChance, currentTower, node, freezeTowerImmobilizeDictionary, "Level 5");
                        break;
                }
                break;
        }
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
                DamageUpgrades(nodeSplit, currentTower, node, adjacentNode1, adjacentNode2, otherNodes);
                break;
            case "FreezeTower":
                FreezeUpgrades(nodeSplit, currentTower, node, adjacentNode1, adjacentNode2, otherNodes);
                break;
            case "PoisonTower":
                break;
            case "BombTower":
                break;
        }
    }

    #endregion
}
