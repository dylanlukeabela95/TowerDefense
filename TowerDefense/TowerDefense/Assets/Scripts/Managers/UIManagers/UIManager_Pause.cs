using Strings;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class UIManager_Pause : MonoBehaviour
{
    [SerializeField]
    private ReferencesManager ReferencesManager;

    private bool isPauseMenuShowing;
    private bool isDamageTowerInfoShowing;
    private bool isFreezeTowerInfoShowing;
    private bool isPoisonTowerInfoShowing;
    private bool isBombTowerInfoShowing;

    public bool isOptionsButtonSelected;
    public bool isDamageNumbersButtonSelected;
    public bool isMusicVolumeButtonSelected;
    public bool isSoundEffectVolumeButtonSelected;
    public bool isTowerInfoSelected;

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

    [Header("Music Volume Section")]
    public GameObject musicVolumeSection;
    public TextMeshProUGUI musicVolumeAmount;
    public RectTransform musicVolumeBar;

    [Header("Sound Effect Volume Section")]
    public GameObject soundEffectVolumeSection;
    public TextMeshProUGUI soundEffectVolumeAmount;
    public RectTransform soundEffectVolumeBar;

    [Header("Tower Info Section")]
    public GameObject towerInfoSection;

    [Header("Tower Info SubStats")]
    public GameObject damageTowerSubStats;
    public GameObject freezeTowerSubStats;
    public GameObject poisonTowerSubStats;
    public GameObject bombTowerSubStats;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuSection.SetActive(false);
        optionsSection.SetActive(false);
        ShowOptionsSection(false, false, false);
        towerInfoSection.SetActive(false);
        damageTowerSubStats.SetActive(false);
        freezeTowerSubStats.SetActive(false);
        poisonTowerSubStats.SetActive(false);
        bombTowerSubStats.SetActive(false);

        SetStats(StringsDatabase.TowerNames.DamageTower);
        SetStats(StringsDatabase.TowerNames.FreezeTower);
        SetStats(StringsDatabase.TowerNames.PoisonTower);
        SetStats(StringsDatabase.TowerNames.BombTower);

        SetDamageNumbersCheckmark();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    AlterPauseMenu();
        //}
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

                if (isDamageNumbersButtonSelected)
                {
                    isDamageNumbersButtonSelected = false;
                    damageNumbersSection.SetActive(false);
                }
                else if(isMusicVolumeButtonSelected)
                {
                    isMusicVolumeButtonSelected = false;
                    musicVolumeSection.SetActive(false);
                }
                else if(isSoundEffectVolumeButtonSelected)
                {
                    isSoundEffectVolumeButtonSelected = false;
                    soundEffectVolumeSection.SetActive(false);
                }
            }
            else if(isTowerInfoSelected)
            {
                isTowerInfoSelected = false;

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

    void ChangeBorder(GameObject button)
    {
        if (button.GetComponent<Image>().color == button.GetComponent<PauseMenuButtonHoverListener>().hoverColor)
        {
            button.GetComponent<Image>().color = button.GetComponent<PauseMenuButtonHoverListener>().defaultColor;
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

    void ShowOptionsSection(bool isDamageNumberSection, bool isMusicVolumeSection, bool isSoundEffectVolumeSection)
    {
        damageNumbersSection.SetActive(isDamageNumberSection);
        musicVolumeSection.SetActive(isMusicVolumeSection);
        soundEffectVolumeSection.SetActive(isSoundEffectVolumeSection);
    }

    void UpdateVolume(TextMeshProUGUI volumeText, int volume, RectTransform volumeBar)
    {
        volumeText.text = volume.ToString();

        Vector2 size = volumeBar.sizeDelta;

        // Set the new width while keeping the current height
        size.x = volume * 2;
        volumeBar.sizeDelta = size;
    }

    void SetStats(string towerName)
    {
        switch(towerName)
        {
            case StringsDatabase.TowerNames.DamageTower:
                damageTowerSubStats.transform.Find("Stats").transform.Find("Stat_Damage").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Damage].ToString();
                damageTowerSubStats.transform.Find("Stats").transform.Find("Stat_FireRate").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = (1 * 1.0f / (float)ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.FireRate]).ToString("F2") + " / s";
                damageTowerSubStats.transform.Find("Stats").transform.Find("Stat_Range").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Range].ToString() + " m";
                damageTowerSubStats.transform.Find("Stats").transform.Find("Stat_Cost").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = ReferencesManager.TowerManager.DamageStats[StringsDatabase.Stats.Cost].ToString();
                break;

            case StringsDatabase.TowerNames.FreezeTower:
                freezeTowerSubStats.transform.Find("Stats").transform.Find("Stat_Damage").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Damage].ToString();
                freezeTowerSubStats.transform.Find("Stats").transform.Find("Stat_FireRate").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = (1 * 1.0f / (float)ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.FireRate]).ToString("F2") + " / s";
                freezeTowerSubStats.transform.Find("Stats").transform.Find("Stat_Range").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Range].ToString() + " m";
                freezeTowerSubStats.transform.Find("Stats").transform.Find("Stat_Cost").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.Cost].ToString();
                freezeTowerSubStats.transform.Find("Stats").transform.Find("Stat_IceDamage").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.IceDamage].ToString();
                freezeTowerSubStats.transform.Find("Stats").transform.Find("Stat_SlowDuration").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.SlowDuration].ToString() + " s";
                freezeTowerSubStats.transform.Find("Stats").transform.Find("Stat_SlowEffect").transform.Find("Background_Inner").transform.Find("StatValue").GetComponent<TextMeshProUGUI>().text = ReferencesManager.TowerManager.FreezeStats[StringsDatabase.Stats.SlowEffect].ToString() + " %";
                break;
        }
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

        if(isTowerInfoSelected)
        {
            isTowerInfoSelected = false;
            towerInfoSection.SetActive(false);
            ChangeBorder(mainButtons.Find(a => a.name == StringsDatabase.PauseMenu.TowerInfoButton));
        }
    }

    public void OnClick_DamageNumbersButton(GameObject damageNumbersButton)
    {
        isDamageNumbersButtonSelected = true;

        if(isMusicVolumeButtonSelected)
        {
            isMusicVolumeButtonSelected = false;
            optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.MusicVolumeButton).GetComponent<Image>().color = optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.MusicVolumeButton).GetComponent<PauseMenuButtonHoverListener>().defaultColor;
        }

        if (isSoundEffectVolumeButtonSelected)
        {
            isSoundEffectVolumeButtonSelected = false;
            optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.SoundEffectVolumeButton).GetComponent<Image>().color = optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.SoundEffectVolumeButton).GetComponent<PauseMenuButtonHoverListener>().defaultColor;
        }

        ShowOptionsSection(true, false, false);
    }

    public void OnClick_DamageNumbersCheckbox()
    {
        showDamageNumbers = !showDamageNumbers;
        SetDamageNumbersCheckmark();
    }

    public void OnClick_MusicVolumeButton()
    {
        if(isDamageNumbersButtonSelected)
        {
            isDamageNumbersButtonSelected = false;
            optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.DamageNumbersButton).GetComponent<Image>().color = optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.DamageNumbersButton).GetComponent<PauseMenuButtonHoverListener>().defaultColor;
        }

        if(isSoundEffectVolumeButtonSelected)
        {
            isSoundEffectVolumeButtonSelected = false;
            optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.SoundEffectVolumeButton).GetComponent<Image>().color = optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.SoundEffectVolumeButton).GetComponent<PauseMenuButtonHoverListener>().defaultColor;
        }

        isMusicVolumeButtonSelected = true;
        ShowOptionsSection(false, true, false);
        UpdateVolume(musicVolumeAmount, ReferencesManager.SoundManager.musicVolume, musicVolumeBar);
    }

    public void OnClick_MusicVolume(GameObject button)
    {
        switch(button.name)
        {
            case "Add":
                ReferencesManager.SoundManager.AlterVolume(true, false, true, false);
                break;

            case "Subtract":
                ReferencesManager.SoundManager.AlterVolume(true, false, false, true);
                break;
        }

        UpdateVolume(musicVolumeAmount, ReferencesManager.SoundManager.musicVolume, musicVolumeBar);
    }

    public void OnClick_SoundEffectVolume(GameObject button)
    {
        switch (button.name)
        {
            case "Add":
                ReferencesManager.SoundManager.AlterVolume(false, true, true, false);
                break;

            case "Subtract":
                ReferencesManager.SoundManager.AlterVolume(false, true, false, true);
                break;
        }

        UpdateVolume(musicVolumeAmount, ReferencesManager.SoundManager.musicVolume, musicVolumeBar);
    }
    
    public void OnClick_SoundEffectVolumeButton()
    {
        if (isDamageNumbersButtonSelected)
        {
            isDamageNumbersButtonSelected = false;
            optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.DamageNumbersButton).GetComponent<Image>().color = optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.DamageNumbersButton).GetComponent<PauseMenuButtonHoverListener>().defaultColor;
        }

        if (isMusicVolumeButtonSelected)
        {
            isMusicVolumeButtonSelected = false;
            optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.MusicVolumeButton).GetComponent<Image>().color = optionsButtons.Find(a => a.name == StringsDatabase.PauseMenu.MusicVolumeButton).GetComponent<PauseMenuButtonHoverListener>().defaultColor;
        }

        isSoundEffectVolumeButtonSelected = true;
        ShowOptionsSection(false, false, true);
        UpdateVolume(soundEffectVolumeAmount, ReferencesManager.SoundManager.soundEffectVolume, soundEffectVolumeBar);
    }

    public void OnClick_TowerInfoButton()
    {
        isTowerInfoSelected = true;
        towerInfoSection.SetActive(true);
        ChangeSection(mainButtonSection, leftSection);
        ChangeSection(towerInfoSection, middleSection);

        if(isOptionsButtonSelected)
        {
            isOptionsButtonSelected = false;
            optionsSection.SetActive(false);
            ChangeBorder(optionsButtons);
            ChangeBorder(mainButtons.Find(a => a.name == StringsDatabase.PauseMenu.OptionsButton));
        }
    }

    public void OnClick_DamageTowerInfo()
    {
        isDamageTowerInfoShowing = !isDamageTowerInfoShowing;
        damageTowerSubStats.SetActive(isDamageTowerInfoShowing);

        if(isFreezeTowerInfoShowing)
        {
            isFreezeTowerInfoShowing = false;
            freezeTowerSubStats.SetActive(isFreezeTowerInfoShowing);
        }
        else if(isPoisonTowerInfoShowing)
        {
            isPoisonTowerInfoShowing = false;
            poisonTowerSubStats.SetActive(isPoisonTowerInfoShowing);
        }
        else if(isBombTowerInfoShowing)
        {
            isBombTowerInfoShowing = false;
            bombTowerSubStats.SetActive(isBombTowerInfoShowing);
        }
    }

    public void OnClick_FreezeTowerInfo()
    {
        isFreezeTowerInfoShowing = !isFreezeTowerInfoShowing;
        freezeTowerSubStats.SetActive(isFreezeTowerInfoShowing);

        if (isDamageTowerInfoShowing)
        {
            isDamageTowerInfoShowing = false;
            damageTowerSubStats.SetActive(isDamageTowerInfoShowing);
        }
        else if (isPoisonTowerInfoShowing)
        {
            isPoisonTowerInfoShowing = false;
            poisonTowerSubStats.SetActive(isPoisonTowerInfoShowing);
        }
        else if(isBombTowerInfoShowing)
        {
            isBombTowerInfoShowing = false;
            bombTowerSubStats.SetActive(isBombTowerInfoShowing);
        }
    }

    public void OnClick_PoisonTowerInfo()
    {
        isPoisonTowerInfoShowing = !isPoisonTowerInfoShowing;
        poisonTowerSubStats.SetActive(isPoisonTowerInfoShowing);

        if (isDamageTowerInfoShowing)
        {
            isDamageTowerInfoShowing = false;
            damageTowerSubStats.SetActive(isDamageTowerInfoShowing);
        }
        else if (isFreezeTowerInfoShowing)
        {
            isFreezeTowerInfoShowing = false;
            freezeTowerSubStats.SetActive(isFreezeTowerInfoShowing);
        }
        else if(isBombTowerInfoShowing)
        {
            isBombTowerInfoShowing = false;
            bombTowerSubStats.SetActive(isBombTowerInfoShowing);
        }
    }

    public void OnClick_BombTowerInfo()
    {
        isBombTowerInfoShowing = true;
        bombTowerSubStats.SetActive(isBombTowerInfoShowing);

        if(isDamageTowerInfoShowing)
        {
            isDamageTowerInfoShowing = false;
            damageTowerSubStats.SetActive(isDamageTowerInfoShowing);
        }
        else if(isFreezeTowerInfoShowing)
        {
            isFreezeTowerInfoShowing = false;
            freezeTowerSubStats.SetActive(isFreezeTowerInfoShowing);
        }
        else if(isPoisonTowerInfoShowing)
        {
            isPoisonTowerInfoShowing = false;
            poisonTowerSubStats.SetActive(isPoisonTowerInfoShowing);
        }
    }

    #endregion
}
