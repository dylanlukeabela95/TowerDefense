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

    public Transform Barrel;

    // Start is called before the first frame update
    protected virtual void Start()
    {
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
                Damage = ReferencesManager.TowerManager.DamageTowerStat.Damage;
                FireRate = ReferencesManager.TowerManager.DamageTowerStat.FireRate;
                Range = ReferencesManager.TowerManager.DamageTowerStat.Range;
                Cost = ReferencesManager.TowerManager.DamageTowerStat.Cost;
                break;
            case TowerEnum.FreezeTower:
                Damage = ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.Damage;
                FireRate = ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.FireRate;
                Range = ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.Range;
                Cost = ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.Cost;
                break;
            case TowerEnum.PoisonTower:
                Damage = ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.Damage;
                FireRate = ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.FireRate;
                Range = ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.Range;
                Cost = ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.Cost;
                break;
            case TowerEnum.BombTower:
                Damage = ReferencesManager.TowerManager.BombTowerStat.TowerStats.Damage;
                FireRate = ReferencesManager.TowerManager.BombTowerStat.TowerStats.FireRate;
                Range = ReferencesManager.TowerManager.BombTowerStat.TowerStats.Range;
                Cost = ReferencesManager.TowerManager.BombTowerStat.TowerStats.Cost;
                break;
        }
    }
}
