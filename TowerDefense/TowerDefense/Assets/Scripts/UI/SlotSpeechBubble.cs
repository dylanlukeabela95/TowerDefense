using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotSpeechBubble : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ReferencesManager ReferencesManager;

    public GameObject speechBubble;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI speechBubbleText;

    public float speechBubbleXLocation;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!string.IsNullOrEmpty(itemName.text))
        {
            speechBubble.SetActive(true);
            RectTransform rectTransform = speechBubble.GetComponent<RectTransform>();
            rectTransform.position = new Vector3(speechBubbleXLocation, 60.67349f, 0);
            rectTransform.anchoredPosition = rectTransform.position;

            if (itemName.text == StringsDatabase.Items.IceCube)
            {
                var iceCubeItemDescriptionSplit = ReferencesManager.ItemsManager.AllItems.Find(a => a.ItemName == StringsDatabase.Items.IceCube).ItemDescription.Split(" or ");

                if (ReferencesManager.GameManager.currentTower.GetComponent<FreezeTower>() != null && ReferencesManager.GameManager.currentTower.GetComponent<FreezeTower>().IceDamage > 0)
                {
                    speechBubbleText.text = iceCubeItemDescriptionSplit[0];
                }
                else
                {
                    speechBubbleText.text = iceCubeItemDescriptionSplit[1];
                }
            }
            else
            {
                speechBubbleText.text = ReferencesManager.ItemsManager.AllItems.Find(a => a.ItemName == itemName.text).ItemDescription;
            }

            if (itemName.text == StringsDatabase.Items.Matches)
            {
                speechBubbleText.fontSize = 5;
            }
            else if(itemName.text == StringsDatabase.Items.Scope || itemName.text == StringsDatabase.Items.Snowball || itemName.text == StringsDatabase.Items.TNTBox)
            {
                speechBubbleText.fontSize = 6;
            }
            else
            {
                speechBubbleText.fontSize = 7;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!string.IsNullOrEmpty(itemName.GetComponent<TextMeshProUGUI>().text))
        {
            speechBubble.SetActive(false);
            speechBubbleText.text = string.Empty;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speechBubble.SetActive(false);
    }
}
