using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageTower : Tower
{
    public GameObject ProjectileDamage;
    public int ProjectileCount = 1;

    public int CriticalDamage;
    public int CriticalPercentage;

    public int SuperDamage;
    public int SuperDamageChance;

    public int TwoRoundBurstChance = 0;
    public int ThreeRoundBurstChance = 0;
    public float BurstFireRate = 0.1f;

    public int BurnChance;
    public int BurnDamage;
    public float BurnDuration;
    public float BurnTickRate;

    public List<Transform> Barrels = new List<Transform>();

    public GameObject BarrelToAdd;

    public Vector3 WhenTwoBarrels = new Vector3(-0.108f, 0.316f, 2.72f);
    public Vector3 WhenThreeBarrels = new Vector3(-0.168f, 0.316f, 2.72f);

    bool canTwoRoundBurst;
    bool canThreeRoundBurst;

    public int MarkChance;

    void Awake()
    {

    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        AssignStats(TowerEnum.DamageTower);
        SetStats(ReferencesManager.StatsManager.DamageTowerStats);

        TowerEnum = TowerEnum.DamageTower;

        StartCoroutine(Shoot(ProjectileDamage));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void AddStat(string stat)
    {
        Stats.Add(stat);
    }

    public string GetStat(int pos)
    {
        return Stats[pos];
    }

    public List<string> GetStats()
    {
        return Stats;
    }

    public void AddBarrel()
    {
        if(Barrels.Count == 0) 
        {
            Destroy(Barrel.transform.parent.gameObject);
        }
        else
        {
            foreach(var barrel in Barrels)
            {
                Destroy(barrel.gameObject);
            }
        }
        Barrels = new List<Transform>();

        if (ProjectileCount == 2)
        {
            GameObject barrel = Instantiate(BarrelToAdd, transform.position, Quaternion.identity, this.gameObject.transform);
            barrel.transform.localPosition = WhenTwoBarrels;
            barrel.name = "Barrel";
            Barrels.Add(barrel.transform);

            GameObject barrel2 = Instantiate(BarrelToAdd, transform.position, Quaternion.identity, this.gameObject.transform);
            barrel2.transform.localPosition = new Vector3(-WhenTwoBarrels.x, WhenTwoBarrels.y, WhenTwoBarrels.z);
            barrel2.name = "Barrel";
            Barrels.Add(barrel2.transform);
        }
        else if(ProjectileCount == 3)
        {
            GameObject barrel = Instantiate(BarrelToAdd, transform.position, Quaternion.identity, this.gameObject.transform);
            barrel.transform.localPosition = new Vector3(0, WhenThreeBarrels.y, WhenThreeBarrels.z);
            barrel.name = "Barrel";
            Barrels.Add(barrel.transform);

            GameObject barrel2 = Instantiate(BarrelToAdd, transform.position, Quaternion.identity, this.gameObject.transform);
            barrel2.transform.localPosition = new Vector3(-WhenThreeBarrels.x, WhenThreeBarrels.y, WhenThreeBarrels.z);
            barrel2.name = "Barrel";
            Barrels.Add(barrel2.transform);

            GameObject barrel3 = Instantiate(BarrelToAdd, transform.position, Quaternion.identity, this.gameObject.transform);
            barrel3.transform.localPosition = WhenThreeBarrels;
            barrel3.name = "Barrel";
            Barrels.Add(barrel3.transform);
        }
    }

    public bool ShootInBurst(int burstChance)
    {
        var random = Random.Range(0, 100);

        if(burstChance != 0 && random <= burstChance)
        {
            return true;
        }

        return false;
    }

    public void ShootProjectile(GameObject projectile)
    {
        var randomCritical = -1;
        var randomSuper = -1;

        if (CriticalChance > 0)
        {
            randomCritical = Random.Range(0, 101);
        }

        if (SuperDamageChance > 0)
        {
            randomCritical = Random.Range(0, 101);
        }

        if (ProjectileCount > 1)
        {
            for (int i = 0; i < ProjectileCount; i++)
            {
                GameObject bullet = Instantiate(projectile, Barrels[i].position, Barrels[i].rotation);
                bullet.GetComponent<TowerProjectile>().target = EnemiesInRange[0].gameObject;
                bullet.GetComponent<TowerProjectile>().FromTower = this.gameObject.name;

                if (randomCritical != -1 && randomCritical <= CriticalChance)
                {
                    bullet.GetComponent<TowerProjectile>().isCritical = true;
                    bullet.GetComponent<TowerProjectile>().CriticalDamage = CriticalDamage;
                }
                else
                {
                    bullet.GetComponent<TowerProjectile>().Damage = Damage;
                }
            }
        }
        else
        {
            GameObject bullet = Instantiate(projectile, Barrel.position, Barrel.rotation);
            bullet.GetComponent<TowerProjectile>().target = EnemiesInRange[0].gameObject;
            bullet.GetComponent<TowerProjectile>().FromTower = this.gameObject.name;

            if (randomCritical != -1 && randomCritical <= CriticalChance)
            {
                bullet.GetComponent<TowerProjectile>().isCritical = true;
                bullet.GetComponent<TowerProjectile>().CriticalDamage = CriticalDamage;
            }
            else
            {
                bullet.GetComponent<TowerProjectile>().Damage = Damage;
            }
        }
    }

    public override IEnumerator Shoot(GameObject projectile)
    {
        while (true)
        {
            if (EnemiesInRange.Count > 0)
            {
                canTwoRoundBurst = ShootInBurst(TwoRoundBurstChance);
                canThreeRoundBurst = ShootInBurst(ThreeRoundBurstChance);

                if (
                    (canTwoRoundBurst && canThreeRoundBurst) ||
                    (!canTwoRoundBurst && canThreeRoundBurst)
                  )
                {
                    //Do three round burst
                    for (int i = 0; i < 3; i++)
                    {
                        ShootProjectile(projectile);
                        yield return new WaitForSeconds(BurstFireRate);
                    }
                    yield return new WaitForSeconds(FireRate);

                }
                else if (canTwoRoundBurst && !canThreeRoundBurst)
                {
                    //Do two round burst
                    for (int i = 0; i < 2; i++)
                    {
                        ShootProjectile(projectile);
                        yield return new WaitForSeconds(BurstFireRate);
                    }
                    yield return new WaitForSeconds(FireRate);
                }
                else if (!canTwoRoundBurst && !canThreeRoundBurst)
                {
                    //Shoot normally
                    ShootProjectile(projectile);
                    yield return new WaitForSeconds(FireRate);
                }
            }
            yield return null;
        }
    }
}
