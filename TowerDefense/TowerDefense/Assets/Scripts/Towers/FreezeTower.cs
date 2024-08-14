using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTower : Tower
{
    public GameObject projectileFreeze;

    public int IceDamage;
    public float SlowDuration;
    public float SlowEffect;

    public bool CanFrostbite;
    public int FrostbiteDamage;
    public float FrostbiteTickRate;

    public bool CanIcicle;
    public int IcicleDamage;
    public int IcicleChance;

    public bool CanImmobilize;
    public int ImmobilizeChance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.FreezeTower);
        AssignStats();
        SetStats(ReferencesManager.StatsManager.FreezeTowerStats);

        TowerEnum = TowerEnum.FreezeTower;

        StartCoroutine(Shoot(projectileFreeze, Damage));
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

    public void AddStat(string stat)
    {
        Stats.Add(stat);
    }

    public void RemoveStat(string stat)
    {
        Stats.Remove(stat);
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
                bullet.GetComponent<FreezeTowerProjectile>().IceDamage = IceDamage;
                bullet.GetComponent<TowerProjectile>().FromTower = this.gameObject.name;
                yield return new WaitForSeconds(FireRate);
            }
            yield return null;
        }
    }
}
