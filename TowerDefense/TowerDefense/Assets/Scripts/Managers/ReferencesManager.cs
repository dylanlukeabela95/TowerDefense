using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public GameManager GameManager;
    public TowerManager TowerManager;
    public StatsManager StatsManager;
    public UpgradesManager UpgradesManager;
    public CostManager CostManager;
    public SpriteManager SpriteManager;
    public ItemsManager ItemsManager;

    [Header("UI Managers")]
    public UIManager_Tower UIManager_Tower;
    public UIManager_Cost UIManager_Cost;
    public UIManager_Stat UIManager_Stat;
    public UIManager_Upgrades UIManager_Upgrades;
    public UIManager_SpeechBubble UIManager_SpeechBubble;
    public UIManager_Items UIManager_Items;
}
