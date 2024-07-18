using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public Dictionary<string, object> DamageStats = new Dictionary<string, object>();
    public Dictionary<string, object> FreezeStats = new Dictionary<string, object>();
    public Dictionary<string, object> PoisonStats = new Dictionary<string, object>();
    public Dictionary<string, object> BombStats = new Dictionary<string, object>();

    [Header("Towers")]
    public GameObject DamageTower;
    public GameObject FreezeTower;
    public GameObject PoisonTower;
    public GameObject BombTower;

    [Header("Towers For Drag")]
    public GameObject DamageTower_Drag;
    public GameObject FreezeTower_Drag;
    public GameObject PoisonTower_Drag;
    public GameObject BombTower_Drag;

    [Header("Range Indicator")]
    public Color UnavailableSpot;
    public Color AvailableSpot;

    GameObject DraggedTower;
    public bool IsTowerSelect;

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
        AssignStats();
    }

    // Update is called once per frame
    void Update()
    {
        DragTower();
    }

    void AssignStats()
    {
        AssignDamageTowerStats();
        AssignFreezeTowerStats();
        AssignPoisonTowerStats();
        AssignBombTowerStats();
    }

    void AssignDamageTowerStats()
    {
        DamageStats.Add(StringsDatabase.Stats.Damage, 10);
        DamageStats.Add(StringsDatabase.Stats.FireRate, 0.75f);
        DamageStats.Add(StringsDatabase.Stats.Range, 4f);
        DamageStats.Add(StringsDatabase.Stats.Cost, 20);
    }

    void AssignFreezeTowerStats()
    {
        FreezeStats.Add(StringsDatabase.Stats.Damage, 5);
        FreezeStats.Add(StringsDatabase.Stats.FireRate, 1f);
        FreezeStats.Add(StringsDatabase.Stats.Range, 6f);
        FreezeStats.Add(StringsDatabase.Stats.Cost, 30);
        FreezeStats.Add(StringsDatabase.Stats.IceDamage, 5);
        FreezeStats.Add(StringsDatabase.Stats.SlowDuration, 3f);
        FreezeStats.Add(StringsDatabase.Stats.SlowEffect, 20f);
    }

    void AssignPoisonTowerStats()
    {
        PoisonStats.Add(StringsDatabase.Stats.Damage, 1);
        PoisonStats.Add(StringsDatabase.Stats.FireRate, 1.2f);
        PoisonStats.Add(StringsDatabase.Stats.Range, 4f);
        PoisonStats.Add(StringsDatabase.Stats.Cost, 35);
        PoisonStats.Add(StringsDatabase.Stats.PoisonDamageOverTime, 4);
        PoisonStats.Add(StringsDatabase.Stats.PoisonDuration, 5f);
        PoisonStats.Add(StringsDatabase.Stats.PoisonTickRate, 0.8f);
    }

    void AssignBombTowerStats()
    {
        BombStats.Add(StringsDatabase.Stats.Damage, 10);
        BombStats.Add(StringsDatabase.Stats.FireRate, 1.5f);
        BombStats.Add(StringsDatabase.Stats.Range, 10f);
        BombStats.Add(StringsDatabase.Stats.Cost, 60);
        BombStats.Add(StringsDatabase.Stats.SplashDamage, 5);
        BombStats.Add(StringsDatabase.Stats.SplashRadius, 3f);
    }

    void ShowHideDragTowers(bool damageTower, bool freezeTower, bool poisonTower, bool bombTower)
    {
        DamageTower_Drag.SetActive(damageTower);
        FreezeTower_Drag.SetActive(freezeTower);
        PoisonTower_Drag.SetActive(poisonTower);
        BombTower_Drag.SetActive(bombTower);
    }

    void SetRangeIndicator(float towerRange, GameObject tower = null)
    {
        if (tower != null)
        {
            var rangeIndicator = tower.transform.Find(StringsDatabase.Towers.RangeIndicator);
            rangeIndicator.localScale = new Vector3(towerRange, towerRange, 1);
            rangeIndicator.GetComponent<SpriteRenderer>().color = AvailableSpot;
        }
        else if(DraggedTower != null)
        {
            var rangeIndicator = DraggedTower.transform.Find(StringsDatabase.Towers.RangeIndicator);
            rangeIndicator.localScale = new Vector3(towerRange, towerRange, 1);
            rangeIndicator.GetComponent<SpriteRenderer>().color = AvailableSpot;
        }
    }

    void DragTower()
    {
        if (IsTowerSelect)
        {
            if (DraggedTower == null)
            {
                var gameManager = ReferencesManager.GameManager;
                var towerManager = ReferencesManager.TowerManager;

                if (gameManager.CheckIfTowerSelected())
                {
                    if (gameManager.isDamageTowerSelected)
                    {
                        ShowHideDragTowers(true, false, false, false);
                        DraggedTower = DamageTower_Drag;
                        SetRangeIndicator((float)towerManager.DamageStats[StringsDatabase.Stats.Range]);
                    }
                    else if (gameManager.isFreezeTowerSelected)
                    {
                        ShowHideDragTowers(false, true, false, false);
                        DraggedTower = FreezeTower_Drag;
                        SetRangeIndicator((float)towerManager.FreezeStats[StringsDatabase.Stats.Range]);
                    }
                    else if (gameManager.isPoisonTowerSelected)
                    {
                        ShowHideDragTowers(false, false, true, false);
                        DraggedTower = PoisonTower_Drag;
                        SetRangeIndicator((float)towerManager.PoisonStats[StringsDatabase.Stats.Range]);
                    }
                    else if (gameManager.isBombTowerSelected)
                    {
                        ShowHideDragTowers(false, false, false, true);
                        DraggedTower = BombTower_Drag;
                        SetRangeIndicator((float)towerManager.BombStats[StringsDatabase.Stats.Range]);
                    }
                }
            }
            else
            {
                DraggedTower.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                DamageTower_Drag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                FreezeTower_Drag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PoisonTower_Drag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                BombTower_Drag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            DamageTower_Drag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FreezeTower_Drag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PoisonTower_Drag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BombTower_Drag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void EmptyDraggedTower()
    {
        DraggedTower = null;
    }

    public void HideAllDraggedTowers()
    {
        ShowHideDragTowers(false, false, false, false);
        IsTowerSelect = false;
    }

    public void PlaceTower()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7.9f));
        var gameManager = ReferencesManager.GameManager;

        GameObject tower = null;

        if (
            (DamageTower_Drag.activeInHierarchy && DamageTower_Drag.GetComponent<TowerDrag>().CanPlace) ||
            (FreezeTower_Drag.activeInHierarchy && FreezeTower_Drag.GetComponent<TowerDrag>().CanPlace) ||
            (PoisonTower_Drag.activeInHierarchy && PoisonTower_Drag.GetComponent<TowerDrag>().CanPlace) ||
            (BombTower_Drag.activeInHierarchy && BombTower_Drag.GetComponent<TowerDrag>().CanPlace)
           )
        {
            if (gameManager.isDamageTowerSelected)
            {
                if (ReferencesManager.GameManager.CanPurchase((int)ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Cost]))
                {
                    tower = Instantiate(DamageTower, mousePosition, Quaternion.identity);
                    ReferencesManager.GameManager.ReduceCoins((int)ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Cost]);
                    ReferencesManager.UIManager_Cost.UpdateCoins();
                    SetRangeIndicator((float)ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Range], tower);
                    ReferencesManager.GameManager.AddTowerToList(tower);
                }
            }
            else if (gameManager.isFreezeTowerSelected)
            {
                if (ReferencesManager.GameManager.CanPurchase((int)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Cost]))
                {
                    tower = Instantiate(FreezeTower, mousePosition, Quaternion.identity);
                    ReferencesManager.GameManager.ReduceCoins((int)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Cost]);
                    ReferencesManager.UIManager_Cost.UpdateCoins();
                    SetRangeIndicator((float)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Range], tower);
                    ReferencesManager.GameManager.AddTowerToList(tower);
                }
            }
            else if (gameManager.isPoisonTowerSelected)
            {
                if (ReferencesManager.GameManager.CanPurchase((int)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.Cost]))
                {
                    tower = Instantiate(PoisonTower, mousePosition, Quaternion.identity);
                    ReferencesManager.GameManager.ReduceCoins((int)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.Cost]);
                    ReferencesManager.UIManager_Cost.UpdateCoins();
                    SetRangeIndicator((float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.Range], tower);
                    ReferencesManager.GameManager.AddTowerToList(tower);
                }
            }
            else if (gameManager.isBombTowerSelected)
            {
                if (ReferencesManager.GameManager.CanPurchase((int)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.Cost]))
                {
                    tower = Instantiate(BombTower, mousePosition, Quaternion.identity);
                    ReferencesManager.GameManager.ReduceCoins((int)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.Cost]);
                    ReferencesManager.UIManager_Cost.UpdateCoins();
                    SetRangeIndicator((float)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.Range], tower);
                    ReferencesManager.GameManager.AddTowerToList(tower);
                }
            }
        }
    }
}
