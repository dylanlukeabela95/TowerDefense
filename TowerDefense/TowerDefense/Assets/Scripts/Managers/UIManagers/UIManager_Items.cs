using Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Tab
{
    public GameObject TabObject { get; set; }
    public GameObject ItemDisplay {  get; set; }
    public bool isSelected { get; set; }
}

public class UIManager_Items : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    [Header("Item Section")]
    public GameObject itemSection;

    [Header("Item Info Section")]
    public GameObject itemInfoSection;

    [Header("Item Slot")]
    public GameObject itemSlot;

    [Header("Item Displays")]
    public List<GameObject> itemDisplays = new List<GameObject>();

    [Header("Item Icon")]
    public GameObject itemIcon;

    [Header("Stats Section")]
    public GameObject statsSection;
    public GameObject statUI;

    [Header("Alert Text")]
    public GameObject alertText;

    [Header("Attach Button")]
    public Button attachButton;

    public List<Tab> itemTabs = new List<Tab>();

    [Header("Tabs")]
    public List<GameObject> tabsObject = new List<GameObject>();

    [Header("Item Slots In Items")]
    public GameObject[] itemSlotsInItems = new GameObject[5];
    public GameObject itemSlotSelected;

    private string itemName;

    private float unSelectedTabHeight = 45.398f;
    private float selectedTabHeight = 54.4776f;

    private bool isItemSelected;

    // Start is called before the first frame update
    void Start()
    {
        SetTabs(tabsObject, itemDisplays);

        AlterTabHeight(selectedTabHeight);

        itemSection.SetActive(false);

        UpdateItemList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetTabs(List<GameObject> tabs, List<GameObject> itemDisplays)
    {
        int counter = 0;
        foreach (var tab in tabs)
        {
            Tab tabObject = new Tab()
            {
                TabObject = tab,
                ItemDisplay = itemDisplays[counter],
                isSelected = false,
            };
            counter++;
            
            itemTabs.Add(tabObject);

            if(itemTabs.Count == 1)
            {
                itemTabs[0].isSelected = true;
                itemTabs[0].ItemDisplay.SetActive(true);
            }
            else
            {
                itemTabs[counter-1].ItemDisplay.SetActive(false);
            }
        }

    }

    void NewTabSelected(GameObject newTab)
    {
        if(newTab != null)
        {
            AlterTabHeight(unSelectedTabHeight);

            itemTabs.Find(a => a.isSelected == true).ItemDisplay.SetActive(false);
            itemTabs.Find(a => a.isSelected == true).isSelected = false;
            itemTabs.Find(a => a.TabObject == newTab).isSelected = true;
            itemTabs.Find(a => a.isSelected == true).ItemDisplay.SetActive(true);

            AlterTabHeight(selectedTabHeight);
        }
    }

    void AlterTabHeight(float height)
    {
        Vector2 size = itemTabs.Find(a => a.isSelected == true).TabObject.GetComponent<RectTransform>().sizeDelta;
        size.y = height;
        itemTabs.Find(a => a.isSelected == true).TabObject.GetComponent<RectTransform>().sizeDelta = size;
    }

    void UpdateItemList(Item? itemAttached = null, bool? swappedItem = null)
    {
        var itemDisplay_General = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_General").ItemDisplay;
        var itemDisplay_Damage = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_Damage").ItemDisplay;
        var itemDisplay_Freeze = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_Freeze").ItemDisplay;
        var itemDisplay_Poison = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_Poison").ItemDisplay;
        var itemDisplay_Bomb = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_Bomb").ItemDisplay;

        if (itemAttached == null)
        {
            foreach (var item in ReferencesManager.ItemsManager.GeneralItems)
            {
                GameObject itemGeneral = Instantiate(itemIcon, itemDisplay_General.transform.position, Quaternion.identity, itemDisplay_General.transform);
                itemGeneral.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.ItemName;
                itemGeneral.name = item.ItemName;

                if (item.ItemCount > 1)
                {
                    itemGeneral.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + item.ItemCount;
                }
                else
                {
                    itemGeneral.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "";
                }

                itemGeneral.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(item.ItemName));
            }

            foreach (var item in ReferencesManager.ItemsManager.DamageTowerItems)
            {
                GameObject itemDamage = Instantiate(itemIcon, itemDisplay_Damage.transform.position, Quaternion.identity, itemDisplay_Damage.transform);
                itemDamage.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.ItemName;
                itemDamage.name = item.ItemName;

                if (item.ItemCount > 1)
                {
                    itemDamage.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + item.ItemCount;
                }
                else
                {
                    itemDamage.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "";
                }

                itemDamage.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(item.ItemName));
            }

            foreach (var item in ReferencesManager.ItemsManager.FreezeTowerItems)
            {
                GameObject itemFreeze = Instantiate(itemIcon, itemDisplay_Freeze.transform.position, Quaternion.identity, itemDisplay_Freeze.transform);
                itemFreeze.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.ItemName;
                itemFreeze.name = item.ItemName;

                if (item.ItemCount > 1)
                {
                    itemFreeze.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + item.ItemCount;
                }
                else
                {
                    itemFreeze.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "";
                }

                itemFreeze.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(item.ItemName));
            }

            foreach (var item in ReferencesManager.ItemsManager.PoisonTowerItems)
            {
                GameObject itemPoison = Instantiate(itemIcon, itemDisplay_Poison.transform.position, Quaternion.identity, itemDisplay_Poison.transform);
                itemPoison.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.ItemName;
                itemPoison.name = item.ItemName;

                if (item.ItemCount > 1)
                {
                    itemPoison.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + item.ItemCount;
                }
                else
                {
                    itemPoison.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "";
                }

                itemPoison.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(item.ItemName));
            }

            foreach (var item in ReferencesManager.ItemsManager.BombTowerItems)
            {
                GameObject itemBomb = Instantiate(itemIcon, itemDisplay_Bomb.transform.position, Quaternion.identity, itemDisplay_Bomb.transform);
                itemBomb.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.ItemName;
                itemBomb.name = item.ItemName;

                if (item.ItemCount > 1)
                {
                    itemBomb.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + item.ItemCount;
                }
                else
                {
                    itemBomb.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "";
                }

                itemBomb.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(item.ItemName));

            }
        }
        else
        {
            Transform item = null;
            switch(itemAttached.ItemName)
            {
                case StringsDatabase.Items.Weight:
                case StringsDatabase.Items.HotPepper:
                case StringsDatabase.Items.Lens:
                case StringsDatabase.Items.Voucher:
                case StringsDatabase.Items.PiggyBank:
                case StringsDatabase.Items.DartBoard:
                    item = itemDisplay_General.transform.Find(itemAttached.ItemName);
                    if (swappedItem == true && item == null)
                    {
                        GameObject itemGeneral = Instantiate(itemIcon, itemDisplay_General.transform.position, Quaternion.identity, itemDisplay_General.transform);
                        itemGeneral.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = itemAttached.ItemName;
                        itemGeneral.name = itemAttached.ItemName;
                        item = itemGeneral.transform;
                        itemGeneral.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(itemAttached.ItemName));
                    }
                    else if(swappedItem == true && item != null)
                    {
                        item.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x "+itemAttached.ItemCount.ToString();
                    }
                    break;
                case StringsDatabase.Items.Scope:
                case StringsDatabase.Items.BoxOfBullets:
                case StringsDatabase.Items.Matches:
                case StringsDatabase.Items.Blueprint:
                case StringsDatabase.Items.RedBall:
                    item = itemDisplay_Damage.transform.Find(itemAttached.ItemName);
                    if (swappedItem == true && item == null)
                    {
                        GameObject itemDamage = Instantiate(itemIcon, itemDisplay_Damage.transform.position, Quaternion.identity, itemDisplay_Damage.transform);
                        itemDamage.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = itemAttached.ItemName;
                        itemDamage.name = itemAttached.ItemName;
                        item = itemDamage.transform;
                        itemDamage.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(itemAttached.ItemName));
                    }
                    else if (swappedItem == true && item != null)
                    {
                        item.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + itemAttached.ItemCount.ToString();
                    }
                    break;
                case StringsDatabase.Items.Snowflake:
                case StringsDatabase.Items.LiquidNitrogen:
                case StringsDatabase.Items.IceCube:
                case StringsDatabase.Items.Snowball:
                case StringsDatabase.Items.FrozenBottle:
                case StringsDatabase.Items.IceCream:
                    item = itemDisplay_Freeze.transform.Find(itemAttached.ItemName);
                    if (swappedItem == true && item == null)
                    {
                        GameObject itemFreeze = Instantiate(itemIcon, itemDisplay_Freeze.transform.position, Quaternion.identity, itemDisplay_Freeze.transform);
                        itemFreeze.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = itemAttached.ItemName;
                        itemFreeze.name = itemAttached.ItemName;
                        item = itemFreeze.transform;
                        itemFreeze.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(itemAttached.ItemName));
                    }
                    else if (swappedItem == true && item != null)
                    {
                        item.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + itemAttached.ItemCount.ToString();
                    }
                    break;
                case StringsDatabase.Items.PoisonVial:
                case StringsDatabase.Items.HazardSign:
                case StringsDatabase.Items.MoldyCheese:
                case StringsDatabase.Items.SnotTissue:
                case StringsDatabase.Items.Fungus:
                    item = itemDisplay_Poison.transform.Find(itemAttached.ItemName);
                    if (swappedItem == true && item == null)
                    {
                        GameObject itemPoison = Instantiate(itemIcon, itemDisplay_Poison.transform.position, Quaternion.identity, itemDisplay_Poison.transform);
                        itemPoison.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = itemAttached.ItemName;
                        itemPoison.name = itemAttached.ItemName;
                        item = itemPoison.transform;
                        itemPoison.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(itemAttached.ItemName));
                    }
                    else if (swappedItem == true && item != null)
                    {
                        item.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + itemAttached.ItemCount.ToString();
                    }
                    break;
                case StringsDatabase.Items.Cannonball:
                case StringsDatabase.Items.Dynamite:
                case StringsDatabase.Items.TNTBox:
                case StringsDatabase.Items.Nuke:
                case StringsDatabase.Items.RPG:
                case StringsDatabase.Items.Firework:
                    item = itemDisplay_Bomb.transform.Find(itemAttached.ItemName);
                    if (swappedItem == true && item == null)
                    {
                        GameObject itemBomb = Instantiate(itemIcon, itemDisplay_Bomb.transform.position, Quaternion.identity, itemDisplay_Bomb.transform);
                        itemBomb.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = itemAttached.ItemName;
                        itemBomb.name = itemAttached.ItemName;
                        item = itemBomb.transform;
                        itemBomb.GetComponent<Button>().onClick.AddListener(() => OnClick_Item(itemAttached.ItemName));
                    }
                    else if (swappedItem == true && item != null)
                    {
                        item.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + itemAttached.ItemCount.ToString();
                    }
                    break;
            }

            if (itemAttached.ItemCount == 0)
            {
                Destroy(item.gameObject);
            }
            else
            {
                if (itemAttached.ItemCount > 1)
                {
                    item.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "x " + itemAttached.ItemCount;
                }
                else
                {
                    item.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = ""; 
                }
            }
        }
    }

    void SetInfo(string itemName, string itemDescription)
    {
        itemInfoSection.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = itemName;
        itemInfoSection.transform.Find("ItemDescription").GetComponent<TextMeshProUGUI>().text = itemDescription;

        int currentInt;
        int changeInt;
        float currentFloat;
        float changeFloat;
        GameObject currentTower = ReferencesManager.GameManager.currentTower;

        var item = ReferencesManager.ItemsManager.AllItems.Find(a => a.ItemName == itemName);

        switch (itemName)
        {
            case StringsDatabase.Items.Weight:
                alertText.SetActive(false);
                attachButton.interactable = true;

                currentInt = currentTower.GetComponent<Tower>().Damage;
                changeInt = (int)item.Changes[0];
                SetStatChange("Damage", currentInt, currentInt + changeInt, true);
                break;
            case StringsDatabase.Items.HotPepper:
                alertText.SetActive(false);
                attachButton.interactable = true;

                currentFloat = (float)(1 * 1.0 / currentTower.GetComponent<Tower>().FireRate);
                changeFloat = (float)item.Changes[0];
                SetStatChange("Fire Rate", currentFloat, currentFloat + changeFloat, true);
                break;
            case StringsDatabase.Items.Lens:
                alertText.SetActive(false);
                attachButton.interactable = true;

                currentFloat = currentTower.GetComponent<Tower>().Range;
                changeFloat =(float)item.Changes[0];
                SetStatChange("Range", currentFloat, currentFloat + changeFloat, true);
                break;
            case StringsDatabase.Items.Voucher:
                alertText.SetActive(false);
                attachButton.interactable = true;

                if (currentTower.name.Contains("DamageTower") && ReferencesManager.GameManager.DamageTowerVoucherDiscount < 6)
                {
                    currentInt = ReferencesManager.GameManager.DamageTowerVoucherDiscount;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Damage Tower Discount", currentInt, currentInt + changeInt, true);
                    break;
                }
                else if(currentTower.name.Contains("FreezeTower") && ReferencesManager.GameManager.FreezeTowerVoucherDiscount < 6)
                {
                    currentInt = ReferencesManager.GameManager.FreezeTowerVoucherDiscount;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Freeze Tower Discount", currentInt, currentInt + changeInt, true);
                    break;
                }
                else if (currentTower.name.Contains("PoisonTower") && ReferencesManager.GameManager.PoisonTowerVoucherDiscount < 6)
                {
                    currentInt = ReferencesManager.GameManager.PoisonTowerVoucherDiscount;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Poison Tower Discount", currentInt, currentInt + changeInt, true);
                    break;
                }
                else if (currentTower.name.Contains("BombTower") && ReferencesManager.GameManager.BombTowerVoucherDiscount < 6)
                {
                    currentInt = ReferencesManager.GameManager.BombTowerVoucherDiscount;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Bomb Tower Discount", currentInt, currentInt + changeInt, true);
                    break;
                }
                break;
            case StringsDatabase.Items.PiggyBank:
                alertText.SetActive(false);
                attachButton.interactable = true;

                currentInt = ReferencesManager.GameManager.bonusCoinGeneration;
                changeInt = (int)item.Changes[0];
                SetStatChange("Extra Coin Generation", currentInt, currentInt + changeInt, true);
                break;
            case StringsDatabase.Items.DartBoard:
                alertText.SetActive(false);
                attachButton.interactable = true;

                currentInt = currentTower.GetComponent<Tower>().CriticalChance;
                changeInt = (int)item.Changes[0];
                SetStatChange("Critical Chance", currentInt, currentInt + changeInt, true);
                break;
            case StringsDatabase.Items.Scope:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<Tower>().CriticalChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Critical Chance", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<DamageTower>().CriticalDamage;
                    changeInt = (int)ReferencesManager.GameManager.FormulaPercentage(currentTower.GetComponent<Tower>().Damage, currentTower.GetComponent<DamageTower>().CriticalPercentage + (int)item.Changes[1]);
                    SetStatChange("Critical Damage", currentInt, changeInt, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.BoxOfBullets:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<DamageTower>().TwoRoundBurstChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Two Round Burst Chance", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<DamageTower>().ThreeRoundBurstChance;
                    changeInt = (int)item.Changes[1];
                    SetStatChange("Three Round Burst Chance", currentInt, currentInt + changeInt, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Matches:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<DamageTower>().BurnChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Burn Chance", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<DamageTower>().BurnDamage;
                    changeInt = (int)item.Changes[1];
                    SetStatChange("Burn Damage", currentInt, currentInt + changeInt, false);

                    currentFloat = currentTower.GetComponent<DamageTower>().BurnDuration;
                    changeFloat = (float)item.Changes[2];
                    SetStatChange("Burn Duration", currentInt, currentInt + changeInt, false);

                    if (currentTower.GetComponent<DamageTower>().BurnTickRate == 0)
                    {
                        decimal currentDecimal = (decimal)currentTower.GetComponent<DamageTower>().BurnTickRate;
                        changeFloat = (float)item.Changes[3];
                        decimal total = 1 / (currentDecimal - (decimal)changeFloat);
                        total *= -1;
                        SetStatChange("Burn Tick Rate", currentDecimal, total, false);
                    }

                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Blueprint:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = ReferencesManager.GameManager.bonusDamageTowerDamage;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Bonus Damage", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.RedBall:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;   

                    currentInt = currentTower.GetComponent<DamageTower>().SuperDamageChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Super Damage Chance", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<DamageTower>().SuperDamage;
                    changeInt = currentTower.GetComponent<DamageTower>().Damage * 5;
                    SetStatChange("Super Damage", currentInt, currentInt + changeInt, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Snowflake:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentFloat = currentTower.GetComponent<FreezeTower>().SlowDuration;
                    changeFloat = (float)item.Changes[0];
                    SetStatChange("Slow Duration", currentFloat, currentFloat + changeFloat, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.LiquidNitrogen:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentFloat = currentTower.GetComponent<FreezeTower>().SlowEffect;
                    changeFloat = (float)item.Changes[0];
                    SetStatChange("Slow Effect", currentFloat, currentFloat + changeFloat, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.IceCube:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    if (currentTower.GetComponent<FreezeTower>().IceDamage > 0)
                    {
                        currentInt = currentTower.GetComponent<FreezeTower>().IceDamage;
                        changeInt = (int)item.Changes[0];
                        SetStatChange("Ice Damage", currentInt, currentInt + changeInt, true);
                    }
                    else
                    {
                        currentInt = currentTower.GetComponent<FreezeTower>().FrostbiteDamage;
                        changeInt = (int)item.Changes[1];
                        SetStatChange("Frostbite Damage", currentInt, currentInt + changeInt, true);
                    }
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Snowball:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<FreezeTower>().SnowballChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Snowball Chance", currentInt, currentInt + changeInt, true);

                    currentFloat = currentTower.GetComponent<FreezeTower>().SnowballStunDuration;
                    changeFloat = (float)item.Changes[1];
                    SetStatChange("Snowball Stun Duration", currentFloat, currentFloat + changeFloat, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.FrozenBottle:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<FreezeTower>().IcicleChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Icicle Spawn Chance", currentInt, currentInt + changeInt, true);

                    if (currentTower.GetComponent<FreezeTower>().IcicleDamage == 0)
                    {
                        currentInt = currentTower.GetComponent<FreezeTower>().IcicleDamage;
                        changeInt = 15;
                        SetStatChange("Icicle Damage", currentInt, currentInt + changeInt, false);
                    }
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.IceCream:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<FreezeTower>().ImmobilizeChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Immobilize Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.PoisonVial:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<PoisonTower>().PoisonDamageOverTime;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Poison Damage Over Time", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.HazardSign:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentFloat = currentTower.GetComponent<PoisonTower>().PoisonDuration;
                    changeFloat = (float)item.Changes[0];
                    SetStatChange("Poison Duration", currentFloat, currentFloat + changeFloat, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.MoldyCheese:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    decimal currentDecimal = (decimal)currentTower.GetComponent<PoisonTower>().PoisonTickRate;
                    changeFloat = (float)item.Changes[0];
                    decimal total = 1 / (currentDecimal - (decimal)changeFloat);
                    SetStatChange("Poison Tick Rate", 1/ currentDecimal, total, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.SnotTissue:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<PoisonTower>().DoubleTickRateChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Poison Double Tick Rate Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Fungus:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = ReferencesManager.GameManager.PoisonCriticalChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Poison Critical Damage Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Cannonball:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<Tower>().Damage;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Damage", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<BombTower>().SplashDamage;
                    changeInt = (int)item.Changes[1];
                    SetStatChange("Splash Damage", currentInt, currentInt + changeInt, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Dynamite:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentFloat = currentTower.GetComponent<BombTower>().SplashRadius;
                    changeFloat = (float)item.Changes[0];
                    SetStatChange("Splash Radius", currentFloat, currentFloat + changeFloat, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.TNTBox:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<BombTower>().ExplosionDelay;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Explosion Delay", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<BombTower>().SplashDamage;
                    changeFloat = ReferencesManager.GameManager.FormulaPercentage(currentTower.GetComponent<BombTower>().SplashDamage,  (int)item.Changes[1]);
                    SetStatChange("Splash Damage", currentInt, Mathf.CeilToInt(changeFloat), false);

                    currentFloat = currentTower.GetComponent<BombTower>().SplashRadius;
                    changeFloat = ReferencesManager.GameManager.FormulaPercentage(currentTower.GetComponent<BombTower>().SplashRadius, (int)item.Changes[2]);
                    SetStatChange("Splash Radius", currentFloat, changeFloat, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Nuke:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<BombTower>().NukeChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Nuke Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.RPG:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<BombTower>().RocketChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Rocket Chance", currentInt, currentInt + changeInt, true);

                    if(currentTower.GetComponent<BombTower>().RocketDamage == 0)
                    {
                        currentInt = currentTower.GetComponent<BombTower>().RocketDamage;
                        changeInt = 15;
                        SetStatChange("Rocket Damage", currentInt, currentInt + changeInt, false);
                    }
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Firework:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<BombTower>().DoubleExplosionChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Double Explosion Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
        }
    }

    //To show decrease
    void SetInfoSwap(string previousItemName)
    {
        int currentInt;
        int changeInt;
        float currentFloat;
        float changeFloat;
        GameObject currentTower = ReferencesManager.GameManager.currentTower;

        var item = ReferencesManager.ItemsManager.AllItems.Find(a => a.ItemName == itemName);

        switch (previousItemName)
        {
            case StringsDatabase.Items.Weight:
                currentInt = currentTower.GetComponent<Tower>().Damage;
                changeInt = (int)item.Changes[0];
                SetStatChange("Damage", currentInt, currentInt + changeInt, true);
                break;
            case StringsDatabase.Items.HotPepper:
                alertText.SetActive(false);
                attachButton.interactable = true;

                currentFloat = (float)(1 * 1.0 / currentTower.GetComponent<Tower>().FireRate);
                changeFloat = (float)item.Changes[0];
                SetStatChange("Fire Rate", currentFloat, currentFloat + changeFloat, true);
                break;
            case StringsDatabase.Items.Lens:
                alertText.SetActive(false);
                attachButton.interactable = true;

                currentFloat = currentTower.GetComponent<Tower>().Range;
                changeFloat = (float)item.Changes[0];
                SetStatChange("Range", currentFloat, currentFloat + changeFloat, true);
                break;
            case StringsDatabase.Items.Voucher:
                alertText.SetActive(false);
                attachButton.interactable = true;

                if (currentTower.name.Contains("DamageTower") && ReferencesManager.GameManager.DamageTowerVoucherDiscount < 6)
                {
                    currentInt = ReferencesManager.GameManager.DamageTowerVoucherDiscount;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Damage Tower Discount", currentInt, currentInt + changeInt, true);
                    break;
                }
                else if (currentTower.name.Contains("FreezeTower") && ReferencesManager.GameManager.FreezeTowerVoucherDiscount < 6)
                {
                    currentInt = ReferencesManager.GameManager.FreezeTowerVoucherDiscount;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Freeze Tower Discount", currentInt, currentInt + changeInt, true);
                    break;
                }
                else if (currentTower.name.Contains("PoisonTower") && ReferencesManager.GameManager.PoisonTowerVoucherDiscount < 6)
                {
                    currentInt = ReferencesManager.GameManager.PoisonTowerVoucherDiscount;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Poison Tower Discount", currentInt, currentInt + changeInt, true);
                    break;
                }
                else if (currentTower.name.Contains("BombTower") && ReferencesManager.GameManager.BombTowerVoucherDiscount < 6)
                {
                    currentInt = ReferencesManager.GameManager.BombTowerVoucherDiscount;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Bomb Tower Discount", currentInt, currentInt + changeInt, true);
                    break;
                }
                break;
            case StringsDatabase.Items.PiggyBank:
                alertText.SetActive(false);
                attachButton.interactable = true;

                currentInt = ReferencesManager.GameManager.bonusCoinGeneration;
                changeInt = (int)item.Changes[0];
                SetStatChange("Extra Coin Generation", currentInt, currentInt + changeInt, true);
                break;
            case StringsDatabase.Items.DartBoard:
                alertText.SetActive(false);
                attachButton.interactable = true;

                currentInt = currentTower.GetComponent<Tower>().CriticalChance;
                changeInt = (int)item.Changes[0];
                SetStatChange("Critical Chance", currentInt, currentInt + changeInt, true);
                break;
            case StringsDatabase.Items.Scope:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<Tower>().CriticalChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Critical Chance", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<DamageTower>().CriticalDamage;
                    changeInt = (int)ReferencesManager.GameManager.FormulaPercentage(currentTower.GetComponent<Tower>().Damage, currentTower.GetComponent<DamageTower>().CriticalPercentage + (int)item.Changes[1]);
                    SetStatChange("Critical Damage", currentInt, changeInt, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.BoxOfBullets:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<DamageTower>().TwoRoundBurstChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Two Round Burst Chance", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<DamageTower>().ThreeRoundBurstChance;
                    changeInt = (int)item.Changes[1];
                    SetStatChange("Three Round Burst Chance", currentInt, currentInt + changeInt, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Matches:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<DamageTower>().BurnChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Burn Chance", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<DamageTower>().BurnDamage;
                    changeInt = (int)item.Changes[1];
                    SetStatChange("Burn Damage", currentInt, currentInt + changeInt, false);

                    currentFloat = currentTower.GetComponent<DamageTower>().BurnDuration;
                    changeFloat = (float)item.Changes[2];
                    SetStatChange("Burn Duration", currentInt, currentInt + changeInt, false);

                    if (currentTower.GetComponent<DamageTower>().BurnTickRate == 0)
                    {
                        decimal currentDecimal = (decimal)currentTower.GetComponent<DamageTower>().BurnTickRate;
                        changeFloat = (float)item.Changes[3];
                        decimal total = 1 / (currentDecimal - (decimal)changeFloat);
                        total *= -1;
                        SetStatChange("Burn Tick Rate", currentDecimal, total, false);
                    }

                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Blueprint:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = ReferencesManager.GameManager.bonusDamageTowerDamage;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Bonus Damage", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.RedBall:
                if (currentTower.GetComponent<DamageTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<DamageTower>().SuperDamageChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Super Damage Chance", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<DamageTower>().SuperDamage;
                    changeInt = currentTower.GetComponent<DamageTower>().Damage * 5;
                    SetStatChange("Super Damage", currentInt, currentInt + changeInt, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Damage Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Snowflake:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentFloat = currentTower.GetComponent<FreezeTower>().SlowDuration;
                    changeFloat = (float)item.Changes[0];
                    SetStatChange("Slow Duration", currentFloat, currentFloat + changeFloat, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.LiquidNitrogen:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentFloat = currentTower.GetComponent<FreezeTower>().SlowEffect;
                    changeFloat = (float)item.Changes[0];
                    SetStatChange("Slow Effect", currentFloat, currentFloat + changeFloat, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.IceCube:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    if (currentTower.GetComponent<FreezeTower>().IceDamage > 0)
                    {
                        currentInt = currentTower.GetComponent<FreezeTower>().IceDamage;
                        changeInt = (int)item.Changes[0];
                        SetStatChange("Ice Damage", currentInt, currentInt + changeInt, true);
                    }
                    else
                    {
                        currentInt = currentTower.GetComponent<FreezeTower>().FrostbiteDamage;
                        changeInt = (int)item.Changes[1];
                        SetStatChange("Frostbite Damage", currentInt, currentInt + changeInt, true);
                    }
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Snowball:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<FreezeTower>().SnowballChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Snowball Chance", currentInt, currentInt + changeInt, true);

                    currentFloat = currentTower.GetComponent<FreezeTower>().SnowballStunDuration;
                    changeFloat = (float)item.Changes[1];
                    SetStatChange("Snowball Stun Duration", currentFloat, currentFloat + changeFloat, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.FrozenBottle:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<FreezeTower>().IcicleChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Icicle Spawn Chance", currentInt, currentInt + changeInt, true);

                    if (currentTower.GetComponent<FreezeTower>().IcicleDamage == 0)
                    {
                        currentInt = currentTower.GetComponent<FreezeTower>().IcicleDamage;
                        changeInt = 15;
                        SetStatChange("Icicle Damage", currentInt, currentInt + changeInt, false);
                    }
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.IceCream:
                if (currentTower.GetComponent<FreezeTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<FreezeTower>().ImmobilizeChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Immobilize Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Freeze Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.PoisonVial:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<PoisonTower>().PoisonDamageOverTime;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Poison Damage Over Time", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.HazardSign:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentFloat = currentTower.GetComponent<PoisonTower>().PoisonDuration;
                    changeFloat = (float)item.Changes[0];
                    SetStatChange("Poison Duration", currentFloat, currentFloat + changeFloat, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.MoldyCheese:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    decimal currentDecimal = (decimal)currentTower.GetComponent<PoisonTower>().PoisonTickRate;
                    changeFloat = (float)item.Changes[0];
                    decimal total = 1 / (currentDecimal - (decimal)changeFloat);
                    SetStatChange("Poison Tick Rate", 1 / currentDecimal, total, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.SnotTissue:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<PoisonTower>().DoubleTickRateChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Poison Double Tick Rate Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Fungus:
                if (currentTower.GetComponent<PoisonTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = ReferencesManager.GameManager.PoisonCriticalChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Poison Critical Damage Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Poison Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Cannonball:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<Tower>().Damage;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Damage", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<BombTower>().SplashDamage;
                    changeInt = (int)item.Changes[1];
                    SetStatChange("Splash Damage", currentInt, currentInt + changeInt, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Dynamite:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentFloat = currentTower.GetComponent<BombTower>().SplashRadius;
                    changeFloat = (float)item.Changes[0];
                    SetStatChange("Splash Radius", currentFloat, currentFloat + changeFloat, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.TNTBox:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<BombTower>().ExplosionDelay;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Explosion Delay", currentInt, currentInt + changeInt, true);

                    currentInt = currentTower.GetComponent<BombTower>().SplashDamage;
                    changeFloat = ReferencesManager.GameManager.FormulaPercentage(currentTower.GetComponent<BombTower>().SplashDamage, (int)item.Changes[1]);
                    SetStatChange("Splash Damage", currentInt, Mathf.CeilToInt(changeFloat), false);

                    currentFloat = currentTower.GetComponent<BombTower>().SplashRadius;
                    changeFloat = ReferencesManager.GameManager.FormulaPercentage(currentTower.GetComponent<BombTower>().SplashRadius, (int)item.Changes[2]);
                    SetStatChange("Splash Radius", currentFloat, changeFloat, false);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Nuke:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<BombTower>().NukeChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Nuke Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.RPG:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<BombTower>().RocketChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Rocket Chance", currentInt, currentInt + changeInt, true);

                    if (currentTower.GetComponent<BombTower>().RocketDamage == 0)
                    {
                        currentInt = currentTower.GetComponent<BombTower>().RocketDamage;
                        changeInt = 15;
                        SetStatChange("Rocket Damage", currentInt, currentInt + changeInt, false);
                    }
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
            case StringsDatabase.Items.Firework:
                if (currentTower.GetComponent<BombTower>())
                {
                    alertText.SetActive(false);
                    attachButton.interactable = true;

                    currentInt = currentTower.GetComponent<BombTower>().DoubleExplosionChance;
                    changeInt = (int)item.Changes[0];
                    SetStatChange("Double Explosion Chance", currentInt, currentInt + changeInt, true);
                }
                else
                {
                    if (statsSection.transform.childCount > 0)
                    {
                        for (int i = 0; i < statsSection.transform.childCount; i++)
                        {
                            Destroy(statsSection.transform.GetChild(i).gameObject);
                        }
                    }

                    alertText.SetActive(true);
                    alertText.GetComponent<TextMeshProUGUI>().text = "Can only be placed on Bomb Towers";
                    attachButton.interactable = false;
                }
                break;
        }
    }

    void SetStatChange(string statName, object oldStat, object newStat, bool destroyPrevious)
    {
        if (destroyPrevious)
        {
            if (statsSection.transform.childCount > 0)
            {
                for (int i = 0; i < statsSection.transform.childCount; i++)
                {
                    Destroy(statsSection.transform.GetChild(i).gameObject);
                }
            }
        }

        string formattedOldStat = string.Empty;
        string formattedNewStat = string.Empty;
        GameObject statChange = null;

        if (oldStat is float)
        {
            formattedOldStat = oldStat.ToString();
            double number = Convert.ToDouble(formattedOldStat);
            if ((float)oldStat % 1 != 0)
            {
                formattedOldStat = number.ToString("F2");
            }
            else
            {
                formattedOldStat = number.ToString("0");
            }
        }

        if (newStat is float)
        {
            formattedNewStat = newStat.ToString();
            double number = Convert.ToDouble(formattedNewStat);
            if ((float)newStat % 1 != 0)
            {
                formattedNewStat = number.ToString("F2");
            }
            else
            {
                formattedNewStat = number.ToString("0");
            }
        }

        if (oldStat is decimal)
        {
            formattedOldStat = oldStat.ToString();
            double number = Convert.ToDouble(formattedOldStat);
            if ((decimal)oldStat % 1 != 0)
            {
                formattedOldStat = number.ToString("0.##");
            }
            else
            {
                formattedOldStat = number.ToString("0");
            }
        }

        if (newStat is decimal)
        {
            formattedNewStat = newStat.ToString();
            double number = Convert.ToDouble(formattedNewStat);
            if ((decimal)newStat % 1 != 0)
            {
                formattedNewStat = number.ToString("0.##");
            }
            else
            {
                formattedNewStat = number.ToString("0");
            }
        }

        if (!string.IsNullOrEmpty(formattedOldStat) && !string.IsNullOrEmpty(formattedNewStat))
        {
            //Set sprite later on
            statChange = Instantiate(statUI, statsSection.transform.position, Quaternion.identity, statsSection.transform);
            statChange.transform.Find("ItemOldNewStat_Title").GetComponent<TextMeshProUGUI>().text = statName;
            statChange.transform.Find("ItemOldNewStat").GetComponent<TextMeshProUGUI>().text = formattedOldStat + " -> <color=green>" + formattedNewStat + "</color>";
        }
        else
        {
            //Set sprite later on
            statChange = Instantiate(statUI, statsSection.transform.position, Quaternion.identity, statsSection.transform);
            statChange.transform.Find("ItemOldNewStat_Title").GetComponent<TextMeshProUGUI>().text = statName;
            statChange.transform.Find("ItemOldNewStat").GetComponent<TextMeshProUGUI>().text = oldStat.ToString() + " -> <color=green>" + newStat.ToString() + "</color>";
        }

        if (statChange != null)
        {
            switch (statName)
            {
                case "Fire Rate":
                    statChange.transform.Find("ItemOldNewStat").GetComponent<TextMeshProUGUI>().text = formattedOldStat + " / s -> <color=green>" + formattedNewStat + " / s</color>";
                    break;
                case "Range":
                case "Splash Radius":
                    statChange.transform.Find("ItemOldNewStat").GetComponent<TextMeshProUGUI>().text = oldStat.ToString() + " m -> <color=green>" + newStat.ToString() + " m</color>";
                    break;
                case "Critical Chance":
                case "Two Round Burst Chance":
                case "Three Round Burst Chance":
                case "Burn Chance":
                case "Super Damage Chance":
                case "Slow Effect":
                case "Snowball Chance":
                case "Icicle Spawn Chance":
                case "Immobilize Chance":
                case "Poison Double Tick Rate Chance":
                case "Poison Critical Damage Chance":
                case "Rocket Chance":
                case "Double Explosion Chance":
                    statChange.transform.Find("ItemOldNewStat").GetComponent<TextMeshProUGUI>().text = oldStat.ToString() + " % -> <color=green>" + newStat.ToString() + " %</color>";
                    break;
                case "Burn Duration":
                case "Slow Duration":
                case "Snowball Stun Duration":
                case "Poison Duration":
                    statChange.transform.Find("ItemOldNewStat").GetComponent<TextMeshProUGUI>().text = oldStat.ToString() + " s -> <color=green>" + newStat.ToString() + " s</color>";
                    break;
                case "Burn Tick Rate":
                case "Poison Tick Rate":
                    statChange.transform.Find("ItemOldNewStat").GetComponent<TextMeshProUGUI>().text = formattedOldStat.ToString() + " times / s -> <color=green>" + formattedNewStat.ToString() + " times / s</color>";
                    break;
                case "Explosion Delay":
                    statChange.transform.Find("ItemOldNewStat").GetComponent<TextMeshProUGUI>().text = oldStat.ToString() + " s -> <color=red>" + newStat.ToString() + " s</color>";
                    break;
            }
        }
    }

    void SetItemsTowerSlots(ItemAttached[] itemsAttached, int itemSlotNumber)
    {
        for (int i = 0; i < itemsAttached.Length; i++)
        {
            if (itemSlotsInItems[i].name.Contains(itemSlotNumber.ToString()))
            {
                itemSlotsInItems[i].transform.Find("Selection").gameObject.SetActive(true);
                itemSlotSelected = itemSlotsInItems[i];
            }
            else
            {
                itemSlotsInItems[i].transform.Find("Selection").gameObject.SetActive(false);
            }

            if (itemsAttached[i] != null)
            {
                itemSlotsInItems[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemsAttached[i].Item.ItemName;
                itemSlotsInItems[i].transform.Find("Plus").gameObject.SetActive(false);
            }
            else
            {
                itemSlotsInItems[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = string.Empty;
                itemSlotsInItems[i].transform.Find("Plus").gameObject.SetActive(true);
            }
        }
    }

    void SetSlotImage(bool isRemoving, bool isNew, bool isSwapping, Sprite sprite, string itemName)
    {
        if(!isRemoving && isNew)
        {
            itemSlotSelected.transform.Find("Plus").gameObject.SetActive(false);
            itemSlotSelected.transform.Find("ItemIcon").gameObject.SetActive(true);
            itemSlotSelected.transform.Find("ItemIcon").GetComponent<Image>().sprite = sprite;
            itemSlotSelected.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = itemName;
        }
        else if(isRemoving && !isNew)
        {
            itemSlotSelected.transform.Find("Plus").gameObject.SetActive(true);
            itemSlotSelected.transform.Find("ItemIcon").gameObject.SetActive(false);
        }
        else if(!isNew && isSwapping)
        {
            itemSlotSelected.transform.Find("ItemIcon").GetComponent<Image>().sprite = sprite;
            itemSlotSelected.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = itemName;
        }
    }

    void SetSlotImages(Tower currentTower)
    {
        for (int i = 0; i < currentTower.ItemsAttached.Length; i++)
        {
            if (currentTower.ItemsAttached[i] == null)
            {
                itemSlotsInItems[i].transform.Find("Plus").gameObject.SetActive(true);
                itemSlotsInItems[i].transform.Find("ItemIcon").gameObject.SetActive(false);
            }
            else
            {
                var sprite = ReferencesManager.SpriteManager.GetSpriteByItemName(currentTower.ItemsAttached[i].Item.ItemName);
                itemSlotsInItems[i].transform.Find("Plus").gameObject.SetActive(false);
                itemSlotsInItems[i].transform.Find("ItemIcon").gameObject.SetActive(true);
                itemSlotsInItems[i].transform.Find("ItemIcon").GetComponent<Image>().sprite = sprite;
            }
        }
    }

    void SetStatsAccordingToItem(string itemName)
    {
        var currentTower = ReferencesManager.GameManager.currentTower;
        var allItems = ReferencesManager.ItemsManager.AllItems;

        switch (itemName)
        {
            //General
            case StringsDatabase.Items.Weight:
                currentTower.GetComponent<Tower>().Damage += (int)allItems.Find(a => a.ItemName == itemName).Changes[0];
                break;
            case StringsDatabase.Items.HotPepper:
                currentTower.GetComponent<Tower>().FireRate -= (float)allItems.Find(a => a.ItemName == itemName).Changes[0];
                break;
            case StringsDatabase.Items.Lens:
                currentTower.GetComponent<Tower>().Range += (float)allItems.Find(a => a.ItemName == itemName).Changes[0];
                break;
            case StringsDatabase.Items.Voucher:
                if(currentTower.name.Contains("DamageTower") && ReferencesManager.GameManager.DamageTowerVoucherDiscount < 6)
                {
                    ReferencesManager.GameManager.DamageTowerVoucherDiscount += (int)allItems.Find(a => a.ItemName == itemName).Changes[0];
                }
                else if (currentTower.name.Contains("FreezeTower") && ReferencesManager.GameManager.FreezeTowerVoucherDiscount < 6)
                {
                    ReferencesManager.GameManager.FreezeTowerVoucherDiscount += (int)allItems.Find(a => a.ItemName == itemName).Changes[0];
                }
                else if (currentTower.name.Contains("PoisonTower") && ReferencesManager.GameManager.PoisonTowerVoucherDiscount < 6)
                {
                    ReferencesManager.GameManager.PoisonTowerVoucherDiscount += (int)allItems.Find(a => a.ItemName == itemName).Changes[0];
                }
                else if (currentTower.name.Contains("BombTower") && ReferencesManager.GameManager.BombTowerVoucherDiscount < 6)
                {
                    ReferencesManager.GameManager.BombTowerVoucherDiscount += (int)allItems.Find(a => a.ItemName == itemName).Changes[0];
                }

                ReferencesManager.UIManager_Cost.SetupTowerCost_UI();
                break;
            case StringsDatabase.Items.PiggyBank:

                break;
            case StringsDatabase.Items.DartBoard:
            
                break;

            //Damage
            case StringsDatabase.Items.Scope:
                
                break;
            case StringsDatabase.Items.BoxOfBullets:
                
                break;
            case StringsDatabase.Items.Matches:
                
                break;
            case StringsDatabase.Items.Blueprint:
                
                break;
            case StringsDatabase.Items.RedBall:
                
                break;

            //Freeze
            case StringsDatabase.Items.Snowflake:
                
                break;
            case StringsDatabase.Items.LiquidNitrogen:
                
                break;
            case StringsDatabase.Items.IceCube:
                
                break;
            case StringsDatabase.Items.Snowball:
               
                break;
            case StringsDatabase.Items.FrozenBottle:
                
                break;
            case StringsDatabase.Items.IceCream:
                
                break;

            //Poison
            case StringsDatabase.Items.PoisonVial:
                
                break;
            case StringsDatabase.Items.HazardSign:
                
                break;
            case StringsDatabase.Items.MoldyCheese:
                
                break;
            case StringsDatabase.Items.SnotTissue:
                
                break;
            case StringsDatabase.Items.Fungus:
                
                break;

            //Bomb
            case StringsDatabase.Items.Cannonball:
                
                break;
            case StringsDatabase.Items.Dynamite:
                
                break;
            case StringsDatabase.Items.TNTBox:
                
                break;
            case StringsDatabase.Items.Nuke:
                
                break;
            case StringsDatabase.Items.RPG:
                
                break;
            case StringsDatabase.Items.Firework:
                
                break;
        }
    }

    #region OnClick
    public void OnClick_ShowItemSection(GameObject itemSlot)
    {
        itemSection.SetActive(true);
        itemInfoSection.SetActive(false);

        var currentTower = ReferencesManager.GameManager.currentTower.GetComponent<Tower>();

        this.itemSlot = itemSlot;

        int itemSlotNumber = int.Parse(itemSlot.name.Substring(4));

        SetItemsTowerSlots(ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached, itemSlotNumber);

        SetSlotImages(currentTower);
    }

    public void OnClick_BackButton()
    {
        itemSection.SetActive(false);
        isItemSelected = false;
        itemInfoSection.SetActive(false);
        itemName = string.Empty;

        itemSlotSelected.transform.Find("Selection").gameObject.SetActive(false);
        itemSlotSelected = null;
    }

    public void OnClick_SelectTab(GameObject tab)
    {
        NewTabSelected(tab);
    }

    public void OnClick_Item(string itemName)
    {
        isItemSelected = true;
        itemInfoSection.SetActive(true);
        this.itemName = itemName;

        Item item = ReferencesManager.ItemsManager.AllItems.Find(a => a.ItemName == itemName);

        SetInfo(item.ItemName, item.ItemDescription);

        if (!ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached.All(a => a == null))
        {
            bool containsInList = ReferencesManager.GameManager.currentTower
                .GetComponent<Tower>()
                .ItemsAttached
                .Any(a => a != null && a.ItemSlot.name == itemSlotSelected.name);

            if (containsInList)
            {
                attachButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Swap Item";
            }
            else
            {
                attachButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Attach";
            }
        }
    }

    public void OnClick_AttachButton()
    {
        itemInfoSection.SetActive(false);

        var currentTower = ReferencesManager.GameManager.currentTower;

        var item = ReferencesManager.ItemsManager.AllItems.Find(a => a.ItemName == itemName);
        ItemAttached itemAttached = new ItemAttached()
        {
            Item = item,
            ItemSlot = itemSlot
        };

        int itemSlotNumber = int.Parse(itemSlot.name.Substring(4));

        if (currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1] == null)
        {
            currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1] = itemAttached;
        }

        //Update list - For both Right and Left

        if (!ReferencesManager.GameManager.currentTower.GetComponent<Tower>().isRight())
        {
            //Update sprite on click of button
            if (ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached.Length > 0 &&
                ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1] != null &&
                ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1].ItemSlot.name == ReferencesManager.UIManager_Stat.StatItems_R[itemSlotNumber - 1].name &&
                ReferencesManager.UIManager_Stat.StatItems_R[itemSlotNumber - 1].transform.Find("Plus"))
            {
                Destroy(ReferencesManager.UIManager_Stat.StatItems_R[itemSlotNumber - 1].transform.Find("Plus").gameObject);
                GameObject itemSpriteObject = Instantiate(ReferencesManager.UIManager_Stat.itemSprite, ReferencesManager.UIManager_Stat.StatItems_R[itemSlotNumber - 1].transform.position, Quaternion.identity, ReferencesManager.UIManager_Stat.StatItems_R[itemSlotNumber - 1].transform);
                //itemSpriteObject.GetComponent<Image>().sprite = ReferencesManager.SpriteManager.GetSpriteByItemName(ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached[i].Item.ItemName);
                SetSlotImage(false, true, false, ReferencesManager.SpriteManager.GetSpriteByItemName(itemName), itemName); //This is set in Item Menu

                ReferencesManager.ItemsManager.ReduceItemFromInventory(item.ItemName, item);
                UpdateItemList(item);
            }
            else
            {
                //swap items
                var itemAttachedAlready = currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1];

                if (itemAttachedAlready.Item.ItemName != itemAttached.Item.ItemName)
                {
                    //Set new sprite
                    //ReferencesManager.UIManager_Stat.StatItems_R[itemSlotNumber - 1].transform.GetChild(0).GetComponent<Image>().sprite = ReferencesManager.SpriteManager.GetSpriteByItemName(ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1].Item.ItemName);
                    SetSlotImage(false, false, true, ReferencesManager.SpriteManager.GetSpriteByItemName(itemName), itemName);

                    //Add the item that was attached back to the list
                    ReferencesManager.ItemsManager.AddItemToInventory(itemAttachedAlready.Item.ItemName, itemAttachedAlready.Item);

                    //Add the new item to the tower
                    currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1] = itemAttached;

                    ReferencesManager.ItemsManager.ReduceItemFromInventory(item.ItemName, item);
                    UpdateItemList(item);


                    //Update List
                    UpdateItemList(itemAttachedAlready.Item, true);
                }
            }
        }
        else
        {
            //Update sprite on click of button
            if (ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached.Length > 0 &&
                ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1] != null &&
                ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1].ItemSlot.name == ReferencesManager.UIManager_Stat.StatItems_L[itemSlotNumber - 1].name &&
                ReferencesManager.UIManager_Stat.StatItems_L[itemSlotNumber - 1].transform.Find("Plus"))
            {
                Destroy(ReferencesManager.UIManager_Stat.StatItems_L[itemSlotNumber - 1].transform.Find("Plus").gameObject);
                GameObject itemSpriteObject = Instantiate(ReferencesManager.UIManager_Stat.itemSprite, ReferencesManager.UIManager_Stat.StatItems_L[itemSlotNumber - 1].transform.position, Quaternion.identity, ReferencesManager.UIManager_Stat.StatItems_L[itemSlotNumber - 1].transform);
                //itemSpriteObject.GetComponent<Image>().sprite = ReferencesManager.SpriteManager.GetSpriteByItemName(ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached[i].Item.ItemName);
                SetSlotImage(false, true, false, ReferencesManager.SpriteManager.GetSpriteByItemName(itemName), itemName); //This is set in item menu

                ReferencesManager.ItemsManager.ReduceItemFromInventory(item.ItemName, item);
                UpdateItemList(item);
            }
            else
            {
                //swap items
                var itemAttachedAlready = currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1];

                if (itemAttachedAlready.Item.ItemName != itemAttached.Item.ItemName)
                {
                    //Set new sprite
                    //ReferencesManager.UIManager_Stat.StatItems_L[itemSlotNumber - 1].transform.GetChild(0).GetComponent<Image>().sprite = ReferencesManager.SpriteManager.GetSpriteByItemName(ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1].Item.ItemName);
                    SetSlotImage(false, false, true, ReferencesManager.SpriteManager.GetSpriteByItemName(itemName), itemName);

                    //Add the item that was attached back to the list
                    ReferencesManager.ItemsManager.AddItemToInventory(itemAttachedAlready.Item.ItemName, itemAttachedAlready.Item);

                    //Add the new item to the tower
                    currentTower.GetComponent<Tower>().ItemsAttached[itemSlotNumber - 1] = itemAttached;

                    ReferencesManager.ItemsManager.ReduceItemFromInventory(item.ItemName, item);
                    UpdateItemList(item);

                    //Update List
                    UpdateItemList(itemAttachedAlready.Item, true);
                }
            }
        }

        if (itemSlotNumber == 5)
        {
            itemSlotNumber = 0;
        }

        OnClick_ItemSlotInItemMenu(itemSlotsInItems[itemSlotNumber]);
    }

    public void OnClick_ItemSlotInItemMenu(GameObject itemSlot)
    {
        //Hide the previous selection
        itemSlotSelected.transform.Find("Selection").gameObject.SetActive(false);

        //Show the new selection
        itemSlotSelected = itemSlot;
        this.itemSlot = itemSlot;
        itemSlotSelected.transform.Find("Selection").gameObject.SetActive(true);

        if (!ReferencesManager.GameManager.currentTower.GetComponent<Tower>().ItemsAttached.All(a => a == null))
        {
            bool containsInList = ReferencesManager.GameManager.currentTower
                .GetComponent<Tower>()
                .ItemsAttached
                .Any(a => a != null && a.ItemSlot.name == itemSlotSelected.name);

            if (containsInList)
            {
                attachButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Swap Item";
            }
            else
            {
                attachButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Attach";
            }
        }
    }
    #endregion
}
