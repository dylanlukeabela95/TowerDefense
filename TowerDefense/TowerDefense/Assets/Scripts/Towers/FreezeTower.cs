using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTower : Tower
{
    public GameObject projectileFreeze;

    public List<string> Stats = new List<string>();

    public int IceDamage;
    public float SlowDuration;
    public float SlowEffect;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.FreezeTower);
        AssignStats();
        Stats = ReferencesManager.StatsManager.FreezeTowerStats;

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
        Stats = new List<string>();

        foreach (var statItem in ReferencesManager.StatsManager.FreezeTowerStats)
        {
            Stats.Add(statItem);
        }

        Stats.Add(stat);
    }
}
