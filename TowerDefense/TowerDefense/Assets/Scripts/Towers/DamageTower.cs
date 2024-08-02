using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageTower : Tower
{
    public GameObject ProjectileDamage;
    public int ProjectileCount = 1;
    public int CriticalChance = 0;
    public int TwoRoundBurstChance = 0;
    public int ThreeRoundBurstChance = 0;

    void Awake()
    {
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.DamageTower);
        SetStats(ReferencesManager.StatsManager.DamageTowerStats);

        TowerEnum = TowerEnum.DamageTower;

        StartCoroutine(Shoot(ProjectileDamage, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void AddStat(string stat)
    {
        Stats.Add(stat);
    }

    public string GetStat(int pos)
    {
        return Stats[pos];
    }

    public List<string> GetStats()
    {
        return Stats;
    }
}
