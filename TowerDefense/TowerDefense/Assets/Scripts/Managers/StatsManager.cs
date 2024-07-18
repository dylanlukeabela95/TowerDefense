using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public List<string> DamageTowerStats = new List<string>() { "Damage", "Fire Rate", "Range" };
    public List<string> FreezeTowerStats = new List<string>() { "Damage", "Fire Rate", "Range", "Ice Damage", "Slow Effect" , "Slow Duration"};
    public List<string> PoisonTowerStats = new List<string>() { "Damage", "Fire Rate", "Range", "Poison Damage Over Time", "Poison Duration" , "Poison Tick Rate"};
    public List<string> BombTowerStats = new List<string>() { "Damage", "Fire Rate", "Range", "Splash Damage", "Splash Radius" };

    
}
