using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager_SpeechBubble : MonoBehaviour
{
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
