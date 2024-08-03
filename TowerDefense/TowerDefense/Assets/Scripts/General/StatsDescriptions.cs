using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stats_Descriptions
{
    public class StatsDescriptions_General
    {
        public const string DamageStatDescription = "Increases Damage";
        public const string FireRateStatDescription = "Increases Fire Rate";
        public const string RangeStatDescription = "Increases Range";
    }

    public class StatsDescriptions_DamageTower
    {
        public const string RangeInfiniteStatDescription = "Range becomes Infinite";
        public const string CriticalStatDescription = "Gain a chance to deal Critical Damage. Critical Damage is 2 x Damage";
        public const string TwoBurstStatDescription = "Gain a chance to shoot in a Burst of Two";
        public const string ThreeBurstStatDescription = "Gain a chance to shoot in a Burst of Three";
        public const string ProjectileStatDescription = "Increase Tower Projectile";
        public const string ProjectileDamageStatDescription = "Increase Tower Projectile but Reduces Damage";
    }

    public class StatsDescriptions_FreezeTower
    {
        public const string IceDamageStatDescription = "Increases Ice Damage";
        public const string DamageIceDamageStatDescription = "Increases Ice Damage and Damage";
        public const string SlowDurationStatDescription = "Increases Slow Duration";
        public const string SlowEffectStatDescription = "Increases Slow Effect";
        public const string FrostbiteStatDescription = "Ice Damage will no longer be applied. Instead, it applies Frostbite to a target, dealing Ice Damage Over Time. Frostbite Damage Over Time is half the Ice Damage";
        public const string IcicleStatDescription = "Gain a chance to shoot an icicle at a random enemy on the field, dealing damage and slowing down the enemy";
        public const string ImmobilizeStatDescription = "Gain a chance to immobilize the target instead of slowing it down";
    }

    public class StatsDescriptions_PoisonTower
    {
        public const string PoisonDamageOverTimeStatDescription = "Increases Poison Damage Over Time";
        public const string PoisonDurationStatDescription = "Increases Poison Duration";
        public const string PoisonTickRateStatDescription = "Increases Poison Tick Rate";
        public const string PoisonDOTCriticalStatDescription = "Poison Damage Over Time gain a chance to deal Critical Damage. Critical Poison Damage Over Time is applied to all Poison Towers";
        public const string PoisonSpreadStatDescription = "This Poison Tower now shoots a projectile that inflicts nearby enemies with Poison";
    }

    public class StatsDescriptions_BombTower
    {
        public const string SplashDamageStatDescription = "Increases Splash Damage";
        public const string SplashRadiusStatDescription = "Increases Splash Radius";
        public const string DoubleExplosionChanceStatDescription = "Gain a chance for an explosion to trigger twice";
        public const string RocketStatDescription = "Gain a chance to shoot a Rocket at a random enemy, applying all the splash damage and radius benefits";
    }
}