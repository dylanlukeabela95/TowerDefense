using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTower : Tower
{
    public GameObject projectileFreeze;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.FreezeTower);

        StartCoroutine(Shoot(projectileFreeze, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
