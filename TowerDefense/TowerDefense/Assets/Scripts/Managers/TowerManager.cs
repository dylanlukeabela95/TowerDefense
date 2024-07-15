using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public TowerStat DamageTowerStat;
    public FreezeTowerStat FreezeTowerStat;
    public PoisonTowerStat PoisonTowerStat;
    public BombTowerStat BombTowerStat;

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
        DamageTowerStat = new TowerStat()
        {
            Damage = 10,
            FireRate = 0.75f,
            Range = 4,
            Cost = 20
        };
    }

    void AssignFreezeTowerStats()
    {
        FreezeTowerStat = new FreezeTowerStat()
        {
            TowerStats = new TowerStat()
            {
                Damage = 5,
                FireRate = 1,
                Range = 6,
                Cost = 30
            },
            FreezeDamage = 5, 
            FreezeDuration = 3, 
            FreezeSlowEffect = 20 //20% slow
        };
    }

    void AssignPoisonTowerStats()
    {
        PoisonTowerStat = new PoisonTowerStat()
        {
            TowerStats = new TowerStat()
            {
                Damage = 1,
                FireRate = 1.2f,
                Range = 4,
                Cost = 35
            },
            PoisonDamageOverTime = 4,
            PoisonDuration = 5,
            PoisonTickRate = 0.8f
        };
    }

    void AssignBombTowerStats()
    {
        BombTowerStat = new BombTowerStat()
        {
            TowerStats = new TowerStat()
            {
                Damage = 10,
                FireRate = 1.5f,
                Range = 10,
                Cost = 60
            },
            SplashDamage = 5,
            SplashRadius = 3
        };
    }

    void ShowHideDragTowers(bool damageTower, bool freezeTower, bool poisonTower, bool bombTower)
    {
        DamageTower_Drag.SetActive(damageTower);
        FreezeTower_Drag.SetActive(freezeTower);
        PoisonTower_Drag.SetActive(poisonTower);
        BombTower_Drag.SetActive(bombTower);
    }

    void SetRangeIndicator(float towerRange)
    {
        if(DraggedTower != null)
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
                        SetRangeIndicator(towerManager.DamageTowerStat.Range);
                    }
                    else if (gameManager.isFreezeTowerSelected)
                    {
                        ShowHideDragTowers(false, true, false, false);
                        DraggedTower = FreezeTower_Drag;
                        SetRangeIndicator(towerManager.FreezeTowerStat.TowerStats.Range);
                    }
                    else if (gameManager.isPoisonTowerSelected)
                    {
                        ShowHideDragTowers(false, false, true, false);
                        DraggedTower = PoisonTower_Drag;
                        SetRangeIndicator(towerManager.PoisonTowerStat.TowerStats.Range);
                    }
                    else if (gameManager.isBombTowerSelected)
                    {
                        ShowHideDragTowers(false, false, false, true);
                        DraggedTower = BombTower_Drag;
                        SetRangeIndicator(towerManager.BombTowerStat.TowerStats.Range);
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var gameManager = ReferencesManager.GameManager;

        if (
            (DamageTower_Drag.activeInHierarchy && DamageTower_Drag.GetComponent<TowerDrag>().CanPlace) ||
            (FreezeTower_Drag.activeInHierarchy && FreezeTower_Drag.GetComponent<TowerDrag>().CanPlace) ||
            (PoisonTower_Drag.activeInHierarchy && PoisonTower_Drag.GetComponent<TowerDrag>().CanPlace) ||
            (BombTower_Drag.activeInHierarchy && BombTower_Drag.GetComponent<TowerDrag>().CanPlace)
           )
        {
            if (gameManager.isDamageTowerSelected)
            {
                if (ReferencesManager.GameManager.CanPurchase(ReferencesManager.TowerManager.DamageTowerStat.Cost))
                {
                    Instantiate(DamageTower, mousePosition, Quaternion.identity);
                    ReferencesManager.GameManager.ReduceCoins(ReferencesManager.TowerManager.DamageTowerStat.Cost);
                    ReferencesManager.UIManager_Cost.UpdateCoins();
                }
            }
            else if (gameManager.isFreezeTowerSelected)
            {
                if (ReferencesManager.GameManager.CanPurchase(ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.Cost))
                {
                    Instantiate(FreezeTower, mousePosition, Quaternion.identity);
                    ReferencesManager.GameManager.ReduceCoins(ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.Cost);
                    ReferencesManager.UIManager_Cost.UpdateCoins();
                }
            }
            else if (gameManager.isPoisonTowerSelected)
            {
                if (ReferencesManager.GameManager.CanPurchase(ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.Cost))
                {
                    Instantiate(PoisonTower, mousePosition, Quaternion.identity);
                    ReferencesManager.GameManager.ReduceCoins(ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.Cost);
                    ReferencesManager.UIManager_Cost.UpdateCoins();
                }
            }
            else if (gameManager.isBombTowerSelected)
            {
                if (ReferencesManager.GameManager.CanPurchase(ReferencesManager.TowerManager.BombTowerStat.TowerStats.Cost))
                {
                    Instantiate(BombTower, mousePosition, Quaternion.identity);
                    ReferencesManager.GameManager.ReduceCoins(ReferencesManager.TowerManager.BombTowerStat.TowerStats.Cost);
                    ReferencesManager.UIManager_Cost.UpdateCoins();
                }
            }
        }
    }
}
