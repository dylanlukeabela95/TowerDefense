using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTower : Tower
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.DamageTower);

        StartCoroutine(Shoot(projectileDamage, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
