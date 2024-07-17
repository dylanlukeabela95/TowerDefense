using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Page
{
    public int PageNumber { get; set; }
    public List<string> Stats { get; set; }

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

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();
        SetStats(TowerEnum.FreezeTower);
        Pagination(ReferencesManager.StatsManager.BombTowerStats);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStats(TowerEnum towerEnum)
    {
        switch(towerEnum)
        {
            case TowerEnum.DamageTower:
                for (int i = 0; i < ReferencesManager.StatsManager.DamageTowerStats.Count;i++)
                {
                    Instantiate(Stat, transform.position, Quaternion.identity, StatContainer.transform);
                }
                break;
            case TowerEnum.FreezeTower:
                for (int i = 0; i < ReferencesManager.StatsManager.FreezeTowerStats.Count; i++)
                {
                    Instantiate(Stat, transform.position, Quaternion.identity, StatContainer.transform);
                }
                break;
            case TowerEnum.PoisonTower:
                for (int i = 0; i < ReferencesManager.StatsManager.PoisonTowerStats.Count; i++)
                {
                    Instantiate(Stat, transform.position, Quaternion.identity, StatContainer.transform);
                }
                break;
            case TowerEnum.BombTower:
                for (int i = 0; i < ReferencesManager.StatsManager.BombTowerStats.Count; i++)
                {
                    Instantiate(Stat, transform.position, Quaternion.identity, StatContainer.transform);
                }
                break;

        }
    }

    public void Pagination(List<string> stats)
    {
        if(stats.Count <= 3)
        {
            Page newPage = new Page()
            {
                PageNumber = 1,
                Stats = stats
            };

            Pages.Add(newPage);
        }
        else
        {
            for (int i = 0; i < stats.Count; i++) 
            {
                Page newPage = new Page()
                {
                    PageNumber = i+1,
                    Stats = new List<string>()
                };

                var x = i + (2 * i);
                var y = i + (2 * i) + 1;
                var z = i + (2 * i) + 2;

                if (z > stats.Count)
                {
                    if(y > stats.Count)
                    {
                        if(x > stats.Count)
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
                }
                else if (y < stats.Count)
                {
                    newPage.Stats.Add(stats[x]);
                    newPage.Stats.Add(stats[y]);
                }
                else if(x <= stats.Count)
                {
                    newPage.Stats.Add(stats[x]);
                }

                Pages.Add(newPage);
            }
        }

        foreach (var page in Pages)
        {
            Debug.Log("Page Number - " + page.PageNumber);
            foreach(var stat in page.Stats)
            {
                Debug.Log("Stat - " + stat);
            }
        }        
    }
}
