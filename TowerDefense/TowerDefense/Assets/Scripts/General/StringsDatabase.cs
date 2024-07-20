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