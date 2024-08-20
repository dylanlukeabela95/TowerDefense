using Strings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TMPro.Examples;
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

    public List<Tab> itemTabs = new List<Tab>();

    [Header("Tabs")]
    public List<GameObject> tabsObject = new List<GameObject>();

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

    void UpdateItemList()
    {
        var itemDisplay_General = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_General").ItemDisplay;
        var itemDisplay_Damage = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_Damage").ItemDisplay;
        var itemDisplay_Freeze = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_Freeze").ItemDisplay;
        var itemDisplay_Poison = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_Poison").ItemDisplay;
        var itemDisplay_Bomb = itemTabs.Find(a => a.ItemDisplay.name == "ItemDisplay_Bomb").ItemDisplay;

        foreach (var item in ReferencesManager.ItemsManager.GeneralItems)
        {
            GameObject itemGeneral = Instantiate(itemIcon, itemDisplay_General.transform.position, Quaternion.identity, itemDisplay_General.transform);
            itemGeneral.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.ItemName;

            if(item.ItemCount > 1)
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

    void SetInfo(string itemName, string itemDescription)
    {
        itemInfoSection.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = itemName;
        itemInfoSection.transform.Find("ItemDescription").GetComponent<TextMeshProUGUI>().text = itemDescription;

        switch(itemName)
        {
            case StringsDatabase.Items.Weight:
                var damage = ReferencesManager.GameManager.currentTower.GetComponent<Tower>().Damage;
                var change = ReferencesManager.ItemsManager.AllItems.Find(a => a.ItemName == StringsDatabase.Items.Weight).Changes[0];
                SetStatChange("Damage", damage, damage + (int)change);
                break;
        }
    }

    void SetStatChange(string statName, int oldStat, int newStat)
    {
        if(statsSection.transform.childCount > 0)
        {
            for (int i = 0; i < statsSection.transform.childCount; i++)
            {
                Destroy(statsSection.transform.GetChild(i).gameObject);

            }
        }

        //Set sprite later on
        GameObject statChange = Instantiate(statUI, statsSection.transform.position, Quaternion.identity, statsSection.transform);
        statChange.transform.Find("ItemOldNewStat_Title").GetComponent<TextMeshProUGUI>().text = statName;
        statChange.transform.Find("ItemOldNewStat").GetComponent<TextMeshProUGUI>().text = oldStat.ToString() + " -> " + "<color=green>" + newStat.ToString() + "</color>";
    }

    #region OnClick
    public void OnClick_ShowItemSection(GameObject itemSlot)
    {
        itemSection.SetActive(true);
        itemInfoSection.SetActive(false);

        this.itemSlot = itemSlot;
    }

    public void OnClick_BackButton()
    {
        itemSection.SetActive(false);
        isItemSelected = false;
        itemInfoSection.SetActive(false);
    }
    
    public void OnClick_SelectTab(GameObject tab)
    {
        NewTabSelected(tab);
    }

    public void OnClick_Item(string itemName)
    {
        isItemSelected = true;
        itemInfoSection.SetActive(true);

        Item item = ReferencesManager.ItemsManager.AllItems.Find(a => a.ItemName == itemName);

        SetInfo(item.ItemName, item.ItemDescription);
    }

    #endregion
}
