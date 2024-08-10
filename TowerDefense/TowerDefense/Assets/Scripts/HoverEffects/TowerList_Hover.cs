using Strings;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerList_Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ReferencesManager ReferencesManager;
    string Title;
    string Description;
    string Damage;
    string FireRate;
    string Range;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ReferencesManager.UIManager_SpeechBubble.ShowHideSpeechBubble(true);

        if (ReferencesManager.UIManager_SpeechBubble.SpeechBubbleTitle.text != Title)
        {
            SetSpeechBubble();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ReferencesManager.UIManager_SpeechBubble.ShowHideSpeechBubble(false);
    }

    public void SetSpeechBubble()
    {
        switch(this.gameObject.name)
        {
            case StringsDatabase.UI_TowerList.DamageTowerButton:
                SetDamageTowerStats();
                break;
            case StringsDatabase.UI_TowerList.FreezeTowerButton:
                SetFreezeTowerStats();
                break;
            case StringsDatabase.UI_TowerList.PoisonTowerButton:
                SetPoisonTowerStats();
                break;
            case StringsDatabase.UI_TowerList.BombTowerButton:
                SetBombTowerStats();
                break;
        }
    }

    public void SetDamageTowerStats()
    {
        Title = StringsDatabase.TowerNames.DamageTower;
        Description = StringsDatabase.TowerDescriptions.DamageTowerDescription;
        Damage = ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Damage].ToString();
        FireRate = (1 * 1.0f / (float)ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.FireRate]).ToString("F2") + " / s";
        Range = ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Range].ToString() + " m";

        ReferencesManager.UIManager_SpeechBubble.UpdateSpeechBubble(Title, Description, Damage, FireRate, Range);
    }

    public void SetFreezeTowerStats()
    {
        Title = StringsDatabase.TowerNames.FreezeTower;
        Description = StringsDatabase.TowerDescriptions.FreezeTowerDescription;
        Damage = ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Damage].ToString();
        FireRate = (1 * 1.0f / (float)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.FireRate]).ToString("F2") + " / s";
        Range = ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Range].ToString() + " m";

        ReferencesManager.UIManager_SpeechBubble.UpdateSpeechBubble(Title, Description, Damage, FireRate, Range);
    }

    public void SetPoisonTowerStats()
    {
        Title = StringsDatabase.TowerNames.PoisonTower;
        Description = StringsDatabase.TowerDescriptions.PoisonTowerDescription;
        Damage = ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.Damage].ToString();
        FireRate = (1 * 1.0f/ (float)ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.FireRate]).ToString("F2") + " / s";
        Range = ReferencesManager.TowerManager.PoisonStats[StringsDatabase.Stats.Range].ToString() + " m";

        ReferencesManager.UIManager_SpeechBubble.UpdateSpeechBubble(Title, Description, Damage, FireRate, Range);
    }

    public void SetBombTowerStats()
    {
        Title = StringsDatabase.TowerNames.BombTower;
        Description = StringsDatabase.TowerDescriptions.BombTowerDescription;
        Damage = ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.Damage].ToString();
        FireRate = (1 * 1.0f / (float)ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.FireRate]).ToString("F2") + " / s";
        Range = ReferencesManager.TowerManager.BombStats[StringsDatabase.Stats.Range].ToString() + " m";

        ReferencesManager.UIManager_SpeechBubble.UpdateSpeechBubble(Title, Description, Damage, FireRate, Range);
    }
}
