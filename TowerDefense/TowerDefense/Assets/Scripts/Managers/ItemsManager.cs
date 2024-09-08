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
    public int? ItemCount { get; set; } = 0;
    public object[] Changes { get; set; }
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

    public int MarkDanageBonus = 30; //30%

    private void Awake()
    {
        SetAllItems();

        //For testing
        AddItemToInventory(StringsDatabase.Items.Weight, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Weight));
        AddItemToInventory(StringsDatabase.Items.Weight, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Weight));
        AddItemToInventory(StringsDatabase.Items.HotPepper, AllItems.Find(a => a.ItemName == StringsDatabase.Items.HotPepper));
        AddItemToInventory(StringsDatabase.Items.Lens, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Lens));
        AddItemToInventory(StringsDatabase.Items.Voucher, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Voucher));
        AddItemToInventory(StringsDatabase.Items.PiggyBank, AllItems.Find(a => a.ItemName == StringsDatabase.Items.PiggyBank));
        AddItemToInventory(StringsDatabase.Items.DartBoard, AllItems.Find(a => a.ItemName == StringsDatabase.Items.DartBoard));
        AddItemToInventory(StringsDatabase.Items.Scope, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Scope));
        AddItemToInventory(StringsDatabase.Items.BoxOfBullets, AllItems.Find(a => a.ItemName == StringsDatabase.Items.BoxOfBullets));
        AddItemToInventory(StringsDatabase.Items.Matches, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Matches));
        AddItemToInventory(StringsDatabase.Items.Blueprint, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Blueprint));
        AddItemToInventory(StringsDatabase.Items.RedBall, AllItems.Find(a => a.ItemName == StringsDatabase.Items.RedBall));
        AddItemToInventory(StringsDatabase.Items.Snowflake, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Snowflake));
        AddItemToInventory(StringsDatabase.Items.LiquidNitrogen, AllItems.Find(a => a.ItemName == StringsDatabase.Items.LiquidNitrogen));
        AddItemToInventory(StringsDatabase.Items.IceCube, AllItems.Find(a => a.ItemName == StringsDatabase.Items.IceCube));
        AddItemToInventory(StringsDatabase.Items.Snowball, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Snowball));
        AddItemToInventory(StringsDatabase.Items.FrozenBottle, AllItems.Find(a => a.ItemName == StringsDatabase.Items.FrozenBottle));
        AddItemToInventory(StringsDatabase.Items.IceCream, AllItems.Find(a => a.ItemName == StringsDatabase.Items.IceCream));
        AddItemToInventory(StringsDatabase.Items.PoisonVial, AllItems.Find(a => a.ItemName == StringsDatabase.Items.PoisonVial));
        AddItemToInventory(StringsDatabase.Items.HazardSign, AllItems.Find(a => a.ItemName == StringsDatabase.Items.HazardSign));
        AddItemToInventory(StringsDatabase.Items.MoldyCheese, AllItems.Find(a => a.ItemName == StringsDatabase.Items.MoldyCheese));
        AddItemToInventory(StringsDatabase.Items.SnotTissue, AllItems.Find(a => a.ItemName == StringsDatabase.Items.SnotTissue));
        AddItemToInventory(StringsDatabase.Items.Fungus, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Fungus));
        AddItemToInventory(StringsDatabase.Items.Cannonball, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Cannonball));
        AddItemToInventory(StringsDatabase.Items.Dynamite, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Dynamite));
        AddItemToInventory(StringsDatabase.Items.TNTBox, AllItems.Find(a => a.ItemName == StringsDatabase.Items.TNTBox));
        AddItemToInventory(StringsDatabase.Items.Nuke, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Nuke));
        AddItemToInventory(StringsDatabase.Items.RPG, AllItems.Find(a => a.ItemName == StringsDatabase.Items.RPG));
        AddItemToInventory(StringsDatabase.Items.Firework, AllItems.Find(a => a.ItemName == StringsDatabase.Items.Firework));
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
            ItemDescription = "Increases Tower Damage By 5 <color=grey>(+ 5 per item stack)</color>",
            Changes = new object[] { 5 }
        };

        Item hotPepper = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.HotPepperSprite,
            ItemName = StringsDatabase.Items.HotPepper,
            ItemDescription = "Increasess Tower Fire Rate by 10% <color=grey>(+ 10% per item stack)</color>",
            Changes = new object[] { 0.1f }
        };

        Item lens = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.LensSprite,
            ItemName = StringsDatabase.Items.Lens,
            ItemDescription = "Increases Tower Range by 1 m <color=grey>(+ 1 m per item stack)</color>",
            Changes = new object[] { 1f }
        };

        Item voucher = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.VoucherSprite,
            ItemName = StringsDatabase.Items.Voucher,
            ItemDescription = "Reduce the cost of the Tower that it is placed on by 2 <color=grey>(+ 2 per item stack)</color>. (Max 6)",
            Changes = new object[] { 2 }
        };

        Item piggyBank = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.PiggyBankSprite,
            ItemName = StringsDatabase.Items.PiggyBank,
            ItemDescription = "Generate +1 coin <color=grey>(+ 1 per item stack)</color> per kill. This works for all towers",
            Changes = new object[] { 1 }
        };

        Item dartBoard = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.DartBoardSprite,
            ItemName = StringsDatabase.Items.DartBoard,
            ItemDescription = "Gain 10% <color=grey>(+ 10% per item stack)</color> chance to deal Critical Damage. Critical Damage is x2 Damage",
            Changes = new object[] { 10 }
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
            ItemDescription = "Increases Critical Chance by 10% <color=grey>(+ 10% per item stack)</color> and 5% <color=grey>(+ 5% per item stack)</color> chance to Mark an enemy. Enemies that are marked will take 30% more damage",
            Changes = new object[] { 10, 5 }
        };

        Item boxOfBullets = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.BoxOfBulletSprite,
            ItemName = StringsDatabase.Items.BoxOfBullets,
            ItemDescription = "Increases Two Round Burst and Three Round Burst Chance by 5% <color=grey>(+ 5% per item stack)</color>",
            Changes = new object[] { 5, 5 }
        };

        Item matches = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.MatchesSprite,
            ItemName = StringsDatabase.Items.Matches,
            ItemDescription = "Damage Towers have a 5% <color=grey>(+ 5% per item stack)</color> chance to inflict an enemy with Burn. Burned targets take 2 <color=grey>(+ 2 per item stack)</color> damage per tick, Burn Duration is 2 <color=grey>(+ 2 per item stack)</color> seconds and Burn Tick Rate is 5 times per second",
            Changes = new object[] { 10, 2, 2f, 0.2f}
        };

        Item blueprint = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.BlueprintSprite,
            ItemName = StringsDatabase.Items.Blueprint,
            ItemDescription = "All Damage Towers, currently on the field and future Damage Towers will gain 5 <color=grey>(+ 5 per item stack)</color> damage",
            Changes = new object[] { 5 }
        };

        Item redBall = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.RedBallSprite,
            ItemName = StringsDatabase.Items.RedBall,
            ItemDescription = "Damage Tower has 5% <color=grey>(+ 5% per item stack)</color> chance to deal Super Damage. Super Damage is x5 Damage",
            Changes = new object[] { 5 }
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
            ItemDescription = "Increase Slow Duration by 1 <color=grey>(+ 1 per item stack)</color> second",
            Changes = new object[] { 1f }
        };

        Item liquidNitrogen = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.LiquidNitrogenSprite,
            ItemName = StringsDatabase.Items.LiquidNitrogen,
            ItemDescription = "Increase Slow Effect by 10% <color=grey>(+ 10% per item stack)</color>",
            Changes = new object[] { 10f }

        };

        Item iceCube = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.IceCubeSprite,
            ItemName = StringsDatabase.Items.IceCube,
            ItemDescription = "Increase Ice Damage By 6 <color=grey>(+ 6 per item stack)</color> or Increase Frostbite Damage Over Time by 3 <color=grey>(+ 3 per item stack)</color>",
            Changes = new object[] { 6, 3 }
        };

        Item snowball = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.SnowballSprite,
            ItemName = StringsDatabase.Items.Snowball,
            ItemDescription = "Gain 5% <color=grey>(+ 5% per item stack)</color> chance to shoot a snowball at an enemy at a random enemy, stunning them for 1 <color=grey>(+ 0.5 per item stack)</color> seconds. Snowball deals 5 <color=grey>(+ 5 per item stack)</color> damage",
            Changes = new object[] { 5, 1f, 0.5f, 5 }
        };

        Item frozenBottle = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.FrozenBottleSprite,
            ItemName = StringsDatabase.Items.FrozenBottle,
            ItemDescription = "Icicle Spawn Chance increased by 5% <color=grey>(+ 5% per item stack)</color>",
            Changes = new object[] { 5 }
        };

        Item icecream = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.IcecreamSprite,
            ItemName = StringsDatabase.Items.IceCream,
            ItemDescription = "Increase Immobilize Chance by 5% <color=grey>(+ 5% per item stack)</color>",
            Changes = new object[] { 5 }
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
            ItemDescription = "Increase Poison Damage Over Time by 2 <color=grey>(+ 2 per item stack)</color>",
            Changes = new object[] { 2 }
        };

        Item hazardSign = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.HazardSignSprite,
            ItemName = StringsDatabase.Items.HazardSign,
            ItemDescription = "Increases Poison Duration by 1 <color=grey>(+ 1 per item stack)</color> second",
            Changes = new object[] { 1f }
        };

        Item moldyCheese = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.MoldyCheeseSprite,
            ItemName = StringsDatabase.Items.MoldyCheese,
            ItemDescription = "Increase Poison Tick Rate by 0.1 <color=grey>(+ 0.1 per item stack)</color> seconds",
            Changes = new object[] { 0.1f }
        };

        Item snotTissue = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.SnotTissueSprite,
            ItemName = StringsDatabase.Items.SnotTissue,
            ItemDescription = "Poison Tick Rate has 5% <color=grey>(+ 5% per item stack)</color> chance to trigger twice",
            Changes = new object[] { 5 }
        };

        Item fungus = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.FungusSprite,
            ItemName = StringsDatabase.Items.Fungus,
            ItemDescription = "Increase All Poison Critical Chance by 5% <color=grey>(+ 5% per item stack)</color>",
            Changes = new object[] { 5 }
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
            ItemDescription = "Increase Damage and Splash Damage by 5 <color=grey>(+ 5 per item stack)</color>",
            Changes = new object[] { 5, 5 }
        };

        Item dynamite = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.DynamiteSprite,
            ItemName = StringsDatabase.Items.Dynamite,
            ItemDescription = "Increases Splash Radius by 1 m <color=grey>(+ 1 m per item stack)</color>",
            Changes = new object[] { 1f }
        };

        Item tntBox = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.TNTBoxSprite,
            ItemName = StringsDatabase.Items.TNTBox,
            ItemDescription = "Explosion happens after 1 <color=grey>(+ 1 per item stack)</color> seconds but increases Splash Damage by 10 <color=grey>(+ 10 per item stack)</color> and Splash Radius by 1 m <color=grey>(+ 1 m per item stack)</color>",
            Changes = new object[] { 1, 10 , 1f }
        };

        Item nuke = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.NukeSprite,
            ItemName = StringsDatabase.Items.Nuke,
            ItemDescription = "Gain 5% <color=grey>(+ 5% per item stack)</color> chance for this tower to deal Splash Damage to all enemies",
            Changes = new object[] { 5 }
        };

        Item rpg = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.RPGSprite,
            ItemName = StringsDatabase.Items.RPG,
            ItemDescription = "Increase Rocket Spawn Chance by 10% <color=grey>(+ 10% per item stack)</color>",
            Changes = new object[] { 10 }
        };

        Item firework = new Item()
        {
            ItemSprite = ReferencesManager.SpriteManager.FireworkSprite,
            ItemName = StringsDatabase.Items.Firework,
            ItemDescription = "Increase Double Explosion Chance by 10% <color=grey>(+ 10% per item stack)</color>",
            Changes = new object[] { 10 }
        };

        AllItems.Add(cannonball);
        AllItems.Add(dynamite);
        AllItems.Add(tntBox);
        AllItems.Add(nuke);
        AllItems.Add(rpg);
        AllItems.Add(firework);
    }

    public void AddItemToInventory(string itemName, Item item)
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
                    item.ItemCount++;
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
                    item.ItemCount++;
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
                    item.ItemCount++;
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
                    item.ItemCount++;
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
                    item.ItemCount++;
                    BombTowerItems.Add(item);
                }
                break;
        }
    }

    public void ReduceItemFromInventory(string itemName, Item item)
    {
        switch (itemName)
        {
            case StringsDatabase.Items.Weight:
            case StringsDatabase.Items.HotPepper:
            case StringsDatabase.Items.Lens:
            case StringsDatabase.Items.Voucher:
            case StringsDatabase.Items.PiggyBank:
            case StringsDatabase.Items.DartBoard:
                if (GeneralItems.Any(a => a.ItemName == itemName) && GeneralItems.Find(a => a.ItemName == itemName).ItemCount > 1)
                {
                    GeneralItems.Find(a => a.ItemName == itemName).ItemCount--;
                }
                else if (GeneralItems.Any(a => a.ItemName == itemName) && GeneralItems.Find(a => a.ItemName == itemName).ItemCount == 1)
                {
                    GeneralItems.Find(a => a.ItemName == itemName).ItemCount--;
                    GeneralItems.Remove(item);
                }
                break;

            case StringsDatabase.Items.Scope:
            case StringsDatabase.Items.BoxOfBullets:
            case StringsDatabase.Items.Matches:
            case StringsDatabase.Items.Blueprint:
            case StringsDatabase.Items.RedBall:
                if (DamageTowerItems.Any(a => a.ItemName == itemName) && DamageTowerItems.Find(a => a.ItemName == itemName).ItemCount > 1)
                {
                    DamageTowerItems.Find(a => a.ItemName == itemName).ItemCount--;
                }
                else if (DamageTowerItems.Any(a => a.ItemName == itemName) && DamageTowerItems.Find(a => a.ItemName == itemName).ItemCount == 1)
                {
                    DamageTowerItems.Find(a => a.ItemName == itemName).ItemCount--;
                    DamageTowerItems.Remove(item);
                }
                break;

            case StringsDatabase.Items.Snowflake:
            case StringsDatabase.Items.LiquidNitrogen:
            case StringsDatabase.Items.IceCube:
            case StringsDatabase.Items.Snowball:
            case StringsDatabase.Items.FrozenBottle:
            case StringsDatabase.Items.IceCream:
                if (FreezeTowerItems.Any(a => a.ItemName == itemName) && FreezeTowerItems.Find(a => a.ItemName == itemName).ItemCount > 1)
                {
                    FreezeTowerItems.Find(a => a.ItemName == itemName).ItemCount--;
                }
                else if (FreezeTowerItems.Any(a => a.ItemName == itemName) && FreezeTowerItems.Find(a => a.ItemName == itemName).ItemCount == 1)
                {
                    FreezeTowerItems.Find(a => a.ItemName == itemName).ItemCount--;
                    FreezeTowerItems.Remove(item);
                }
                break;

            case StringsDatabase.Items.PoisonVial:
            case StringsDatabase.Items.HazardSign:
            case StringsDatabase.Items.MoldyCheese:
            case StringsDatabase.Items.SnotTissue:
            case StringsDatabase.Items.Fungus:
                if (PoisonTowerItems.Any(a => a.ItemName == itemName) && PoisonTowerItems.Find(a => a.ItemName == itemName).ItemCount > 1)
                {
                    PoisonTowerItems.Find(a => a.ItemName == itemName).ItemCount--;
                }
                else if (PoisonTowerItems.Any(a => a.ItemName == itemName) && PoisonTowerItems.Find(a => a.ItemName == itemName).ItemCount == 1)
                {
                    PoisonTowerItems.Find(a => a.ItemName == itemName).ItemCount--;
                    PoisonTowerItems.Remove(item);
                }
                break;

            case StringsDatabase.Items.Cannonball:
            case StringsDatabase.Items.Dynamite:
            case StringsDatabase.Items.TNTBox:
            case StringsDatabase.Items.Nuke:
            case StringsDatabase.Items.RPG:
            case StringsDatabase.Items.Firework:
                if (BombTowerItems.Any(a => a.ItemName == itemName) && BombTowerItems.Find(a => a.ItemName == itemName).ItemCount > 1)
                {
                    BombTowerItems.Find(a => a.ItemName == itemName).ItemCount--;
                }
                else if (BombTowerItems.Any(a => a.ItemName == itemName) && BombTowerItems.Find(a => a.ItemName == itemName).ItemCount == 1)
                {
                    BombTowerItems.Find(a => a.ItemName == itemName).ItemCount--;
                    BombTowerItems.Remove(item);
                }
                break;
        }
    }
}
