using Strings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    [Header("Tower Selected")]
    public bool isDamageTowerSelected;
    public bool isFreezeTowerSelected;
    public bool isPoisonTowerSelected;
    public bool isBombTowerSelected;

    [Header("Coins")]
    public int coins;

    [Header("Poison Critical Chance")]
    public int PoisonCriticalChance = 0;

    [Header("All Towers On The Field")]
    public List<GameObject> AllTowers = new List<GameObject>();

    [Header("All Enemies On The Field")]
    public List<GameObject> enemiesInScreen = new List<GameObject>();

    [Header("Currently Selected Tower")]
    public GameObject currentTower;

    [Header("Tower Discounts")]
    public int DamageTowerVoucherDiscount;
    public int FreezeTowerVoucherDiscount;
    public int PoisonTowerVoucherDiscount;
    public int BombTowerVoucherDiscount;

    [Header("Bonus Coin Generation")]
    public int bonusCoinGeneration;

    [Header("All Damage Tower Bonus Damage")]
    public int bonusDamageTowerDamage;

    [Header("Damage Text")]
    public GameObject DamageText;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInScreen = GameObject.FindGameObjectsWithTag(StringsDatabase.Tag.EnemyTag).ToList();
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
        AllTowers.Add(tower);
    }

    public void RemoveTowerFromList(GameObject tower)
    {
        AllTowers.Remove(tower);
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

    public void AddEnemyToList(GameObject enemy)
    {
        enemiesInScreen.Add(enemy);
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemiesInScreen.Remove(enemy);  
    }

    public float FormulaPercentage(float original, float boostPercentage)
    {
        float boostedStat = 0;

        boostedStat = original * (1 + (boostPercentage * 1.0f / 100));

        return boostedStat;
    }

    public float FormulaPercentage_ForAddSub(float original, float boostPercentage)
    {
        float boostedStat = 0;

        boostedStat = original * (boostPercentage * 1.0f / 100);

        return boostedStat;
    }

    public void CreateDamageText(GameObject target, int damage, bool isCritical, bool isSuper, bool isSplash, bool isPoison, bool isPoisonCritical, bool isIce, bool? isBurn = null)
    {
        if (ReferencesManager.UIManager_Pause.showDamageNumbers)
        {
            GameObject damageText = Instantiate(DamageText, target.transform.position, Quaternion.identity);

            if (isCritical)
            {
                damageText.GetComponent<TextMeshPro>().color = Color.yellow;
            }

            if (isSuper)
            {
                damageText.GetComponent<TextMeshPro>().color = new Color32(160, 32, 240, 255);
            }

            if (isSplash)
            {
                damageText.GetComponent<TextMeshPro>().color = new Color32(255, 211, 0, 255);
            }

            if (isPoison)
            {
                damageText.GetComponent<TextMeshPro>().color = Color.green;
            }

            if (isPoisonCritical)
            {
                damageText.GetComponent<TextMeshPro>().color = new Color32(206, 250, 5, 255);
            }

            if (isIce)
            {
                damageText.GetComponent<TextMeshPro>().color = Color.cyan;
            }

            if (isBurn != null && isBurn == true)
            {
                damageText.GetComponent<TextMeshPro>().color = new Color32(255, 165, 0, 255);
            }

            damageText.GetComponent<TextMeshPro>().text = damage.ToString();
        }
    }

    public void CreateDamageText(GameObject target, string status, bool isImmobilize, bool isStun)
    {
        if (ReferencesManager.UIManager_Pause.showDamageNumbers)
        {
            GameObject damageText = Instantiate(DamageText, target.transform.position, Quaternion.identity);

            if (isImmobilize)
            {
                damageText.GetComponent<TextMeshPro>().text = "Immobilize";
                damageText.GetComponent<TextMeshPro>().color = Color.cyan;
            }

            if (isStun)
            {
                damageText.GetComponent<TextMeshPro>().text = "Stun";
                damageText.GetComponent<TextMeshPro>().color = Color.yellow;
            }

            damageText.GetComponent<DamageText>().goDown = true;
        }
    }
}
