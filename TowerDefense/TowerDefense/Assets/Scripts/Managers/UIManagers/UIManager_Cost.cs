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

    // Start is called before the first frame update
    void Start()
    {
        UpdateCoins();

        // Set the on-screen position to be where the panel is initially placed in the UI
        OnScreenPosition = CoinsSection.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoins()
    {
        CoinsText.text = ReferencesManager.GameManager.coins.ToString();
    }

    public void UpdateCoins(TextMeshProUGUI coinsText, int coins)
    {
        coinsText.text = coins.ToString();
    }
}
