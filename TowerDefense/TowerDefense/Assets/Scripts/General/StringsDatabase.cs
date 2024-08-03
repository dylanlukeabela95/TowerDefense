using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strings
{
    public class StringsDatabase : MonoBehaviour
    {
        public class TowerButtonNames
        {
            public const string DamageTowerButton = "DamageTowerButton";
            public const string FreezeTowerButton = "FreezeTowerButton";
            public const string PoisonTowerButton = "PoisonTowerButton";
            public const string BombTowerButton = "BombTowerButton";
        }

        public class Buttons
        {
            public const string DownButton = "DownButton";
            public const string UpButton = "UpButton";
        }

        public class UI
        {
            public const string Canvas = "Canvas";
            public const string SelectedNode = "SelectedNode";
        }

        public class UI_Upgrades
        {
            public const string UpgradeTitle = "UpgradeTitle";
            public const string UpgradeDescription = "UpgradeDescription";
            public const string UpgradeStats = "UpgradeStats";

            public const string UpgradeStatTitle = "UpgradeStatTitle";
            public const string StatsContainer = "Stats";
            public const string UpgradeStatChanges_Old = "UpgradeStatChanges_Old";
            public const string UpgradeStatChanges_New = "UpgradeStatChanges_New";
        }

        public class UI_Stats
        {
            public const string StatText = "StatText";
            public const string UpgradeValue = "UpgradeValue";
            public const string TowerTitle = "TowerTitle";
        }

        public class Towers
        {
            public const string RangeIndicator = "RangeIndicator";
            public const string DamageTower = "DamageTower";
            public const string FreezeTower = "FreezeTower";
            public const string PoisonTower = "PoisonTower";
            public const string BombTower = "BombTower";
        }

        public class Stats
        {
            public const string Damage = "Damage";
            public const string FireRate = "FireRate";
            public const string Range = "Range";
            public const string Cost = "Cost";
            public const string IceDamage = "IceDamage";
            public const string SlowDuration = "SlowDuration";
            public const string SlowEffect = "SlowEffect";
            public const string PoisonDamageOverTime = "PoisonDamageOverTime";
            public const string PoisonDuration = "PoisonDuration";
            public const string PoisonTickRate = "PoisonTickRate";
            public const string SplashDamage = "SplashDamage";
            public const string SplashRadius = "SplashRadius";
            public const string ProjectileCount = "ProjectileCount";
            public const string TwoRoundBurstChance = "2RoundBurstChance";
            public const string ThreeRoundBurstChance = "3RoundBurstChance";
            public const string CriticalChance = "CriticalChance";
            public const string CriticalDamage = "CriticalDamage";
            public const string Frostbite = "Frostbite";
            public const string FrostbiteDamage = "FrostbiteDamage";
            public const string FrostbiteTickRate = "FrostbiteTickRate";
            public const string Icicle = "Icicle";
            public const string IcicleDanage = "IcicleDamage";
            public const string IcicleChance = "IcicleChance";
            public const string Immobilize = "Immobilize";
            public const string ImmobilizeChance = "ImmobilizeChance";
            public const string PoisonCriticalChance = "PoisonCriticalChance";
            public const string PoisonCriticalDamage = "PoisonCriticalDamage";
            public const string PoisonSpread = "PoisonSpread";
            public const string DoubleExplosionChance = "DoubleExplosionChance";
            public const string Rocket = "Rocket";
            public const string RocketChance = "RocketChance";
            public const string RocketDamage = "RocketDamage";
        }

        public class Stats_Display
        {
            public const string Damage = "Damage";
            public const string FireRate = "Fire Rate";
            public const string Range = "Range";
            public const string Cost = "Cost";
            public const string IceDamage = "Ice Damage";
            public const string SlowDuration = "Slow Duration";
            public const string SlowEffect = "Slow Effect";
            public const string PoisonDamageOverTime = "Poison Damage Over Time";
            public const string PoisonDuration = "Poison Duration";
            public const string PoisonTickRate = "Poison Tick Rate";
            public const string SplashDamage = "Splash Damage";
            public const string SplashRadius = "Splash Radius";
            public const string ProjectileCount = "Projectile Count";
            public const string TwoRoundBurstChance = "Two Round Burst Chance";
            public const string ThreeRoundBurstChance = "Three Round Burst Chance";
            public const string CriticalChance = "Critical Chance";
            public const string CriticalDamage = "Critical Damage";
            public const string Frostbite = "Frostbite";
            public const string FrostbiteDamage = "Frostbite Damage";
            public const string FrostbiteTickRate = "Frostbite Tick Rate";
            public const string IcicleDanage = "Icicle Damage";
            public const string IcicleChance = "Icicle Chance";
            public const string ImmobilizeChance = "Immobilize Chance";
            public const string PoisonCriticalChance = "Poison Critical Chance";
            public const string PoisonCriticalDamage = "Poison Critical Damage";
            public const string PoisonSpreadRadius = "Poison Spread Radius";
            public const string DoubleExplosionChance = "Double Explosion Chance";
            public const string RocketChance = "Rocket Chance";
            public const string RocketDamage = "Rocket Damage";
        }

        public class TowerNames
        {
            public const string DamageTower = "Damage Tower";
            public const string FreezeTower = "Freeze Tower";
            public const string PoisonTower = "Poison Tower";
            public const string BombTower = "Bomb Tower";
        }

        public class SkillTree
        {
            public const string DamageSkillTree = "Damage Tower Skill Tree";
            public const string FreezeSkillTree = "Freeze Tower Skill Tree";
            public const string PoisonSkillTree = "Poison Tower Skill Tree";
            public const string BombSkillTree = "Bomb Tower Skill Tree";
        }
    }
}