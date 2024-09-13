using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuButtonHoverListener : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ReferencesManager ReferencesManager;

    public Color32 defaultColor;
    public Color32 hoverColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(ReferencesManager.UIManager_Pause.isOptionsButtonSelected && this.name == StringsDatabase.PauseMenu.OptionsButton)
        {
        }
        else
        {
            GetComponent<Image>().color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ReferencesManager.UIManager_Pause.isOptionsButtonSelected && this.name == StringsDatabase.PauseMenu.OptionsButton)
        {
        }
        else
        {
            GetComponent<Image>().color = defaultColor;
        }
    }
}
