using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : Tower
{
    public GameObject projectileBomb;

    public int SplashDamage;
    public float SplashRadius;

    public int DoubleExplosionChance;

    public int RocketChance;
    public int RocketDamage;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.BombTower);
        AssignStats();
        SetStats(ReferencesManager.StatsManager.BombTowerStats);

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

    public override IEnumerator Shoot(GameObject projectile, int damage)
    {
        while (true)
        {
            if (EnemiesInRange.Count > 0)
            {
                GameObject bullet = Instantiate(projectile, Barrel.position, Barrel.rotation);
                bullet.GetComponent<TowerProjectile>().target = EnemiesInRange[0].gameObject;
                bullet.GetComponent<TowerProjectile>().Damage = damage;
                bullet.GetComponent<TowerProjectile>().FromTower = this.gameObject.name;
                bullet.GetComponent<BombTowerProjectile>().splashDamage = SplashDamage;
                bullet.GetComponent<BombTowerProjectile>().splashRadius = SplashRadius;
                yield return new WaitForSeconds(FireRate);
            }
            yield return null;
        }
    }
}
