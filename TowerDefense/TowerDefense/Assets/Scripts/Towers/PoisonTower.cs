using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTower : Tower
{
    public GameObject projectilePoison;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.PoisonTower);

        StartCoroutine(Shoot(projectilePoison, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
