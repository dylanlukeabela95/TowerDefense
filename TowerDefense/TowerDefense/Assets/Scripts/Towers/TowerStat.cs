using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStat
{
    public int Damage { get; set; }
    public float FireRate { get; set; }
    public float Range { get; set; }
    public int Cost { get; set; }

    public TowerStat()
    {
        
    }
}

public class PoisonTowerStat
{
    public TowerStat TowerStats { get; set; }
    public int PoisonDamageOverTime { get; set; }
    public float PoisonDuration { get; set; }
    public float PoisonTickRate { get; set; }

    public PoisonTowerStat()
    {
        
    }
}

public class FreezeTowerStat
{
    public TowerStat TowerStats { get; set; }
    public int FreezeDamage { get; set; }
    public float FreezeDuration { get; set; }
    public float FreezeSlowEffect {  get; set; } // % effect

    public FreezeTowerStat()
    {
        
    }
}

public class BombTowerStat
{
    public TowerStat TowerStats { get; set; }
    public int SplashDamage { get; set; }
    public float SplashRadius { get; set; }

    public BombTowerStat()
    {
        
    }
}
