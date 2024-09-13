using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTower : Tower
{
    public GameObject projectileFreeze;

    [Header("Stats")]
    public int IceDamage;
    public float SlowDuration;
    public float SlowEffect;

    [Header("Frostbite")]
    public bool CanFrostbite;
    public int FrostbiteDamage;
    public float FrostbiteTickRate;

    [Header("Icicle")]
    public bool CanIcicle;
    public GameObject Icicle;
    public int IcicleDamage;
    public int IcicleChance;

    [Header("Immobilize")]
    public bool CanImmobilize;
    public int ImmobilizeChance;

    [Header("Snowball")]
    public GameObject Snowball;
    public int SnowballDamage;
    public int SnowballChance;
    public float SnowballStunDuration;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.FreezeTower);
        AssignStats();
        SetStats(ReferencesManager.StatsManager.FreezeTowerStats);

        TowerEnum = TowerEnum.FreezeTower;

        StartCoroutine(Shoot(projectileFreeze));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void AssignStats()
    {
        IceDamage = (int)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.IceDamage];
        SlowDuration = (float)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.SlowDuration];
        SlowEffect = (float)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.SlowEffect];
    }

    public override IEnumerator Shoot(GameObject projectile)
    {
        GameObject icicle = null;
        while (true)
        {
            if (EnemiesInRange.Count > 0)
            {
                GameObject bullet = Instantiate(projectile, Barrel.position, Barrel.rotation);
                bullet.GetComponent<TowerProjectile>().ReferencesManager = ReferencesManager;
                bullet.GetComponent<TowerProjectile>().target = EnemiesInRange[0].gameObject;
                bullet.GetComponent<TowerProjectile>().Damage = Damage;
                bullet.GetComponent<FreezeTowerProjectile>().IceDamage = IceDamage;
                bullet.GetComponent<FreezeTowerProjectile>().SlowDuration = SlowDuration;
                bullet.GetComponent<FreezeTowerProjectile>().SlowEffect = SlowEffect;
                bullet.GetComponent<TowerProjectile>().FromTower = this.gameObject.name;

                if (CanIcicle)
                {
                    var random = Random.Range(0, 101);
                    if (random <= IcicleChance)
                    {
                        icicle = Instantiate(Icicle, transform.position, Quaternion.identity);
                        icicle.GetComponent<Icicle>().icicleDamage = IcicleDamage;
                        icicle.GetComponent<Icicle>().slowDuration = SlowDuration;
                        icicle.GetComponent<Icicle>().slowEffect = SlowEffect;

                        if(CanFrostbite)
                        {
                            icicle.GetComponent<Icicle>().frostbiteDamage = FrostbiteDamage;
                            icicle.GetComponent<Icicle>().frostbiteTickRate = FrostbiteTickRate;
                        }
                    }
                }

                if (CanFrostbite)
                {
                    bullet.GetComponent<FreezeTowerProjectile>().canFrostbite = true;
                    bullet.GetComponent<FreezeTowerProjectile>().frostbiteDamageOverTime = FrostbiteDamage;
                    bullet.GetComponent<FreezeTowerProjectile>().frostbiteTickRate = FrostbiteTickRate;
                }

                if(CanImmobilize)
                {
                    bullet.GetComponent<FreezeTowerProjectile>().canImmobilize = true;
                    bullet.GetComponent<FreezeTowerProjectile>().immobilizeChance = ImmobilizeChance;
                }

                if(SnowballChance > 0)
                {
                    if(Random.Range(0,101) <= SnowballChance)
                    {
                        GameObject snowball = Instantiate(Snowball, transform.position, Quaternion.identity);
                        snowball.GetComponent<Snowball>().ReferencesManager = ReferencesManager;
                        snowball.GetComponent<Snowball>().snowballDamage = SnowballDamage;
                        snowball.GetComponent<Snowball>().stunDuration = SnowballStunDuration;
                    }
                }

                yield return new WaitForSeconds(FireRate);
            }
            yield return null;
        }
    }
}
