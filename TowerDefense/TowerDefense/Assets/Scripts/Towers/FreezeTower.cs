using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTower : Tower
{
    public GameObject projectileFreeze;

    public int IceDamage;
    public float SlowDuration;
    public float SlowEffect;

    public bool CanFrostbite;
    public int FrostbiteDamage;
    public float FrostbiteTickRate;

    public bool CanIcicle;
    public int IcicleDamage;
    public int IcicleChance;

    public bool CanImmobilize;
    public int ImmobilizeChance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.FreezeTower);
        AssignStats();
        SetStats(ReferencesManager.StatsManager.FreezeTowerStats);

        TowerEnum = TowerEnum.FreezeTower;

        StartCoroutine(Shoot(projectileFreeze, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void AssignStats()
    {
        IceDamage = (int)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.IceDamage];
        SlowDuration = (float)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.SlowDuration];
        SlowEffect = (float)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.SlowEffect];
    }

    public void AddStat(string stat)
    {
        Stats.Add(stat);
    }

    public void RemoveStat(string stat)
    {
        Stats.Remove(stat);
    }
}
