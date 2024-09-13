using Strings;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIManager_Pause : MonoBehaviour
{
    private bool isPauseMenuShowing;

    public bool isOptionsButtonSelected;
    public bool isDamageNumbersButtonSelected;
    public bool showDamageNumbers;

    [Header("Pause Menu Section")]
    public GameObject pauseMenuSection;

    [Header("Button Section")]
    public GameObject mainButtonSection;
    public List<GameObject> mainButtons = new List<GameObject>();

    [Header("Sections")]
    public GameObject leftSection;
    public GameObject middleSection;
    public GameObject rightSection;

    [Header("Options Section")]
    public GameObject optionsSection;
    public List<GameObject> optionsButtons = new List<GameObject>();

    [Header("Damage Numbers Section")]
    public GameObject damageNumbersSection;

    [Header("Damage Numbers Checkbox")]
    public GameObject damageNumberCheckbox;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuSection.SetActive(false);
        optionsSection.SetActive(false);
        damageNumbersSection.SetActive(false);

        SetDamageNumbersCheckmark();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            AlterPauseMenu();
        }
    }

    void AlterPauseMenu()
    {
        isPauseMenuShowing = !isPauseMenuShowing;

        if(isPauseMenuShowing)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        pauseMenuSection.SetActive(isPauseMenuShowing);

        if (middleSection.transform.childCount == 1 && middleSection.transform.GetChild(0).name == StringsDatabase.PauseMenu.OptionsSection)
        {
            if (isOptionsButtonSelected)
            {
                isOptionsButtonSelected = false;
                ChangeBorder(optionsButtons);

                optionsSection.SetActive(false);
                optionsSection.transform.parent = pauseMenuSection.transform;
            }

            ChangeSection(mainButtonSection, middleSection);
        }

        ChangeBorder(mainButtons);
    }

    void ChangeBorder(List<GameObject> buttons)
    {
        foreach (var button in buttons)
        {
            if (button.GetComponent<Image>().color == button.GetComponent<PauseMenuButtonHoverListener>().hoverColor)
            {
                button.GetComponent<Image>().color = button.GetComponent<PauseMenuButtonHoverListener>().defaultColor;
                break;
            }
        }
    }

    void ChangeSection(GameObject buttonSection, GameObject newSection)
    {
        buttonSection.transform.parent = newSection.transform;
        buttonSection.transform.localPosition = Vector3.zero;
    }

    void SetDamageNumbersCheckmark()
    {
        damageNumberCheckbox.transform.GetChild(0).gameObject.SetActive(showDamageNumbers);
    }

    #region OnClick

    public void OnClick_ResmueButton(GameObject resumeButton)
    {
        resumeButton.GetComponent<Image>().color = resumeButton.GetComponent<PauseMenuButtonHoverListener>().defaultColor;
        AlterPauseMenu();
    }

    public void OnClick_OptionsButton(GameObject optionsButton)
    {
        isOptionsButtonSelected = true;
        ChangeSection(mainButtonSection, leftSection);

        optionsSection.SetActive(true);
        ChangeSection(optionsSection, middleSection);
    }

    public void OnClick_DamageNumbersButton(GameObject damageNumbersButton)
    {
        isDamageNumbersButtonSelected = true;
        damageNumbersSection.SetActive(true);
    }

    public void OnClick_DamageNumbersCheckbox()
    {
        showDamageNumbers = !showDamageNumbers;
        SetDamageNumbersCheckmark();
    }

    #endregion
}
