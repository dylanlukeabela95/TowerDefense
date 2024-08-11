using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager_SpeechBubble : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public GameObject SpeechBubble;
    public TextMeshProUGUI SpeechBubbleTitle;
    public TextMeshProUGUI SpeechBubbleDescription;
    public TextMeshProUGUI SpeechBubbleDamage;
    public TextMeshProUGUI SpeechBubbleFireRate;
    public TextMeshProUGUI SpeechBubbleRange;

    // Start is called before the first frame update
    void Start()
    {
        ShowHideSpeechBubble(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ReferencesManager.UIManager_Tower.IsTowerMenuShown)
        {
            Vector3 pos = new Vector3(Input.mousePosition.x - 110, Input.mousePosition.y + 110, Input.mousePosition.z);
            SpeechBubble.transform.position = pos;
        }
    }

    public void ShowHideSpeechBubble(bool canShow)
    {
        SpeechBubble.SetActive(canShow);
    }

    public void UpdateSpeechBubble(string title, string description, string damage, string fireRate, string range)
    {
        SpeechBubbleTitle.text = title;
        SpeechBubbleDescription.text = description;
        SpeechBubbleDamage.text = damage;
        SpeechBubbleFireRate.text = fireRate;
        SpeechBubbleRange.text = range;
    }
}
