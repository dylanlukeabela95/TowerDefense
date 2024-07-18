using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public GameManager GameManager;
    public TowerManager TowerManager;
    public StatsManager StatsManager;
    public UpgradesManager UpgradesManager;

    [Header("UI Managers")]
    public UIManager_Tower UIManager_Tower;
    public UIManager_Cost UIManager_Cost;
    public UIManager_Stat UIManager_Stat;
}
