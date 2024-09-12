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

    public bool CanPoisonCrit_Node;
    public Dictionary<string, bool> CanPoisonCrit_Item = new Dictionary<string, bool>();

    public int DoublePoisonTickRateChance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        AssignDictionary();
        AssignStats(TowerEnum.PoisonTower);
        AssignStats();
        SetStats(ReferencesManager.StatsManager.PoisonTowerStats);

        TowerEnum = TowerEnum.PoisonTower;

        StartCoroutine(Shoot(projectilePoison));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void AssignDictionary()
    {
        CanPoisonCrit_Item.Add("Fungus 1", false);
        CanPoisonCrit_Item.Add("Fungus 2", false);
        CanPoisonCrit_Item.Add("Fungus 3", false);
        CanPoisonCrit_Item.Add("Fungus 4", false);
        CanPoisonCrit_Item.Add("Fungus 5", false);
    }

    void AssignStats()
    {
        PoisonDamageOverTime = (int)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.PoisonDamageOverTime];
        PoisonDuration = (float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.PoisonDuration];
        PoisonTickRate = (float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.PoisonTickRate];
    }

    public override void SellTower()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (CanPoisonCrit_Item["Fungus "+i])
            {
                ReferencesManager.GameManager.PoisonCriticalChance -= (int)ReferencesManager.ItemsManager.AllItems.Find(a => a.ItemName == StringsDatabase.Items.Fungus).Changes[0];
            }
        }

        if (CanPoisonCrit_Node)
        {
            ReferencesManager.GameManager.PoisonCriticalChance -= (int)ReferencesManager.UpgradesManager.PoisonTowerPoisonCriticalChance["Level5"];
        }

        if (ReferencesManager.GameManager.PoisonCriticalChance == 0)
        {
            foreach (var poisonTower in ReferencesManager.GameManager.AllTowers.FindAll(a => a.name.Contains("PoisonTower")))
            {
                poisonTower.GetComponent<PoisonTower>().RemoveStat(StringsDatabase.Stats_Display.PoisonCriticalChance);
                poisonTower.GetComponent<PoisonTower>().RemoveStat(StringsDatabase.Stats_Display.PoisonCriticalDamage);
            }
        }
        base.SellTower();
    }

    public override IEnumerator Shoot(GameObject projectile)
    {
        while (true)
        {
            if (EnemiesInRange.Count > 0)
            {
                GameObject bullet = Instantiate(projectile, Barrel.position, Barrel.rotation);
                bullet.GetComponent<TowerProjectile>().target = EnemiesInRange[0].gameObject;
                bullet.GetComponent<TowerProjectile>().Damage = Damage;
                bullet.GetComponent<TowerProjectile>().FromTower = this.gameObject.name;
                bullet.GetComponent<PoisonTowerProjectile>().poisonDamageOverTime = PoisonDamageOverTime;
                bullet.GetComponent<PoisonTowerProjectile>().poisonDuration = PoisonDuration;
                bullet.GetComponent<PoisonTowerProjectile>().poisonTickRate = PoisonTickRate;

                if(PoisonSpread)
                {
                    bullet.GetComponent<PoisonTowerProjectile>().poisonSpread = true;
                    bullet.GetComponent<PoisonTowerProjectile>().poisonSpreadRadius = PoisonSpreadRadius;
                }

                if(DoublePoisonTickRateChance > 0)
                {
                    bullet.GetComponent<PoisonTowerProjectile>().doublePoisonTickRateChance = DoublePoisonTickRateChance;
                }
                yield return new WaitForSeconds(FireRate);
            }
            yield return null;
        }
    }
}
