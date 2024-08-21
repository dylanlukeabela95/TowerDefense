using Strings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public bool isDamageTowerSelected;
    public bool isFreezeTowerSelected;
    public bool isPoisonTowerSelected;
    public bool isBombTowerSelected;

    public int coins;
    public int PoisonCriticalChance = 0;

    public List<GameObject> AllTowers = new List<GameObject>();
    public List<GameObject> enemiesInScreen = new List<GameObject>();

    public GameObject currentTower;

    public int DamageTowerVoucherDiscount;
    public int FreezeTowerVoucherDiscount;
    public int PoisonTowerVoucherDiscount;
    public int BombTowerVoucherDiscount;

    public int bonusCoinGeneration;


    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();

        enemiesInScreen = GameObject.FindGameObjectsWithTag(StringsDatabase.Tag.EnemyTag).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        HideDragTower();
    }

    public void SetBooleans(bool damageTower, bool freezeTower, bool poisonTower, bool bombTower)
    {
        isDamageTowerSelected = damageTower;
        isFreezeTowerSelected = freezeTower;
        isPoisonTowerSelected = poisonTower;
        isBombTowerSelected = bombTower;

        ReferencesManager.TowerManager.EmptyDraggedTower();
    }

    public bool CheckIfTowerSelected()
    {
        if(isDamageTowerSelected || isFreezeTowerSelected || isPoisonTowerSelected || isBombTowerSelected)
            return true;

        return false;
    }

    public void HideDragTower()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ReferencesManager.TowerManager.EmptyDraggedTower();
            ReferencesManager.TowerManager.HideAllDraggedTowers();
        }
    }

    public void AddTowerToList(GameObject tower)
    {
        AllTowers.Add(tower);
    }

    public void RemoveTowerFromList(GameObject tower)
    {
        AllTowers.Remove(tower);
    }

    public void ReduceCoins(int cost)
    {
        coins -= cost;
    }

    public bool CanPurchase(int cost)
    {
        if(coins >= cost)
        {
            return true;
        }

        return false;
    }

    public void AddEnemyToList(GameObject enemy)
    {
        enemiesInScreen.Add(enemy);
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemiesInScreen.Remove(enemy);  
    }

    public float FormulaPercentage(float original, float boostPercentage)
    {
        float boostedStat = 0;

        boostedStat = original * (1 + (boostPercentage * 1.0f / 100));

        return boostedStat;
    }
}
