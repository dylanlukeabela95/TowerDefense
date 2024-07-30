using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTower : Tower
{
    public GameObject projectilePoison;

    public List<string> Stats = new List<string>();

    public int PoisonDamageOverTime;
    public float PoisonDuration;
    public float PoisonTickRate;
    public bool PoisonSpread;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.PoisonTower);
        AssignStats();
        foreach (var item in ReferencesManager.StatsManager.PoisonTowerStats)
        {
            Stats.Add(item);
        }

        TowerEnum = TowerEnum.PoisonTower;

        StartCoroutine(Shoot(projectilePoison, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void AssignStats()
    {
        PoisonDamageOverTime = (int)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.PoisonDamageOverTime];
        PoisonDuration = (float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.PoisonDuration];
        PoisonTickRate = (float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.PoisonTickRate];
    }

    public void AddStat(string stat)
    {
        Stats.Add(stat);
    }
}
