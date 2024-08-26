using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public Dictionary<string, int> DamageTowerDamage = new Dictionary<string, int>();
    public Dictionary<string, float> DamageTowerFireRate = new Dictionary<string, float>();
    public Dictionary<string, float> DamageTowerRange = new Dictionary<string, float>();
    public Dictionary<string, int> DamageTowerProjectile = new Dictionary<string, int>();
    public Dictionary<string, int> DamageTowerBurstChance = new Dictionary<string, int>();
    public Dictionary<string, int> DamageTowerCriticalChance = new Dictionary<string, int>();

    public Dictionary<string, int> FreezeTowerDamage = new Dictionary<string, int>();
    public Dictionary<string, float> FreezeTowerFireRate = new Dictionary<string, float>();
    public Dictionary<string, float> FreezeTowerRange = new Dictionary<string, float>();
    public Dictionary<string, int> FreezeTowerIceDamage = new Dictionary<string, int>();
    public Dictionary<string, float> FreezeTowerSlowDuration = new Dictionary<string, float>();
    public Dictionary<string, float> FreezeTowerSlowEffect = new Dictionary<string, float>();
    public Dictionary<string, bool> FreezeTowerFrostbite = new Dictionary<string, bool>();
    public Dictionary<string, int> FreezeTowerIcicle = new Dictionary<string, int>();
    public Dictionary<string, int> FreezeTowerImmobilize = new Dictionary<string, int>();

    public Dictionary<string, int> PoisonTowerDamage = new Dictionary<string, int>();
    public Dictionary<string, float> PoisonTowerFireRate = new Dictionary<string, float>();
    public Dictionary<string, float> PoisonTowerRange = new Dictionary<string, float>();
    public Dictionary<string, int> PoisonTowerDamageOverTime = new Dictionary<string, int>();
    public Dictionary<string, float> PoisonTowerDuration = new Dictionary<string, float>();
    public Dictionary<string, float> PoisonTowerTickRate = new Dictionary<string, float>();
    public Dictionary<string, int> PoisonTowerPoisonCriticalChance = new Dictionary<string, int>();
    public Dictionary<string, bool> PoisonTowerPoisonSpread = new Dictionary<string, bool>();
    public Dictionary<string, float> PoisonTowerPoisonSpreadRadius = new Dictionary<string, float>();

    public Dictionary<string, int> BombTowerDamage = new Dictionary<string, int>();
    public Dictionary<string, float> BombTowerFireRate = new Dictionary<string, float>();
    public Dictionary<string, float> BombTowerRange = new Dictionary<string, float>();
    public Dictionary<string, int> BombTowerSplashDamage = new Dictionary<string, int>();
    public Dictionary<string, float> BombTowerSplashRadius = new Dictionary<string, float>();
    public Dictionary<string, bool> BombTowerRocket = new Dictionary<string, bool>();
    public Dictionary<string, int> BombTowerRocketChance = new Dictionary<string, int>();
    public Dictionary<string, int> BombTowerDoubleExplosionChance = new Dictionary<string, int>();

    public int RocketDamage = 15;
    public int IcicleDamage = 15;

    private void Start()
    {
        AssignUpgrades();
    }

    public void AssignUpgrades()
    {
        AssignDamageTowerUpgrades();
        AssignFreezeTowerUpgrades();
        AssignPoisonTowerUpgrades();
        AssignBombTowerUpgrades();
    }

    public void AssignDamageTowerUpgrades()
    {
        DamageFirst();
        DamageLeftBranch();
        DamageMiddleBranch();
        DamageRightBranch();
    }

    public void AssignFreezeTowerUpgrades()
    {
        FreezeFirst();
        FreezeLeftBranch();
        FreezeMiddleBranch();
        FreezeRightBranch();
    }

    public void AssignPoisonTowerUpgrades()
    {
        PoisonFirst();
        PoisonLeftBranch();
        PoisonMiddleBranch();
        PoisonRightBranch();
    }

    public void AssignBombTowerUpgrades()
    {
        BombFirst();
        BombLeftBranch();
        BombMiddleBranch();
        BombRightBranch();
    }

    public void DamageFirst()
    {
        DamageTowerDamage.Add("Level1", 5);
    }

    public void DamageLeftBranch()
    {
        DamageTowerFireRate.Add("Level2", 0.1f);

        DamageTowerBurstChance.Add("Level3.1", 15); // 15% for 2 burst
        DamageTowerFireRate.Add("Level3.2", 0.1f);

        DamageTowerFireRate.Add("Level4", 0.1f);

        DamageTowerBurstChance.Add("Level5", 10); // 10% for 3 burst
    }

    public void DamageMiddleBranch()
    {
        DamageTowerDamage.Add("Level2", 5);

        DamageTowerProjectile.Add("Level3", 1);

        DamageTowerDamage.Add("Level4.1", 50); // 50% reduction
        DamageTowerProjectile.Add("Level4.1", 1);

        DamageTowerDamage.Add("Level4.2", 10);

        DamageTowerDamage.Add("Level5", 10);
    }

    public void DamageRightBranch()
    {
        DamageTowerRange.Add("Level2", 1);

        DamageTowerCriticalChance.Add("Level3.1", 10);
        DamageTowerRange.Add("Level3.2", 1);

        DamageTowerRange.Add("Level4", 1);

        DamageTowerRange.Add("Level5", 100);
    }

    public void FreezeFirst()
    {
        FreezeTowerIceDamage.Add("Level1", 2);
    }

    public void FreezeLeftBranch()
    {
        FreezeTowerFireRate.Add("Level2", 0.1f);

        FreezeTowerSlowDuration.Add("Level3.1", 0.5f);
        FreezeTowerFireRate.Add("Level3.2", 0.1f);

        FreezeTowerSlowDuration.Add("Level4", 0.5f);

        FreezeTowerSlowDuration.Add("Level5", 1f);
    }

    public void FreezeMiddleBranch()
    {
        FreezeTowerIceDamage.Add("Level2", 3);

        FreezeTowerIceDamage.Add("Level3.1", 5);
        FreezeTowerFrostbite.Add("Level3.2", true);

        FreezeTowerDamage.Add("Level4", 5);
        FreezeTowerIceDamage.Add("Level4", 5);

        FreezeTowerIcicle.Add("Level5", 10); //10% chance to shoot icicle dealing 15
    }

    public void FreezeRightBranch()
    {
        FreezeTowerSlowEffect.Add("Level2", 5f);

        FreezeTowerRange.Add("Level3", 1);

        FreezeTowerSlowEffect.Add("Level4.1", 5f);
        FreezeTowerRange.Add("Level4.2", 1);

        FreezeTowerImmobilize.Add("Level5", 5); //5% to immobilize movement for the duration of the slow
    }

    public void PoisonFirst()
    {
        PoisonTowerDamageOverTime.Add("Level1", 1);
    }

    public void PoisonLeftBranch()
    {
        PoisonTowerDuration.Add("Level2", 1);

        PoisonTowerDuration.Add("Level3.1", 1);
        PoisonTowerTickRate.Add("Level3.2", 0.3f);

        PoisonTowerDuration.Add("Level4", 1);

        PoisonTowerDuration.Add("Level5", 1);
    }

    public void PoisonMiddleBranch()
    {
        PoisonTowerDamageOverTime.Add("Level2", 1);

        PoisonTowerDamage.Add("Level3.1", 4);
        PoisonTowerDamageOverTime.Add("Level3.2", 2);

        PoisonTowerDamage.Add("Level4.1", 5);
        PoisonTowerTickRate.Add("Level4.2", 0.3f);

        PoisonTowerPoisonCriticalChance.Add("Level5", 10); //10% for poison damage to crit
    }

    public void PoisonRightBranch()
    {
        PoisonTowerRange.Add("Level2", 1);

        PoisonTowerFireRate.Add("Level3.1", 0.2f);
        PoisonTowerRange.Add("Level3.2", 1);

        PoisonTowerRange.Add("Level4", 1);

        PoisonTowerPoisonSpread.Add("Level5", true);
        PoisonTowerPoisonSpreadRadius.Add("Level5", 4);
    }

    public void BombFirst()
    {
        BombTowerSplashDamage.Add("Level1", 2);
    }

    public void BombLeftBranch()
    {
        BombTowerDamage.Add("Level2", 5);

        BombTowerDamage.Add("Level3.1", 5);
        BombTowerFireRate.Add("Level3.2", 0.5f);

        BombTowerDamage.Add("Level4", 5);

        BombTowerRocket.Add("Level5", true);
        BombTowerRocketChance.Add("Level5", 10);
    }

    public void BombMiddleBranch()
    {
        BombTowerSplashDamage.Add("Level2", 3);

        BombTowerDoubleExplosionChance.Add("Level3.1", 5);
        BombTowerSplashDamage.Add("Level3.2", 5);

        BombTowerDoubleExplosionChance.Add("Level4.1", 5);
        BombTowerSplashDamage.Add("Level4.2", 5);

        BombTowerSplashDamage.Add("Level5", 10);
    }

    public void BombRightBranch()
    {
        BombTowerRange.Add("Level2", 1);

        BombTowerSplashRadius.Add("Level3.1", 1);
        BombTowerRange.Add("Level3.2", 1);

        BombTowerSplashRadius.Add("Level4.1", 1);
        BombTowerRange.Add("Level4.2", 1);

        BombTowerFireRate.Add("Level5", 1);
    }    
}
