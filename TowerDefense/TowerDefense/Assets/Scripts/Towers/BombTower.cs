using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : Tower
{
    public GameObject projectileBomb;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.BombTower);

        StartCoroutine(Shoot(projectileBomb, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
