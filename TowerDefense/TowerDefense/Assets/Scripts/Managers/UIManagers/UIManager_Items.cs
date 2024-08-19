using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Tab
{
    public GameObject TabObject { get; set; }
    public GameObject ItemDisplay {  get; set; }
    public bool isSelected { get; set; }
}

public class UIManager_Items : MonoBehaviour
{
    [Header("Item Section")]
    public GameObject itemSection;

    [Header("Item Info Section")]
    public GameObject itemInfoSection;

    [Header("Item Slot")]
    public GameObject itemSlot;

    [Header("Item Displays")]
    public List<GameObject> itemDisplays = new List<GameObject>();

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

    public void OnClick_Item()
    {
        isItemSelected = true;
    }

    #endregion
}
