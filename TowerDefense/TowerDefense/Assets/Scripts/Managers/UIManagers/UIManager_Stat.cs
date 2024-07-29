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
    
    public GameObject StatContainer_L;
    public GameObject StatDisplay_L;

    public GameObject StatContainer_R;
    public GameObject StatDisplay_R;

    public List<Page> Pages = new List<Page>();
    public int CurrentPage = 1;

    public GameObject downArrow_L;
    public GameObject upArrow_L;

    public GameObject downArrow_R;
    public GameObject upArrow_R;

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
        StatDisplay_L.SetActive(false);
        StatDisplay_R.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> SetStats(TowerEnum towerEnum, int start, int end, bool isRight)
    {
        List<GameObject> stats = new List<GameObject>();

        if (ReferencesManager.GameManager.currentTower != null)
        {
            switch (towerEnum)
            {
                case TowerEnum.DamageTower:
                    for (int i = start; i <= end; i++)
                    {
                        if (isRight)
                        {
                            StatDisplay_L.transform.Find(StringsDatabase.UI_Stats.TowerTitle).GetComponent<TextMeshProUGUI>().text = StringsDatabase.TowerNames.DamageTower;
                            GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer_L.transform);
                            stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().GetStat(i);
                            stat.name = ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().GetStat(i).Replace(" ", "");
                            stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                            stats.Add(stat);
                        }
                        else
                        {
                            StatDisplay_R.transform.Find(StringsDatabase.UI_Stats.TowerTitle).GetComponent<TextMeshProUGUI>().text = StringsDatabase.TowerNames.DamageTower;
                            GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer_R.transform);
                            stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().GetStat(i);
                            stat.name = ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().GetStat(i).Replace(" ", "");
                            stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                            stats.Add(stat);
                        }
                    }
                    break;
                case TowerEnum.FreezeTower:
                    for (int i = start; i <= end; i++)
                    {
                        if (isRight)
                        {
                            StatDisplay_L.transform.Find(StringsDatabase.UI_Stats.TowerTitle).GetComponent<TextMeshProUGUI>().text = StringsDatabase.TowerNames.FreezeTower;
                            GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer_L.transform);
                            stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.GameManager.currentTower.GetComponent<FreezeTower>().Stats[i];
                            stat.name = ReferencesManager.GameManager.currentTower.GetComponent<FreezeTower>().Stats[i].Replace(" ", "");
                            stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                            stats.Add(stat);
                        }
                        else
                        {
                            StatDisplay_R.transform.Find(StringsDatabase.UI_Stats.TowerTitle).GetComponent<TextMeshProUGUI>().text = StringsDatabase.TowerNames.FreezeTower;
                            GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer_R.transform);
                            stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.GameManager.currentTower.GetComponent<FreezeTower>().Stats[i];
                            stat.name = ReferencesManager.GameManager.currentTower.GetComponent<FreezeTower>().Stats[i].Replace(" ", "");
                            stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                            stats.Add(stat);
                        }
                    }
                    break;
                case TowerEnum.PoisonTower:
                    for (int i = start; i <= end; i++)
                    {
                        if (isRight)
                        {
                            StatDisplay_L.transform.Find(StringsDatabase.UI_Stats.TowerTitle).GetComponent<TextMeshProUGUI>().text = StringsDatabase.TowerNames.PoisonTower;
                            GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer_L.transform);
                            stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.GameManager.currentTower.GetComponent<PoisonTower>().Stats[i];
                            stat.name = ReferencesManager.GameManager.currentTower.GetComponent<PoisonTower>().Stats[i].Replace(" ", "");
                            stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                            stats.Add(stat);
                        }
                        else
                        {
                            StatDisplay_R.transform.Find(StringsDatabase.UI_Stats.TowerTitle).GetComponent<TextMeshProUGUI>().text = StringsDatabase.TowerNames.PoisonTower;
                            GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer_R.transform);
                            stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.GameManager.currentTower.GetComponent<PoisonTower>().Stats[i];
                            stat.name = ReferencesManager.GameManager.currentTower.GetComponent<PoisonTower>().Stats[i];
                            stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                            stats.Add(stat);
                        }
                    }
                    break;
                case TowerEnum.BombTower:
                    for (int i = start; i <= end; i++)
                    {
                        if (isRight)
                        {
                            StatDisplay_L.transform.Find(StringsDatabase.UI_Stats.TowerTitle).GetComponent<TextMeshProUGUI>().text = StringsDatabase.TowerNames.BombTower;
                            GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer_L.transform);
                            stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.GameManager.currentTower.GetComponent<BombTower>().Stats[i];
                            stat.name = ReferencesManager.GameManager.currentTower.GetComponent<BombTower>().Stats[i].Replace(" ", "");
                            stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                            stats.Add(stat);
                        }
                        else
                        {
                            StatDisplay_R.transform.Find(StringsDatabase.UI_Stats.TowerTitle).GetComponent<TextMeshProUGUI>().text = StringsDatabase.TowerNames.BombTower;
                            GameObject stat = Instantiate(Stat, transform.position, Quaternion.identity, StatContainer_R.transform);
                            stat.transform.Find(StringsDatabase.UI_Stats.StatText).GetComponent<TextMeshProUGUI>().text = ReferencesManager.GameManager.currentTower.GetComponent<BombTower>().Stats[i];
                            stat.name = ReferencesManager.GameManager.currentTower.GetComponent<BombTower>().Stats[i].Replace(" ", "");
                            stat.transform.Find(StringsDatabase.UI_Stats.UpgradeValue).GetComponent<TextMeshProUGUI>().text = SetStatValue(stat.name, ReferencesManager.GameManager.currentTower);
                            stats.Add(stat);
                        }
                    }
                    break;
            }
        }

        return stats;
    }

    public void Pagination(List<string> stats, TowerEnum towerEnum, bool isRight)
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
                    newPage.StatsInPage = SetStats(towerEnum, 0, stats.Count - 1, isRight);
                    break;
                case TowerEnum.FreezeTower:
                    newPage.StatsInPage = SetStats(towerEnum, 0, stats.Count - 1, isRight);
                    break;
                case TowerEnum.PoisonTower:
                    newPage.StatsInPage = SetStats(towerEnum, 0, stats.Count - 1, isRight);
                    break;
                case TowerEnum.BombTower:
                    newPage.StatsInPage = SetStats(towerEnum, 0, stats.Count - 1, isRight);
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
                            newPage.StatsInPage = SetStats(towerEnum, x, z, isRight);
                            break;
                        case TowerEnum.FreezeTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, z, isRight);
                            break;
                        case TowerEnum.PoisonTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, z, isRight);
                            break;
                        case TowerEnum.BombTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, z, isRight);
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
                            newPage.StatsInPage = SetStats(towerEnum, x, y, isRight);
                            break;
                        case TowerEnum.FreezeTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, y, isRight);
                            break;
                        case TowerEnum.PoisonTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, y, isRight);
                            break;
                        case TowerEnum.BombTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, y, isRight);
                            break;
                    }
                }
                else if (x <= stats.Count)
                {
                    newPage.Stats.Add(stats[x]);

                    switch (towerEnum)
                    {
                        case TowerEnum.DamageTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, x, isRight);
                            break;
                        case TowerEnum.FreezeTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, x, isRight);
                            break;
                        case TowerEnum.PoisonTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, x, isRight);
                            break;
                        case TowerEnum.BombTower:
                            newPage.StatsInPage = SetStats(towerEnum, x, x, isRight);
                            break;
                    }
                }

                Pages.Add(newPage);
            }
        }

        if (isRight)
        {
            if (Pages[Pages.Count - 1].PageNumber > CurrentPage && CurrentPage == 1)
            {
                upArrow_L.SetActive(false);
                downArrow_L.SetActive(true);
            }
            else if (Pages[Pages.Count - 1].PageNumber == CurrentPage && CurrentPage == 1)
            {
                upArrow_L.SetActive(false);
                downArrow_L.SetActive(false);
            }
        }
        else
        {
            if (Pages[Pages.Count - 1].PageNumber > CurrentPage && CurrentPage == 1)
            {
                upArrow_R.SetActive(false);
                downArrow_R.SetActive(true);
            }
            else if (Pages[Pages.Count - 1].PageNumber == CurrentPage && CurrentPage == 1)
            {
                upArrow_R.SetActive(false);
                downArrow_R.SetActive(false);
            }
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
                if(currentTower.GetComponent<Tower>().Range >= 100)
                {
                    return "Infinity";
                }
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
            case StringsDatabase.Stats.ProjectileCount:
                return currentTower.GetComponent<DamageTower>().ProjectileCount.ToString();
            case StringsDatabase.Stats.TwoRoundBurstChance:
                return currentTower.GetComponent<DamageTower>().TwoRoundBurstChance.ToString() + " %";
            case StringsDatabase.Stats.ThreeRoundBurstChance:
                return currentTower.GetComponent<DamageTower>().ThreeRoundBurstChance.ToString() + " %";
            case StringsDatabase.Stats.CriticalChance:
                return currentTower.GetComponent<DamageTower>().CriticalChance.ToString() + " %";
            case StringsDatabase.Stats.CriticalDamage:
                return (currentTower.GetComponent<DamageTower>().Damage * 2).ToString();
            case StringsDatabase.Stats.FrostbiteDamage:
                return ((currentTower.GetComponent<FreezeTower>().IceDamage * 1.0f) / 2).ToString();
            case StringsDatabase.Stats.FrostbiteTickRate:
                return currentTower.GetComponent<FreezeTower>().FrostbiteTickRate.ToString() + " / s";
            case StringsDatabase.Stats.IcicleChance:
                return currentTower.GetComponent<FreezeTower>().IcicleChance.ToString() + " %";
            case StringsDatabase.Stats.IcicleDanage:
                return currentTower.GetComponent<FreezeTower>().IcicleDamage.ToString();
            case StringsDatabase.Stats.Immobilize:
                return currentTower.GetComponent<FreezeTower>().ImmobilizeChance.ToString() + " %";
            default:
                return string.Empty;
        }
    }

    public void ResetStatCointainer()
    {
        StatDisplay_L.SetActive(false);
        StatDisplay_R.SetActive(false);
        Pages = new List<Page>();

        if (StatContainer_L.transform.childCount > 0)
        {
            for (int i = 0; i < StatContainer_L.transform.childCount; i++)
            {
                Destroy(StatContainer_L.transform.GetChild(i).gameObject);
            }

            upArrow_L.SetActive(false);
            downArrow_L.SetActive(false);
        }
        else if(StatContainer_R.transform.childCount > 0)
        {
            for (int i = 0; i < StatContainer_R.transform.childCount; i++)
            {
                Destroy(StatContainer_R.transform.GetChild(i).gameObject);
            }

            upArrow_R.SetActive(false);
            downArrow_R.SetActive(false);
        }

        CurrentPage = 1;
    }

    public void ShowStatDisplay(string towerName, bool isRight)
    {
        if (isRight)
        {
            StatDisplay_L.SetActive(true);
        }
        else
        {
            StatDisplay_R.SetActive(true);
        }
        
        if (towerName.Contains("DamageTower"))
        {
            ReferencesManager.UIManager_Stat.Pagination(ReferencesManager.GameManager.currentTower.GetComponent<DamageTower>().GetStats(), TowerEnum.DamageTower, isRight);
        }
        else if (towerName.Contains("FreezeTower"))
        {
            ReferencesManager.UIManager_Stat.Pagination(ReferencesManager.GameManager.currentTower.GetComponent<FreezeTower>().Stats, TowerEnum.FreezeTower, isRight);
        }
        else if (towerName.Contains("PoisonTower"))
        {
            ReferencesManager.UIManager_Stat.Pagination(ReferencesManager.GameManager.currentTower.GetComponent<PoisonTower>().Stats, TowerEnum.PoisonTower, isRight);
        }
        else if (towerName.Contains("BombTower"))
        {
            ReferencesManager.UIManager_Stat.Pagination(ReferencesManager.GameManager.currentTower.GetComponent<BombTower>().Stats, TowerEnum.BombTower, isRight);
        }
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
                downArrow_L.SetActive(false);
                downArrow_R.SetActive(false);
            }
        }

        //We have a previous page
        if (Pages[0].PageNumber < CurrentPage)
        {
            upArrow_L.SetActive(true);
            upArrow_R.SetActive(true);
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
                upArrow_L.SetActive(false);
                upArrow_R.SetActive(false);
            }
        }

        if (Pages[Pages.Count - 1].PageNumber > CurrentPage)
        {
            downArrow_L.SetActive(true);
            downArrow_R.SetActive(true);
        }

        ShowPage();
    }

    public void OnClick_UpgradesSection(GameObject panel)
    {
        ReferencesManager.UIManager_Upgrades.ShowSkillTree(ReferencesManager.GameManager.currentTower.GetComponent<Tower>().TowerEnum);
        panel.SetActive(false);
        ReferencesManager.UIManager_Upgrades.SetUpSkillTreeOptions(ReferencesManager.GameManager.currentTower, ReferencesManager.UIManager_Upgrades.ReturnTypeSkillTree(ReferencesManager.GameManager.currentTower));
    }

    #endregion

}
