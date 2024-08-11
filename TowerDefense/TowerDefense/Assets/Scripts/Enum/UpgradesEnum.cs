using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradesEnum_Branch
{
    LeftBranch = 0,
    MiddleBranch = 1,
    RightBranch = 2
}

public enum UpgradesEnum_Level
{
    Level1 = 0,
    Level2 = 1,
    Level3 = 2,
    Level3_1 = 3,
    Level3_2 = 4,
    Level4 = 5,
    Level4_1 = 6,
    Level4_2 = 7,
    Level5 = 8,
}

public static class UpgradeEnum_BranchHandler
{
    public static UpgradesEnum_Branch? GetBranch(GameObject node, List<List<GameObject>> TowerLeftBranches, List<List<GameObject>> TowerMiddleBranches, List<List<GameObject>> TowerRightBranches)
    {
        if (
            TowerLeftBranches[0].Contains(node) ||
            TowerLeftBranches[1].Contains(node) ||
            TowerLeftBranches[2].Contains(node) ||
            TowerLeftBranches[3].Contains(node)
          )
        {
            return UpgradesEnum_Branch.LeftBranch;
        }
        else if (
                TowerMiddleBranches[0].Contains(node) ||
                TowerMiddleBranches[1].Contains(node) ||
                TowerMiddleBranches[2].Contains(node) ||
                TowerMiddleBranches[3].Contains(node)
               )
        {
            return UpgradesEnum_Branch.MiddleBranch;
        }
        else if (
                TowerRightBranches[0].Contains(node) ||
                TowerRightBranches[1].Contains(node) ||
                TowerRightBranches[2].Contains(node) ||
                TowerRightBranches[3].Contains(node)
               )
        {
            return UpgradesEnum_Branch.RightBranch;
        }

        return null;
    }
}

public static class UpgradeEnum_LevelHandler
{
    public static UpgradesEnum_Level? GetLevel(GameObject node)
    {
        if (node.name.Contains("Level1"))
        {
            return UpgradesEnum_Level.Level1;
        }
        else if (node.name.Contains("Level2"))
        {
            return UpgradesEnum_Level.Level2;
        }
        else if (node.name.Contains("Level3.1"))
        {
            return UpgradesEnum_Level.Level3_1;
        }
        else if (node.name.Contains("Level3.2"))
        {
            return UpgradesEnum_Level.Level3_2;
        }
        else if (node.name.Contains("Level3"))
        {
            return UpgradesEnum_Level.Level3;
        }
        else if (node.name.Contains("Level4.1"))
        {
            return UpgradesEnum_Level.Level4_1;
        }
        else if (node.name.Contains("Level4.2"))
        {
            return UpgradesEnum_Level.Level4_2;
        }
        else if (node.name.Contains("Level4"))
        {
            return UpgradesEnum_Level.Level4;
        }
        else if (node.name.Contains("Level5"))
        {
            return UpgradesEnum_Level.Level5;
        }

        return null;
    }
}
