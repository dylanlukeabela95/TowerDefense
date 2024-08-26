using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager_Cost : MonoBehaviour
{
    public ReferencesManager ReferencesManager;
    public TextMeshProUGUI CoinsText;
    public RectTransform CoinsSection;

    public GameObject CostSection_SkillTree;

    private Vector2 OnScreenPosition;

    [Header("Tower List Cost")]
    public TextMeshProUGUI DamageTowerCost;
    public TextMeshProUGUI FreezeTowerCost;
    public TextMeshProUGUI PoisonTowerCost;
    public TextMeshProUGUI BombTowerCost;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCoins();

        // Set the on-screen position to be where the panel is initially placed in the UI
        OnScreenPosition = CoinsSection.anchoredPosition;

        SetupTowerCost_UI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoins()
    {
        CoinsText.text = ReferencesManager.GameManager.coins.ToString();
    }

    public void UpdateCoins(TextMeshProUGUI coinsText, int cost)
    {
        coinsText.text = cost.ToString();
    }

    public void SetupTowerCost_UI()
    {
        UpdateCoins(DamageTowerCost, ReferencesManager.CostManager.DamageTowerCost - ReferencesManager.GameManager.DamageTowerVoucherDiscount);
        UpdateCoins(FreezeTowerCost, ReferencesManager.CostManager.FreezeTowerCost - ReferencesManager.GameManager.FreezeTowerVoucherDiscount);
        UpdateCoins(PoisonTowerCost, ReferencesManager.CostManager.PoisonTowerCost - ReferencesManager.GameManager.PoisonTowerVoucherDiscount);
        UpdateCoins(BombTowerCost, ReferencesManager.CostManager.BombTowerCost - ReferencesManager.GameManager.BombTowerVoucherDiscount);
    }
}
