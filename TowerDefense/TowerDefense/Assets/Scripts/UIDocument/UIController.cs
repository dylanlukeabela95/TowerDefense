using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //public Button startButton;
    //public Button messageButton;
    //public Label messageText;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    var root = GetComponent<UIDocument>().rootVisualElement;

    //    startButton = root.Q<Button>("start-button");
    //    messageButton = root.Q<Button>("message-button");
    //    messageText = root.Q<Label>("message-text");

    //    startButton.clicked += StartButtonPressed;
    //    messageButton.clicked += MessageButtonPressed;
    //}

    //void StartButtonPressed()
    //{
    //    Debug.Log("Start Button Clicked");
    //}

    //void MessageButtonPressed()
    //{
    //    messageText.text = "Message Button has been clicked";
    //    messageText.style.display = DisplayStyle.Flex;
    //}

    public Button resumeButton;
    public Button optionsButton;

    public VisualElement pauseMenuSectionRoot;
    public VisualElement optionsMenuSectionRoot;

    public GameObject pauseMenuSection;
    public GameObject optionsSection;

    private bool isPaused;
    private bool isOptions;

    private void Start()
    {
        var pauseMenuRoot = pauseMenuSection.GetComponent<UIDocument>().rootVisualElement;
        var optionsRoot = optionsSection.GetComponent<UIDocument>().rootVisualElement;

        resumeButton = pauseMenuRoot.Q<Button>("resume-button");
        optionsButton = pauseMenuRoot.Q<Button>("options-button");

        resumeButton.clicked += ResumeButtonPressed;
        optionsButton.clicked += OptionsButtonPressed;

        pauseMenuSectionRoot = pauseMenuRoot.Q<VisualElement>("pause-menu-section-global");
        pauseMenuSectionRoot.style.display = DisplayStyle.None;

        optionsMenuSectionRoot = optionsRoot.Q<VisualElement>("options-menu-section-global");
        optionsMenuSectionRoot.style.display = DisplayStyle.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                pauseMenuSectionRoot.style.display = DisplayStyle.Flex;
            }
            else
            {
                pauseMenuSectionRoot.style.display = DisplayStyle.None;

                if(isOptions)
                {
                    optionsMenuSectionRoot.style.display = DisplayStyle.None;
                }
            }
        }
    }

    void ResumeButtonPressed()
    {
        isPaused = !isPaused;
        pauseMenuSectionRoot.style.display = DisplayStyle.None;
    }

    void OptionsButtonPressed()
    {
        isOptions = true;
        pauseMenuSectionRoot.style.display = DisplayStyle.None;
        optionsMenuSectionRoot.style.display = DisplayStyle.Flex;
    }
}
