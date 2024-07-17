using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public int Damage;
    public float FireRate;
    public float Range;
    public int Cost;

    public Transform Barrel;

    public GameObject RangeIndicator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
        RangeIndicator.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void AssignStats(TowerEnum towerEnum)
    {
        switch(towerEnum)
        {
            case TowerEnum.DamageTower:
                Damage = ReferencesManager.TowerManager.DamageTowerStat.Damage;
                FireRate = ReferencesManager.TowerManager.DamageTowerStat.FireRate;
                Range = ReferencesManager.TowerManager.DamageTowerStat.Range;
                Cost = ReferencesManager.TowerManager.DamageTowerStat.Cost;
                break;
            case TowerEnum.FreezeTower:
                Damage = ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.Damage;
                FireRate = ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.FireRate;
                Range = ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.Range;
                Cost = ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.Cost;
                break;
            case TowerEnum.PoisonTower:
                Damage = ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.Damage;
                FireRate = ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.FireRate;
                Range = ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.Range;
                Cost = ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.Cost;
                break;
            case TowerEnum.BombTower:
                Damage = ReferencesManager.TowerManager.BombTowerStat.TowerStats.Damage;
                FireRate = ReferencesManager.TowerManager.BombTowerStat.TowerStats.FireRate;
                Range = ReferencesManager.TowerManager.BombTowerStat.TowerStats.Range;
                Cost = ReferencesManager.TowerManager.BombTowerStat.TowerStats.Cost;
                break;
        }
    }

    protected virtual void OnMouseDown()
    {
        if (ReferencesManager.GameManager.tower == this.gameObject)
        {
            RangeIndicator.SetActive(false);
            ReferencesManager.GameManager.tower = null;
        }
        else if(ReferencesManager.GameManager.tower == null)
        {
            ReferencesManager.GameManager.tower = this.gameObject;
            RangeIndicator.SetActive(true);
            //Debug.Log("Damage -> "+ Damage);
            //Debug.Log("Fire Rate -> "+ FireRate);
            //Debug.Log("Range -> "+ Range);
        }
    }

    public IEnumerator Shoot(GameObject projectile, int damage)
    {
        while(true)
        {
            GameObject bullet = Instantiate(projectile, Barrel.transform.position, Barrel.transform.rotation);
            bullet.GetComponent<TowerProjectile>().Damage = damage;
            yield return new WaitForSeconds(FireRate);
        }
    }

}
