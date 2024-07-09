using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isDamageTowerSelected;
    public bool isFreezeTowerSelected;
    public bool isPoisonTowerSelected;
    public bool isBombTowerSelected;

    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBooleans(bool damageTower, bool freezeTower, bool poisonTower, bool bombTower)
    {
        isDamageTowerSelected = damageTower;
        isFreezeTowerSelected = freezeTower;
        isPoisonTowerSelected = poisonTower;
        isBombTowerSelected = bombTower;
    }
}
