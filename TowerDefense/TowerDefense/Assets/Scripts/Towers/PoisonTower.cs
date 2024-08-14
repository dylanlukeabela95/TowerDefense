using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTower : Tower
{
    public GameObject projectilePoison;

    public int PoisonDamageOverTime;
    public float PoisonDuration;
    public float PoisonTickRate;
    
    public bool PoisonSpread;
    public float PoisonSpreadRadius;

    public bool CanPoisonCrit;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.PoisonTower);
        AssignStats();
        SetStats(ReferencesManager.StatsManager.PoisonTowerStats);

        TowerEnum = TowerEnum.PoisonTower;

        StartCoroutine(Shoot(projectilePoison, Damage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void AssignStats()
    {
        PoisonDamageOverTime = (int)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.PoisonDamageOverTime];
        PoisonDuration = (float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.PoisonDuration];
        PoisonTickRate = (float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.PoisonTickRate];
    }

    public void AddStat(string stat)
    {
        Stats.Add(stat);
    }

    public override void SellTower()
    {
        if (CanPoisonCrit)
        {
            ReferencesManager.GameManager.PoisonCriticalChance -= (int)ReferencesManager.UpgradesManager.PoisonTowerPoisonCriticalChance["Level5"];
        }
        base.SellTower();
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
                bullet.GetComponent<PoisonTowerProjectile>().poisonDamageOverTime = PoisonDamageOverTime;
                bullet.GetComponent<PoisonTowerProjectile>().poisonDuration = PoisonDuration;
                bullet.GetComponent<PoisonTowerProjectile>().poisonTickRate = PoisonTickRate;
                yield return new WaitForSeconds(FireRate);
            }
            yield return null;
        }
    }
}
