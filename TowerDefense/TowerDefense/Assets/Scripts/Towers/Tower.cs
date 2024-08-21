using Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ItemAttached
{
    public Item Item { get; set; }
    public GameObject[] ItemSlot { get; set; } //2 since we have two side stat bars
    public ItemAttached()
    {
        
    }
}

public class Tower : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    [Header("Main Stats")]
    public int Damage;
    public float FireRate;
    public float Range;
    public int Cost;

    [Header("Upgrades")]
    public int UpgradeLevel = 0;
    public List<string> UpgradeNames = new List<string>();

    [Header("All Stats On Tower")]
    public List<string> Stats = new List<string>();

    public TowerEnum TowerEnum;

    public Transform Barrel;

    public int CriticalChance = 0;

    public GameObject RangeIndicator;

    public List<GameObject> EnemiesInRange = new List<GameObject>();

    public List<ItemAttached> ItemsAttached = new List<ItemAttached>();

    [Header("Selling Cost")]
    public int SellingCost;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
        RangeIndicator.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (EnemiesInRange.Count > 0)
        {
            LookAt_Horizontally(this.gameObject, EnemiesInRange[0].gameObject);
        }
    }

    public void LookAt_Horizontally(GameObject prefab, GameObject target)
    {
        Vector2 directionToTarget = target.transform.position - prefab.transform.position;
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        prefab.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
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
                DeselectTower();
            }
            else if (ReferencesManager.GameManager.currentTower == null)
            {
                SelectTower();
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

    public void DeselectTower()
    {
        RangeIndicator.GetComponent<SpriteRenderer>().enabled = false;
        ReferencesManager.GameManager.currentTower = null;

        ReferencesManager.UIManager_Stat.ResetStatCointainer();
    }

    public void SelectTower()
    {
        RangeIndicator.GetComponent<SpriteRenderer>().enabled = true;
        ReferencesManager.GameManager.currentTower = this.gameObject;

        ReferencesManager.UIManager_Stat.ShowStatDisplay(this.gameObject.name, isRight());
    }

    public void SetStats(List<string> statsManagerStats)
    {
        foreach (var item in statsManagerStats)
        {
            Stats.Add(item);
        }
    }

    public virtual void SellTower()
    {
        ReferencesManager.GameManager.coins += SellingCost;
        Destroy(this.gameObject);
    }

    public virtual IEnumerator Shoot(GameObject projectile)
    {
        while(true)
        {
            if (EnemiesInRange.Count > 0)
            {
                GameObject bullet = Instantiate(projectile, Barrel.position, Barrel.rotation);
                bullet.GetComponent<TowerProjectile>().target = EnemiesInRange[0].gameObject;
                bullet.GetComponent<TowerProjectile>().Damage = Damage;
                bullet.GetComponent<TowerProjectile>().FromTower = this.gameObject.name;
                yield return new WaitForSeconds(FireRate);
            }
            yield return null;
        }
    }

}
