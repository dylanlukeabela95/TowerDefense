using Strings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Page
{
    public int PageNumber { get; set; }
    public List<string> Stats { get; set; }

    public List<GameObject> StatsInPage { get; set; }

    public Page()
    {

    }
}

public class UIManager_Stat : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public GameObject Stat;
    public GameObject StatContainer;

    public List<Page> Pages = new List<Page>();
    public int CurrentPage = 1;

    public GameObject downArrow;
    public GameObject upArrow;

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> SetStats(TowerEnum towerEnum, int start, int end)
    {
        List<GameObject> stats = new List<GameObject>();

        if (ReferencesManager.GameManager.currentTower != null)
        {
            switch (towerEnum)
            {
                case TowerEnum.DamageTower:
                    for (int i = start; i <= end; i++)
                    {
                        GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer.transform);
                        stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.StatsManager.DamageTowerStats[i];
                        stat.name = ReferencesManager.StatsManager.DamageTowerStats[i].Replace(" ", "");
                        stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                        stats.Add(stat);
                    }
                    break;
                case TowerEnum.FreezeTower:
                    for (int i = start; i <= end; i++)
                    {
                        GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer.transform);
                        stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.StatsManager.FreezeTowerStats[i];
                        stat.name = ReferencesManager.StatsManager.FreezeTowerStats[i].Replace(" ", "");
                        stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                        stats.Add(stat);
                    }
                    break;
                case TowerEnum.PoisonTower:
                    for (int i = start; i <= end; i++)
                    {
                        GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer.transform);
                        stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.StatsManager.PoisonTowerStats[i];
                        stat.name = ReferencesManager.StatsManager.PoisonTowerStats[i].Replace(" ", "");
                        stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                        stats.Add(stat);
                    }
                    break;
                case TowerEnum.BombTower:
                    for (int i = start; i <= end; i++)
                    {
                        GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer.transform);
                        stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.StatsManager.BombTowerStats[i];
                        stat.name = ReferencesManager.StatsManager.BombTowerStats[i].Replace(" ", "");
                        stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                        stats.Add(stat);
                    }
                    break;
            }
        }

        return stats;
    }

    public void Pagination(List<string> stats, TowerEnum towerEnum)
    {
        if (stats.Count <= 3)
        {
            Page newPage = new Page()
            {
                PageNumber = 1,
                Stats = stats,
            };

            switch (towerEnum)
            {
                case TowerEnum.DamageTower:
                    newPage.StatsInPage = SetStats(towerEnum, 0, ReferencesManager.StatsManager.DamageTowerStats.Count - 1);
                    break;
                case TowerEnum.FreezeTower:
                    newPage.StatsInPage = SetStats(towerEnum, 0, ReferencesManager.StatsManager.FreezeTowerStats.Count - 1);
                    break;
                case TowerEnum.PoisonTower:
                    newPage.StatsInPage = SetStats(towerEnum, 0, ReferencesManager.StatsManager.PoisonTowerStats.Count - 1);
                    break;
                case TowerEnum.BombTower:
                    newPage.StatsInPage = SetStats(towerEnum, 0, ReferencesManager.StatsManager.BombTowerStats.Count - 1);
                    break;

            }

            Pages.Add(newPage);
        }
        else
        {
            for (int i = 0; i < stats.Count; i++)
            {
                Page newPage = new Page()
                {
                    PageNumber = i + 1,
                    Stats = new List<string>(),
                };

                var x = i + (2 * i);
                var y = i + (2 * i) + 1;
                var z = i + (2 * i) + 2;

                if (z > stats.Count)
                {
                    if (y > stats.Count)
                    {
                        if (x >= stats.Count)
                        {
                            break;
                        }
                    }
                }

                if (z < stats.Count)
                {
                    newPage.Stats.Add(stats[x]);
                    newPage.Stats.Add(stats[y]);
                    newPage.Stats.Add(stats[z]);

                    switch (towerEnum)
                    {
                        case TowerEnum.DamageTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, z);
                            break;
                        case TowerEnum.FreezeTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, z);
                            break;
                        case TowerEnum.PoisonTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, z);
                            break;
                        case TowerEnum.BombTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, z);
                            break;
                    }
                }
                else if (y < stats.Count)
                {
                    newPage.Stats.Add(stats[x]);
                    newPage.Stats.Add(stats[y]);

                    switch (towerEnum)
                    {
                        case TowerEnum.DamageTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, y);
                            break;
                        case TowerEnum.FreezeTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, y);
                            break;
                        case TowerEnum.PoisonTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, y);
                            break;
                        case TowerEnum.BombTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, y);
                            break;
                    }
                }
                else if (x <= stats.Count)
                {
                    newPage.Stats.Add(stats[x]);

                    switch (towerEnum)
                    {
                        case TowerEnum.DamageTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, x);
                            break;
                        case TowerEnum.FreezeTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, x);
                            break;
                        case TowerEnum.PoisonTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, x);
                            break;
                        case TowerEnum.BombTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, x);
                            break;
                    }
                }

                Pages.Add(newPage);
            }
        }

        if (Pages[Pages.Count - 1].PageNumber > CurrentPage && CurrentPage == 1)
        {
            upArrow.SetActive(false);
            downArrow.SetActive(true);
        }
        else if (Pages[Pages.Count - 1].PageNumber == CurrentPage && CurrentPage == 1)
        {
            upArrow.SetActive(false);
            downArrow.SetActive(false);
        }

        ShowPage();
    }

    public void ShowPage()
    {
        foreach (var page in Pages)
        {
            bool isActive = page.PageNumber == CurrentPage;
            foreach (var gameObject in page.StatsInPage)
            {
                gameObject.SetActive(isActive);
            }
        }
    }

    public string SetStatValue(string statName, GameObject currentTower)
    {
        switch(statName)
        {
            case StringsDatabase.Stats.Damage:
                return currentTower.GetComponent<Tower>().Damage.ToString();
            case StringsDatabase.Stats.FireRate:
                return ((1 * 1.0f) / currentTower.GetComponent<Tower>().FireRate).ToString("F2") + " / s";
            case StringsDatabase.Stats.Range:
                return currentTower.GetComponent<Tower>().Range.ToString() + " m";
            case StringsDatabase.Stats.IceDamage:
                return currentTower.GetComponent<FreezeTower>().IceDamage.ToString();
            case StringsDatabase.Stats.SlowDuration:
                return currentTower.GetComponent<FreezeTower>().SlowDuration.ToString() + " s";
            case StringsDatabase.Stats.SlowEffect:
                return currentTower.GetComponent <FreezeTower>().SlowEffect.ToString() + " %";
            case StringsDatabase.Stats.PoisonDamageOverTime:
                return currentTower.GetComponent<PoisonTower>().PoisonDamageOverTime.ToString();
            case StringsDatabase.Stats.PoisonDuration:
                return currentTower.GetComponent<PoisonTower>().PoisonDuration.ToString() + " s";
            case StringsDatabase.Stats.PoisonTickRate:
                return currentTower.GetComponent<PoisonTower>().PoisonTickRate.ToString() + " / s";
            case StringsDatabase.Stats.SplashDamage:
                return currentTower.GetComponent<BombTower>().SplashDamage.ToString();
            case StringsDatabase.Stats.SplashRadius:
                return currentTower.GetComponent<BombTower>().SplashRadius.ToString() + " m";
            default:
                return string.Empty;
        }
    }

    public void ResetStatCointainer()
    {
        Pages = new List<Page>();
        for (int i = 0; i < StatContainer.transform.childCount; i++)
        {
            Destroy(StatContainer.transform.GetChild(i).gameObject);
        }

        upArrow.SetActive(false);
        downArrow.SetActive(false);

        CurrentPage = 1;
    }

    #region OnClick

    public void OnClick_DownArrow()
    {
        //We have another page
        if (Pages[Pages.Count - 1].PageNumber > CurrentPage)
        {
            CurrentPage++;

            //No next pages
            if (Pages[Pages.Count - 1].PageNumber == CurrentPage)
            {
                downArrow.SetActive(false);
            }
        }

        //We have a previous page
        if (Pages[0].PageNumber < CurrentPage)
        {
            upArrow.SetActive(true);
        }

        ShowPage();
    }

    public void OnClick_UpArrow()
    {
        //We are on a future page
        if (Pages[0].PageNumber < CurrentPage)
        {
            CurrentPage--;
            if (Pages[0].PageNumber == CurrentPage)
            {
                upArrow.SetActive(false);
            }
        }

        if (Pages[Pages.Count - 1].PageNumber > CurrentPage)
        {
            downArrow.SetActive(true);
        }

        ShowPage();
    }

    #endregion

}
