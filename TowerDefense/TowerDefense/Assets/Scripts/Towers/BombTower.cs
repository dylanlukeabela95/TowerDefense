using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : Tower
{
    public GameObject projectileBomb;

    public List<string> Stats = new List<string>();

    public int SplashDamage;
    public float SplashRadius;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.BombTower);
        AssignStats();
        foreach (var item in ReferencesManager.StatsManager.BombTowerStats)
        {
            Stats.Add(item);
        }

        TowerEnum = TowerEnum.BombTower;

        StartCoroutine(Shoot(projectileBomb, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void AssignStats()
    {
        SplashDamage = (int)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.SplashDamage];
        SplashRadius = (float)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.SplashRadius];
    }

    public void AddStat(string stat)
    {
        Stats.Add(stat);
    }
}
