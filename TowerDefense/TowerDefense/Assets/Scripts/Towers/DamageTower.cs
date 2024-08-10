using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageTower : Tower
{
    public GameObject ProjectileDamage;
    public int ProjectileCount = 1;
    public int CriticalChance = 0;
    public int TwoRoundBurstChance = 0;
    public int ThreeRoundBurstChance = 0;

    public List<Transform> Barrels = new List<Transform>();

    public GameObject BarrelToAdd;

    public Vector3 WhenTwoBarrels = new Vector3(-0.108f, 0.316f, 2.72f);

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

        StartCoroutine(Shoot(ProjectileDamage, Damage));
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
        Destroy(Barrel.transform.parent.gameObject);
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
    }

    public override IEnumerator Shoot(GameObject projectile, int damage)
    {
        while (true)
        {
            if (ProjectileCount > 1)
            {
                for (int i = 0; i < ProjectileCount; i++)
                {
                    GameObject bullet = Instantiate(projectile, Barrels[i].position, Barrels[i].rotation);
                    bullet.GetComponent<TowerProjectile>().Damage = damage;
                }
                yield return new WaitForSeconds(FireRate);
            }
            else
            {
                GameObject bullet = Instantiate(projectile, Barrel.position, Barrel.rotation);
                bullet.GetComponent<TowerProjectile>().Damage = damage;
                yield return new WaitForSeconds(FireRate);
            }
        }
    }
}
