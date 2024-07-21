using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTower : Tower
{
    public GameObject ProjectileDamage;
    public int ProjectileCount = 1;
    public int CriticalChance = 0;
    public int TwoRoundBurstChance = 0;
    public int ThreeRoundBurstChance = 0;

    public List<string> Stats = new List<string>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.DamageTower);
        Stats = ReferencesManager.StatsManager.DamageTowerStats;

        TowerEnum = TowerEnum.DamageTower;

        StartCoroutine(Shoot(ProjectileDamage, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
