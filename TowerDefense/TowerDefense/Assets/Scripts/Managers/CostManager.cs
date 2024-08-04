using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    [Header("Tower Costs")]
    public int DamageTowerCost;
    public int FreezeTowerCost;
    public int PoisonTowerCost;
    public int BombTowerCost;

    private void Awake()
    {
        SetUpTowerCost();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUpTowerCost()
    {
        DamageTowerCost = 20;
        FreezeTowerCost = 30;
        PoisonTowerCost = 35;
        BombTowerCost = 60;
    }

    public int SetUpDamageTowerNodeCost(UpgradesEnum_Branch branch, UpgradesEnum_Level level)
    {
        int cost = 0
        switch(branch)
        {
            case UpgradesEnum_Branch.LeftBranch:
                break;
            case UpgradesEnum_Branch.MiddleBranch:
                break;
            case UpgradesEnum_Branch.RightBranch:
                break;
            default:
                cost = -1;
                break;
        }

        return cost;
    }

    public int SetUpFreezeTowerCost(UpgradesEnum_Branch branch, UpgradesEnum_Level level)
    {
        int cost = 0
        switch (branch)
        {
            case UpgradesEnum_Branch.LeftBranch:
                break;
            case UpgradesEnum_Branch.MiddleBranch:
                break;
            case UpgradesEnum_Branch.RightBranch:
                break;
            default:
                cost = -1;
                break;
        }

        return cost;
    }

    public int SetupPoisonTowerCost(UpgradesEnum_Branch branch, UpgradesEnum_Level level)
    {
        int cost = 0
        switch (branch)
        {
            case UpgradesEnum_Branch.LeftBranch:
                break;
            case UpgradesEnum_Branch.MiddleBranch:
                break;
            case UpgradesEnum_Branch.RightBranch:
                break;
            default:
                cost = -1;
                break;
        }

        return cost;
    }

    public int SetUpBombTowerCost(UpgradesEnum_Branch branch, UpgradesEnum_Level level)
    {
        int cost = 0
        switch (branch)
        {
            case UpgradesEnum_Branch.LeftBranch:
                break;
            case UpgradesEnum_Branch.MiddleBranch:
                break;
            case UpgradesEnum_Branch.RightBranch:
                break;
            default:
                cost = -1;
                break;
        }

        return cost;
    }    
}
