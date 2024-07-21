using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public int Damage;
    public float FireRate;
    public float Range;
    public int Cost;

    public int UpgradeLevel = 0;
    public List<string> UpgradeNames = new List<string>();

    public TowerEnum TowerEnum;

    public Transform Barrel;

    public GameObject RangeIndicator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
        RangeIndicator.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void AssignStats(TowerEnum towerEnum)
    {
        switch(towerEnum)
        {
            case TowerEnum.DamageTower:
                Damage = (int)ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Damage];
                FireRate = (float)ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.FireRate];
                Range = (float)ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Range];
                Cost = (int)ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Cost];
                break;
            case TowerEnum.FreezeTower:
                Damage = (int)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Damage];
                FireRate = (float)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.FireRate];
                Range = (float)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Range];
                Cost = (int)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Cost];
                break;
            case TowerEnum.PoisonTower:
                Damage = (int)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.Damage];
                FireRate = (float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.FireRate];
                Range = (float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.Range];
                Cost = (int)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.Cost];
                break;
            case TowerEnum.BombTower:
                Damage = (int)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.Damage];
                FireRate = (float)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.FireRate];
                Range = (float)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.Range];
                Cost = (int)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.Cost];
                break;
        }
    }

    protected virtual void OnMouseDown()
    {
        if (!ReferencesManager.UIManager_Upgrades.isInSkillTree)
        {
            if (ReferencesManager.GameManager.currentTower == this.gameObject)
            {
                RangeIndicator.SetActive(false);
                ReferencesManager.GameManager.currentTower = null;

                ReferencesManager.UIManager_Stat.ResetStatCointainer();
            }
            else if (ReferencesManager.GameManager.currentTower == null)
            {
                RangeIndicator.SetActive(true);
                ReferencesManager.GameManager.currentTower = this.gameObject;

                ReferencesManager.UIManager_Stat.ShowStatDisplay(this.gameObject.name, isRight());
            }
        }
    }

    public bool isLeft()
    {
        var isLeft = this.gameObject.transform.position.x <= -5.3f ? true : false;

        return isLeft;
    }

    public bool isRight()
    {
        var isRight = this.gameObject.transform.position.x >= 4.2f ? true : false;

        return isRight;
    }

    public IEnumerator Shoot(GameObject projectile, int damage)
    {
        while(true)
        {
            GameObject bullet = Instantiate(projectile, Barrel.transform.position, Barrel.transform.rotation);
            bullet.GetComponent<TowerProjectile>().Damage = damage;
            yield return new WaitForSeconds(FireRate);
        }
    }

}
