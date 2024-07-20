using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager_Upgrades : MonoBehaviour
{
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
}
