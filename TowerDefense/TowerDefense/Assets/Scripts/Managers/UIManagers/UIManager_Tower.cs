using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager_Tower : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public GameObject DownArrow;
    public GameObject UpArrow;
    
    public RectTransform TowerSelectionUI;
    
    public float AnimationDuration = 0.5f;
    
    public bool IsPanelVisible = false;

    public Vector2 OffScreenPosition;
    public Vector2 OnScreenPosition;

    public bool IsTowerMenuShown;

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();

        SwitchArrows(IsTowerMenuShown, !IsTowerMenuShown);

        OffScreenPosition = new Vector2(TowerSelectionUI.anchoredPosition.x, -TowerSelectionUI.rect.height);

        // Set the on-screen position to be where the panel is initially placed in the UI
        OnScreenPosition = TowerSelectionUI.anchoredPosition;

        // Move the panel to the off-screen position at the start
        TowerSelectionUI.anchoredPosition = OffScreenPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchArrows(bool downArrowShow, bool upArrowShow)
    {
        DownArrow.SetActive(downArrowShow);
        UpArrow.SetActive(upArrowShow); 
    }

    public void SlideUp()
    {
        StartCoroutine(Slide(TowerSelectionUI, OffScreenPosition, OnScreenPosition));
        IsPanelVisible = true;
    }

    public void SlideDown()
    {
        StartCoroutine(Slide(TowerSelectionUI, OnScreenPosition, OffScreenPosition));
        IsPanelVisible = false;
    }

    private System.Collections.IEnumerator Slide(RectTransform rectTransform, Vector2 startPos, Vector2 endPos)
    {
        float elapsedTime = 0f;

        while (elapsedTime < AnimationDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, (elapsedTime / AnimationDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
    }

    // Toggle panel visibility
    public void TogglePanel()
    {
        if (IsPanelVisible)
        {
            SlideDown();
        }
        else
        {
            SlideUp();
        }
    }

    #region OnClick

    public void OnClick_TowerButton(GameObject button)
    {
        var gameManager = ReferencesManager.GameManager;
        switch(button.name)
        {
            case StringsDatabase.TowerButtonNames.DamageTowerButton:
                gameManager.SetBooleans(true, false, false, false);
                break;
            case StringsDatabase.TowerButtonNames.FreezeTowerButton:
                gameManager.SetBooleans(false, true, false, false);
                break;
            case StringsDatabase.TowerButtonNames.PoisonTowerButton:
                gameManager.SetBooleans(false, false, true, false);
                break;
            case StringsDatabase.TowerButtonNames.BombTowerButton:
                gameManager.SetBooleans(false, false, false, true);
                break;
        }
    }

    public void OnClick_TowerUIArrow(GameObject button)
    {
        switch (button.name)
        {
            case StringsDatabase.Buttons.DownButton:
                IsTowerMenuShown = false;
                SwitchArrows(false, true);
                break;
            case StringsDatabase.Buttons.UpButton:
                IsTowerMenuShown = true;
                SwitchArrows(true, false);
                break;
        }

        TogglePanel();
    }

    #endregion
}
