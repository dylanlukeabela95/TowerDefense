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

    public List<GameObject> allTowers = new List<GameObject>();
    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
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
        allTowers.Add(tower);
    }

    public void RemoveTowerFromList(GameObject tower)
    {
        allTowers.Remove(tower);
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
}
