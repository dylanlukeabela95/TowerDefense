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

    GameObject DraggedTower;

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

    void DragTower()
    {
        if (DraggedTower == null)
        {
            var gameManager = ReferencesManager.GameManager;
            if (gameManager.CheckIfTowerSelected())
            {
                if (gameManager.isDamageTowerSelected)
                {
                    ShowHideDragTowers(true, false, false, false);
                    DraggedTower = DamageTower_Drag;
                }
                else if (gameManager.isFreezeTowerSelected)
                {
                    ShowHideDragTowers(false, true, false, false);
                    DraggedTower = FreezeTower_Drag;
                }
                else if (gameManager.isPoisonTowerSelected)
                {
                    ShowHideDragTowers(false, false, true, false);
                    DraggedTower = PoisonTower_Drag;
                }
                else if (gameManager.isBombTowerSelected)
                {
                    ShowHideDragTowers(false, false, false, true);
                    DraggedTower = BombTower_Drag;
                }
            }
        }
        else
        {
            DraggedTower.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void TowerChange()
    {
        DraggedTower = null;
    }

    public void PlaceTower()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var gameManager = ReferencesManager.GameManager;

        if (gameManager.isDamageTowerSelected)
        {
            Instantiate(DamageTower, mousePosition, Quaternion.identity);
        }
        else if (gameManager.isFreezeTowerSelected)
        {
            Instantiate(FreezeTower, mousePosition, Quaternion.identity);
        }
        else if (gameManager.isPoisonTowerSelected)
        {
            Instantiate(PoisonTower, mousePosition, Quaternion.identity);
        }
        else if (gameManager.isBombTowerSelected)
        {
            Instantiate(BombTower, mousePosition, Quaternion.identity); 
        }
    }
}
