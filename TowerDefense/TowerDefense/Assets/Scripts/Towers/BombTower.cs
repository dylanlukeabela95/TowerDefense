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

    public GameObject Rocket;
    public int RocketChance;
    public int RocketDamage;

    public int ExplosionDelay;

    public int NukeChance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.BombTower);
        AssignStats();
        SetStats(ReferencesManager.StatsManager.BombTowerStats);

        TowerEnum = TowerEnum.BombTower;

        StartCoroutine(Shoot(projectileBomb));
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

    public override IEnumerator Shoot(GameObject projectile)
    {
        while (true)
        {
            if (EnemiesInRange.Count > 0)
            {
                GameObject bullet = Instantiate(projectile, Barrel.position, Barrel.rotation);
                bullet.GetComponent<TowerProjectile>().ReferencesManager = ReferencesManager;
                bullet.GetComponent<TowerProjectile>().target = EnemiesInRange[0].gameObject;
                bullet.GetComponent<TowerProjectile>().Damage = Damage;
                bullet.GetComponent<TowerProjectile>().FromTower = this.gameObject.name;
                bullet.GetComponent<BombTowerProjectile>().splashDamage = SplashDamage;
                bullet.GetComponent<BombTowerProjectile>().splashRadius = SplashRadius;

                if(DoubleExplosionChance != 0)
                {
                    bullet.GetComponent<BombTowerProjectile>().canDoubleExplosion = true;
                    bullet.GetComponent<BombTowerProjectile>().doubleExplosionChance = DoubleExplosionChance;
                }

                if(RocketChance != 0)
                {
                    var random = Random.Range(0, 101);
                    if (random <= RocketChance)
                    {
                        GameObject rocket = Instantiate(Rocket, transform.position, Quaternion.identity);
                        rocket.GetComponent<Rocket>().rocketDamage = RocketDamage;
                        rocket.GetComponent<Rocket>().splashDamage = SplashDamage;
                        rocket.GetComponent<Rocket>().splashRadius = SplashRadius;

                        if(DoubleExplosionChance != 0)
                        {
                            rocket.GetComponent<Rocket>().canDoubleExplosion = true;
                            rocket.GetComponent<Rocket>().doubleExplosionChance = DoubleExplosionChance;
                        }
                    }
                }

                if(ExplosionDelay > 0)
                {
                    bullet.GetComponent<BombTowerProjectile>().explosionDelay = ExplosionDelay;
                }

                if(NukeChance > 0)
                {
                    bullet.GetComponent<BombTowerProjectile>().nukeChance = NukeChance;
                }

                yield return new WaitForSeconds(FireRate);
            }
            yield return null;
        }
    }
}
