using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [Header("Tower Sprites")]
    public Sprite DamageTowerSprite;
    public Sprite FreezeTowerSprite;
    public Sprite PoisonTowerSprite;
    public Sprite BombTowerSprite;


    [Header("Item Sprites")]
    public Sprite WeightSprite;
    public Sprite HotPepperSprite;
    public Sprite LensSprite;
    public Sprite VoucherSprite;
    public Sprite PiggyBankSprite;
    public Sprite DartBoardSprite;
    public Sprite ScopeSprite;
    public Sprite BoxOfBulletSprite;
    public Sprite MatchesSprite;
    public Sprite BlueprintSprite;
    public Sprite RedBallSprite;
    public Sprite SnowflakeSprite;
    public Sprite LiquidNitrogenSprite;
    public Sprite IceCubeSprite;
    public Sprite SnowballSprite;
    public Sprite FrozenBottleSprite;
    public Sprite IcecreamSprite;
    public Sprite PoisonVialSprite;
    public Sprite HazardSignSprite;
    public Sprite MoldyCheeseSprite;
    public Sprite SnotTissueSprite;
    public Sprite FungusSprite;
    public Sprite CannonballSprite;
    public Sprite DynamiteSprite;
    public Sprite TNTBoxSprite;
    public Sprite NukeSprite;
    public Sprite RPGSprite;
    public Sprite FireworkSprite;

    public Sprite GetSpriteByItemName(string itemName)
    {
        switch (itemName)
        {
            case StringsDatabase.Items.Weight:
                return WeightSprite;
            case StringsDatabase.Items.HotPepper:
                return HotPepperSprite;
            case StringsDatabase.Items.Lens:
                return LensSprite;
            case StringsDatabase.Items.Voucher:
                return VoucherSprite;
            case StringsDatabase.Items.PiggyBank:
                return PiggyBankSprite;
            case StringsDatabase.Items.DartBoard:
                return DartBoardSprite;
            case StringsDatabase.Items.Scope:
                return ScopeSprite;
            case StringsDatabase.Items.BoxOfBullets:
                return BoxOfBulletSprite;
            case StringsDatabase.Items.Matches:
                return MatchesSprite;
            case StringsDatabase.Items.Blueprint:
                return BlueprintSprite;
            case StringsDatabase.Items.RedBall:
                return RedBallSprite;
            case StringsDatabase.Items.Snowflake:
                return SnowflakeSprite;
            case StringsDatabase.Items.LiquidNitrogen:
                return LiquidNitrogenSprite;
            case StringsDatabase.Items.IceCube:
                return IceCubeSprite;
            case StringsDatabase.Items.Snowball:
                return SnowballSprite;
            case StringsDatabase.Items.FrozenBottle:
                return FrozenBottleSprite;
            case StringsDatabase.Items.IceCream:
                return IcecreamSprite;
            case StringsDatabase.Items.PoisonVial:
                return PoisonVialSprite;
            case StringsDatabase.Items.HazardSign:
                return HazardSignSprite;
            case StringsDatabase.Items.MoldyCheese:
                return MoldyCheeseSprite;
            case StringsDatabase.Items.SnotTissue:
                return SnotTissueSprite;
            case StringsDatabase.Items.Fungus:
                return FungusSprite;
            case StringsDatabase.Items.Cannonball:
                return CannonballSprite;
            case StringsDatabase.Items.Dynamite:
                return DynamiteSprite;
            case StringsDatabase.Items.TNTBox:
                return TNTBoxSprite;
            case StringsDatabase.Items.Nuke:
                return NukeSprite;
            case StringsDatabase.Items.RPG:
                return RPGSprite;
            case StringsDatabase.Items.Firework:
                return FireworkSprite;
            default:
                return null; // or handle the default case as needed
        }
    }

}
