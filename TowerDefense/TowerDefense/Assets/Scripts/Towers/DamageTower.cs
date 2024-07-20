using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTower : Tower
{
    public GameObject projectileDamage;

    public List<string> Stats = new List<string>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.DamageTower);
        Stats = ReferencesManager.StatsManager.DamageTowerStats;

        TowerEnum = TowerEnum.DamageTower;

        StartCoroutine(Shoot(projectileDamage, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
