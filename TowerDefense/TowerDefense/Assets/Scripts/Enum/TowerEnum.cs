using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerEnum
{
    DamageTower = 0,
    PoisonTower = 1,
    FreezeTower = 2,
    BombTower = 3
}

public static class TowerEnumHandler
{
    public static TowerEnum? GetTowerEnum(GameObject node)
    {
        if (node.name.Contains("DamageTower"))
        {
            return TowerEnum.DamageTower;
        }
        else if (node.name.Contains("FreezeTower"))
        {
            return TowerEnum.FreezeTower;
        }
        else if (node.name.Contains("PoisonTower"))
        {
            return TowerEnum.PoisonTower;
        }
        else if (node.name.Contains("BombTower"))
        {
            return TowerEnum.BombTower;
        }

        return null;
    }
}
