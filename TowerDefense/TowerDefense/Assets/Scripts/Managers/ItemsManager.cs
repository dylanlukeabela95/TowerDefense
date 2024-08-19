using Mono.Cecil;
using Strings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item
{
    public Sprite ItemSprite {  get; set; }
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public int? ItemCount { get; set; }
}

public class ItemsManager : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    //This will be used to store all the items in the game
    public List<Item> AllItems = new List<Item>();

    //These will be used to store the current items that are obtained
    public List<Item> GeneralItems = new List<Item>();
    public List<Item> DamageTowerItems = new List<Item>();
    public List<Item> FreezeTowerItems = new List<Item>();
    public List<Item> PoisonTowerItems = new List<Item>();
    public List<Item> BombTowerItems = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        SetAllItems();

        //For testing
        AddItem(StringsDatabase.Items.Weight, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Weight));
        AddItem(StringsDatabase.Items.Weight, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Weight));
        AddItem(StringsDatabase.Items.DartBoard, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Weight));
        AddItem(StringsDatabase.Items.Scope, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Scope));
        AddItem(StringsDatabase.Items.Snowflake, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Snowflake));
        AddItem(StringsDatabase.Items.HazardSign, AllItems.Find(a => a.ItemName == StringsDatabase.Items.HazardSign));
        AddItem(StringsDatabase.Items.Cannonball, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Cannonball));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetAllItems()
    {
        SetAllGeneralItems();
        SetAllDamageTowerItems();
        SetAllFreezeTowerItems();
        SetAllPoisonTowerItems();
        SetAllBombTowerItems();
    }

    void SetAllGeneralItems()
    {
        Item weight = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.WeightSprite,
            ItemName = StringsDatabase.Items.Weight,
            ItemDescription = "Increases Tower Damage By 5"
        };

        Item hotPepper = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.HotPepperSprite,
            ItemName = StringsDatabase.Items.HotPepper,
            ItemDescription = "Increasess Tower Fire Rate by 10%"
        };

        Item lens = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.LensSprite,
            ItemName = StringsDatabase.Items.Lens,
            ItemDescription = "Increases Tower Range by 1 metre"
        };

        Item voucher = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.VoucherSprite,
            ItemName = StringsDatabase.Items.Voucher,
            ItemDescription = "Reduce the cost of the Tower that it is placed on by 2. (Max 6)"
        };

        Item piggyBank = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.PiggyBankSprite,
            ItemName = StringsDatabase.Items.PiggyBank,
            ItemDescription = "Generate +1 coin per kill. This works for all towers"
        };

        Item dartBoard = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.DartBoardSprite,
            ItemName = StringsDatabase.Items.DartBoard,
            ItemDescription = "Gain 10% chance to deal Critical Damage. Critical Damage is x2 Damage"
        };

        AllItems.Add(weight);
        AllItems.Add(hotPepper);
        AllItems.Add(lens);
        AllItems.Add(voucher);
        AllItems.Add(piggyBank);
        AllItems.Add(dartBoard);
    }

    void SetAllDamageTowerItems()
    {
        Item scope = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.ScopeSprite,
            ItemName = StringsDatabase.Items.Scope,
            ItemDescription = "Increases Critical Chance by 10% and Critical Damage by 100%"
        };

        Item boxOfBullets = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.BoxOfBulletSprite,
            ItemName = StringsDatabase.Items.BoxOfBullets,
            ItemDescription = "Increases Two Round Burst and Three Round Burst Chance by 5%"
        };

        Item matches = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.MatchesSprite,
            ItemName = StringsDatabase.Items.Matches,
            ItemDescription = "Damage Towers have a 5% chance to inflict an enemy with Burn. Burned enemies take damage over time and has a high tick rate"
        };

        Item blueprint = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.BlueprintSprite,
            ItemName = StringsDatabase.Items.Blueprint,
            ItemDescription = "All Damage Towers, currently on the field and future Damage Towers will gain 5 damage"
        };

        Item redBall = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.RedBallSprite,
            ItemName = StringsDatabase.Items.RedBall,
            ItemDescription = "Damage Tower has 5% chance to deal Super Damage. Super Damage is x5 Damage"
        };

        AllItems.Add(scope);
        AllItems.Add(boxOfBullets);
        AllItems.Add(matches);
        AllItems.Add(blueprint);
        AllItems.Add(redBall);

    }

    void SetAllFreezeTowerItems()
    {
        Item snowflake = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.SnowflakeSprite,
            ItemName = StringsDatabase.Items.Snowflake,
            ItemDescription = "Increase Slow Duration by 1 second"
        };

        Item liquidNitrogen = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.LiquidNitrogenSprite,
            ItemName = StringsDatabase.Items.LiquidNitrogen,
            ItemDescription = "Increase Slow Effect by 10%"
        };

        Item iceCube = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.IceCubeSprite,
            ItemName = StringsDatabase.Items.IceCube,
            ItemDescription = "Increase Ice Damage By 6 or Frostbite Damage Over Time by 3"
        };

        Item snowball = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.SnowballSprite,
            ItemName = StringsDatabase.Items.Snowball,
            ItemDescription = "Gain 5% chance to shoot a snowball at an enemy at a random enemy, stunning them for 1 second"
        };

        Item frozenBottle = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.FrozenBottleSprite,
            ItemName = StringsDatabase.Items.FrozenBottle,
            ItemDescription = "Icicle Spawn Chance increased by 5%"
        };

        Item icecream = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.IcecreamSprite,
            ItemName = StringsDatabase.Items.IceCream,
            ItemDescription = "Increase Immobilize Chance by 5%"
        };

        AllItems.Add(snowflake);
        AllItems.Add(liquidNitrogen);
        AllItems.Add(iceCube);
        AllItems.Add(snowball);
        AllItems.Add(frozenBottle);
        AllItems.Add(icecream);
    }

    void SetAllPoisonTowerItems()
    {
        Item poisonVial = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.PoisonVialSprite,
            ItemName = StringsDatabase.Items.PoisonVial,
            ItemDescription = "Increase Poison Damage Over Time by 2"
        };

        Item hazardSign = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.HazardSignSprite,
            ItemName = StringsDatabase.Items.HazardSign,
            ItemDescription = "Increases Poison Duration by 1 second"
        };

        Item moldyCheese = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.MoldyCheeseSprite,
            ItemName = StringsDatabase.Items.MoldyCheese,
            ItemDescription = "Increase Poison Tick Rate by 0.1 seconds"
        };

        Item snotTissue = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.SnotTissueSprite,
            ItemName = StringsDatabase.Items.SnotTissue,
            ItemDescription = "When an enemy inflicted with Poison is defeated, there is a 5% chance to realise a poison nova, inflicting Poison to all nearby enemies. This applies to all Poison effects"
        };

        Item fungus = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.FungusSprite,
            ItemName = StringsDatabase.Items.Fungus,
            ItemDescription = "Increase Poison Critical Chance by 5% globally"
        };

        AllItems.Add(poisonVial);
        AllItems.Add(hazardSign);
        AllItems.Add(moldyCheese);
        AllItems.Add(snotTissue);
        AllItems.Add(fungus);
    }

    void SetAllBombTowerItems()
    {
        Item cannonball = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.CannonballSprite,
            ItemName = StringsDatabase.Items.Cannonball,
            ItemDescription = "Increase Damage and Splash Damage by 5"
        };

        Item dynamite = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.DynamiteSprite,
            ItemName = StringsDatabase.Items.Dynamite,
            ItemDescription = "Increases Splash Radius by 1 m"
        };

        Item tntBox = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.TNTBoxSprite,
            ItemName = StringsDatabase.Items.TNTBox,
            ItemDescription = "Explosion happens after 1 second but increases Splash Damage and Splash Radius by 50%"
        };

        Item nuke = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.NukeSprite,
            ItemName = StringsDatabase.Items.Nuke,
            ItemDescription = "Gain 5% chance for this tower to deal Splash Damage to everyone on the screen"
        };

        Item rpg = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.RPGSprite,
            ItemName = StringsDatabase.Items.RPG,
            ItemDescription = "Increase Rocket Spawn Chance by 10%"
        };

        Item firework = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.FireworkSprite,
            ItemName = StringsDatabase.Items.Firework,
            ItemDescription = "Increase Double Explosion Chance by 10%"
        };

        AllItems.Add(cannonball);
        AllItems.Add(dynamite);
        AllItems.Add(tntBox);
        AllItems.Add(nuke);
        AllItems.Add(rpg);
        AllItems.Add(firework);
    }

    void AddItem(string itemName, Item item)
    {
        switch (itemName)
        {
            case StringsDatabase.Items.Weight:
            case StringsDatabase.Items.HotPepper:
            case StringsDatabase.Items.Lens:
            case StringsDatabase.Items.Voucher:
            case StringsDatabase.Items.PiggyBank:
            case StringsDatabase.Items.DartBoard:
                if (GeneralItems.Any(a => a.ItemName == itemName))
                {
                    GeneralItems.Find(a => a.ItemName == itemName).ItemCount++;
                }
                else
                {
                    GeneralItems.Add(item);
                }
                break;

            case StringsDatabase.Items.Scope:
            case StringsDatabase.Items.BoxOfBullets:
            case StringsDatabase.Items.Matches:
            case StringsDatabase.Items.Blueprint:
            case StringsDatabase.Items.RedBall:
                if (DamageTowerItems.Any(a => a.ItemName == itemName))
                {
                    DamageTowerItems.Find(a => a.ItemName == itemName).ItemCount++;
                }
                else
                {
                    DamageTowerItems.Add(item);
                }
                break;

            case StringsDatabase.Items.Snowflake:
            case StringsDatabase.Items.LiquidNitrogen:
            case StringsDatabase.Items.IceCube:
            case StringsDatabase.Items.Snowball:
            case StringsDatabase.Items.FrozenBottle:
            case StringsDatabase.Items.IceCream:
                if (FreezeTowerItems.Any(a => a.ItemName == itemName))
                {
                    FreezeTowerItems.Find(a => a.ItemName == itemName).ItemCount++;
                }
                else
                {
                    FreezeTowerItems.Add(item);
                }
                break;

            case StringsDatabase.Items.PoisonVial:
            case StringsDatabase.Items.HazardSign:
            case StringsDatabase.Items.MoldyCheese:
            case StringsDatabase.Items.SnotTissue:
            case StringsDatabase.Items.Fungus:
                if (PoisonTowerItems.Any(a => a.ItemName == itemName))
                {
                    PoisonTowerItems.Find(a => a.ItemName == itemName).ItemCount++;
                }
                else
                {
                    PoisonTowerItems.Add(item);
                }
                break;

            case StringsDatabase.Items.Cannonball:
            case StringsDatabase.Items.Dynamite:
            case StringsDatabase.Items.TNTBox:
            case StringsDatabase.Items.Nuke:
            case StringsDatabase.Items.RPG:
            case StringsDatabase.Items.Firework:
                if (BombTowerItems.Any(a => a.ItemName == itemName))
                {
                    BombTowerItems.Find(a => a.ItemName == itemName).ItemCount++;
                }
                else
                {
                    BombTowerItems.Add(item);
                }
                break;
        }
    }
}
