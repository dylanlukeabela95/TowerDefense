using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public ReferencesManager ReferencesManager;
    UIHoverListener uiListener;


    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
        uiListener = GameObject.Find(StringsDatabase.UI.Canvas).GetComponent<UIHoverListener>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!uiListener.isUIOverride)
        {
            ReferencesManager.TowerManager.PlaceTower();
        }
    }
}
