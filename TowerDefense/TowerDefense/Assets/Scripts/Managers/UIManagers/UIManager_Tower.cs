using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager_Tower : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public GameObject DownArrow;
    public GameObject UpArrow;

    public bool isTowerMenuShown;

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();

        SwitchArrows(isTowerMenuShown, !isTowerMenuShown);
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
                isTowerMenuShown = false;
                SwitchArrows(false, true);
                break;
            case StringsDatabase.Buttons.UpButton:
                isTowerMenuShown = true;
                SwitchArrows(true, false);
                break;
        }
    }

    #endregion
}
