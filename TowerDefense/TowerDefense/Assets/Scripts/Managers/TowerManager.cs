using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public TowerStat DamageTowerStat;
    public FreezeTowerStat FreezeTowerStat;
    public PoisonTowerStat PoisonTowerStat;
    public BombTowerStat BombTowerStat;

    [Header("Towers")]
    public GameObject DamageTower;
    public GameObject FreezeTower;
    public GameObject PoisonTower;
    public GameObject BombTower;

    // Start is called before the first frame update
    void Start()
    {
        AssignStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AssignStats()
    {
        AssignDamageTowerStats();
        AssignFreezeTowerStats();
        AssignPoisonTowerStats();
        AssignBombTowerStats();
    }

    void AssignDamageTowerStats()
    {
        DamageTowerStat = new TowerStat()
        {
            Damage = 10,
            FireRate = 0.75f,
            Range = 4,
            Cost = 20
        };
    }

    void AssignFreezeTowerStats()
    {
        FreezeTowerStat = new FreezeTowerStat()
        {
            TowerStats = new TowerStat()
            {
                Damage = 5,
                FireRate = 1,
                Range = 6,
                Cost = 30
            },
            FreezeDamage = 5, 
            FreezeDuration = 3, 
            FreezeSlowEffect = 20 //20% slow
        };
    }

    void AssignPoisonTowerStats()
    {
        PoisonTowerStat = new PoisonTowerStat()
        {
            TowerStats = new TowerStat()
            {
                Damage = 1,
                FireRate = 1.2f,
                Range = 4,
                Cost = 35
            },
            PoisonDamageOverTime = 4,
            PoisonDuration = 5,
            PoisonTickRate = 0.8f
        };
    }

    void AssignBombTowerStats()
    {
        BombTowerStat = new BombTowerStat()
        {
            TowerStats = new TowerStat()
            {
                Damage = 10,
                FireRate = 1.5f,
                Range = 10,
                Cost = 60
            },
            SplashDamage = 5,
            SplashRadius = 3
        };
    }

    public void PlaceTower()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(DamageTower, mousePosition, Quaternion.identity);
    }
}
