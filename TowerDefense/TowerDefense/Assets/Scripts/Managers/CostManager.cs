using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    [Header("Tower Costs")]
    public int DamageTowerCost;
    public int FreezeTowerCost;
    public int PoisonTowerCost;
    public int BombTowerCost;

    private void Awake()
    {
        SetUpTowerCost();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUpTowerCost()
    {
        DamageTowerCost = 20;
        FreezeTowerCost = 30;
        PoisonTowerCost = 35;
        BombTowerCost = 60;
    }
}
