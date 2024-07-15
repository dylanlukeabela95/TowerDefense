using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDrag : MonoBehaviour
{
    public bool CanPlace;
    public GameObject RangeIndicator;
    public ReferencesManager ReferencesManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!CanPlace || !SufficientCoins())
        {
            RangeIndicator.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 60 * 1.0f/255);
        }
        else
        {
            RangeIndicator.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 60 * 1.0f/255);
        }
    }

    public bool SufficientCoins()
    {
        var enoughCoins = true;

        if (ReferencesManager.GameManager.isDamageTowerSelected)
        {
            enoughCoins = ReferencesManager.GameManager.CanPurchase(ReferencesManager.TowerManager.DamageTowerStat.Cost);
        }
        else if (ReferencesManager.GameManager.isFreezeTowerSelected)
        {
            enoughCoins = ReferencesManager.GameManager.CanPurchase(ReferencesManager.TowerManager.FreezeTowerStat.TowerStats.Cost);
        }
        else if (ReferencesManager.GameManager.isPoisonTowerSelected)
        {
            enoughCoins = ReferencesManager.GameManager.CanPurchase(ReferencesManager.TowerManager.PoisonTowerStat.TowerStats.Cost);
        } 
        else if (ReferencesManager.GameManager.isBombTowerSelected)
        {
            enoughCoins = ReferencesManager.GameManager.CanPurchase(ReferencesManager.TowerManager.BombTowerStat.TowerStats.Cost);
        }

        return enoughCoins;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name.Contains("Tower"))
        {
            CanPlace = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Tower"))
        {
            CanPlace = true;
        }
    }
}
