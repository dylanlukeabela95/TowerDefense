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
        int cost = 0;
        if (level == UpgradesEnum_Level.Level1)
        {
            cost = 20;
        }
        else
        {
            switch (branch)
            {
                case UpgradesEnum_Branch.LeftBranch:
                    switch(level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 25;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 55;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 40;
                            break;
                        case UpgradesEnum_Level.Level4:
                            cost = 70;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 100;
                            break;
                    }
                    break;
                case UpgradesEnum_Branch.MiddleBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 25;
                            break;
                        case UpgradesEnum_Level.Level3:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level4_1:
                            cost = 70;
                            break;
                        case UpgradesEnum_Level.Level4_2:
                            cost = 60;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 90;
                            break;
                    }
                    break;
                case UpgradesEnum_Branch.RightBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 25;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 60;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level4:
                            cost = 75;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 120;
                            break;
                    }
                    break;
                default:
                    cost = -1;
                    break;
            }
        }

        return cost;
    }

    public int SetUpFreezeTowerCost(UpgradesEnum_Branch branch, UpgradesEnum_Level level)
    {
        int cost = 0;
        if (level == UpgradesEnum_Level.Level1)
        {
            cost = 35;
        }
        else
        {
            switch (branch)
            {
                case UpgradesEnum_Branch.LeftBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 65;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 70;
                            break;
                        case UpgradesEnum_Level.Level4:
                            cost = 80;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 100;
                            break;
                    }
                    break;
                case UpgradesEnum_Branch.MiddleBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 65;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 70;
                            break;
                        case UpgradesEnum_Level.Level4:
                            cost = 85;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 110;
                            break;
                    }
                    break;
                case UpgradesEnum_Branch.RightBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level3:
                            cost = 60;
                            break;
                        case UpgradesEnum_Level.Level4_1:
                            cost = 85;
                            break;
                        case UpgradesEnum_Level.Level4_2:
                            cost = 75;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 130;
                            break;
                    }
                    break;
                default:
                    cost = -1;
                    break;
            }
        }
        return cost;
    }

    public int SetupPoisonTowerCost(UpgradesEnum_Branch branch, UpgradesEnum_Level level)
    {
        int cost = 0;
        if (level == UpgradesEnum_Level.Level1)
        {
            cost = 30;
        }
        else
        {
            switch (branch)
            {
                case UpgradesEnum_Branch.LeftBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 70;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 80;
                            break;
                        case UpgradesEnum_Level.Level4:
                            cost = 90;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 110;
                            break;
                    }
                    break;
                case UpgradesEnum_Branch.MiddleBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 50;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 60;
                            break;
                        case UpgradesEnum_Level.Level4_1:
                            cost = 70;
                            break;
                        case UpgradesEnum_Level.Level4_2:
                            cost = 85;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 140;
                            break;
                    }
                    break;
                case UpgradesEnum_Branch.RightBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 55;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 60;
                            break;
                        case UpgradesEnum_Level.Level4:
                            cost = 80;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 110;
                            break;
                    }
                    break;
                default:
                    cost = -1;
                    break;
            }
        }

        return cost;
    }

    public int SetUpBombTowerCost(UpgradesEnum_Branch branch, UpgradesEnum_Level level)
    {
        int cost = 0;
        if (level == UpgradesEnum_Level.Level1)
        {
            cost = 30;
        }
        else
        {
            switch (branch)
            {
                case UpgradesEnum_Branch.LeftBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 65;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 85;
                            break;
                        case UpgradesEnum_Level.Level4:
                            cost = 90;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 120;
                            break;
                    }
                    break;
                case UpgradesEnum_Branch.MiddleBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 70;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 60;
                            break;
                        case UpgradesEnum_Level.Level4_1:
                            cost = 90;
                            break;
                        case UpgradesEnum_Level.Level4_2:
                            cost = 80;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 100;
                            break;
                    }
                    break;
                case UpgradesEnum_Branch.RightBranch:
                    switch (level)
                    {
                        case UpgradesEnum_Level.Level2:
                            cost = 45;
                            break;
                        case UpgradesEnum_Level.Level3_1:
                            cost = 65;
                            break;
                        case UpgradesEnum_Level.Level3_2:
                            cost = 60;
                            break;
                        case UpgradesEnum_Level.Level4_1:
                            cost = 80;
                            break;
                        case UpgradesEnum_Level.Level4_2:
                            cost = 75;
                            break;
                        case UpgradesEnum_Level.Level5:
                            cost = 100;
                            break;
                    }
                    break;
                default:
                    cost = -1;
                    break;
            }
        }

        return cost;
    }    
}
