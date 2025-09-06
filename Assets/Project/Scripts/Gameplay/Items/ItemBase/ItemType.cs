using System;
using System.Collections.Generic;
using static Project.ItemType;

namespace Project
{
    public enum ItemType
    {
        Gel = 0,
        IronBar = 1,
        BeeWax = 2,
        CrimtaneOre = 3,
        SmallHealPotion = 4,
        MediumHealPotion = 5,
        LargeHealPotion = 6,
        Helmet = 7,
        Chestplate = 8,
        Boots = 9,
        Bow = 10,
        Sword = 11,
        MagicWand = 12,
        RecallPotion = 13,
    }

    
    //Not the best solution to bind Item and Config but what other solutions could be
    //With odin inspector you can serialize System.Type so you bind both Type and Config in inspector in one place. Best solution at my opinion, but cant use assets here
    //Each item has separate class with ItemType hardcoded in it (worst variant for me)
    public static class ItemBind
    {
        private static readonly Dictionary<ItemType, Type> ItemTypes = new()
        {
            { Gel, typeof(SimpleItem) },
            { IronBar, typeof(SimpleItem) },
            { BeeWax, typeof(SimpleItem) },
            { CrimtaneOre, typeof(SimpleItem) },
            { SmallHealPotion, typeof(HealPotion) },
            { MediumHealPotion, typeof(HealPotion) },
            { LargeHealPotion, typeof(HealPotion) },
            { RecallPotion, typeof(RecallItem) },
            { Helmet, typeof(Equipment) },
            { Chestplate, typeof(Equipment) },
            { Boots, typeof(Equipment) },
            { Bow, typeof(Weapon) },
            { Sword, typeof(Weapon) },
            { MagicWand, typeof(Weapon) },
        };

        public static Type GetItem(ItemType itemType)
        {
            if (ItemTypes.TryGetValue(itemType, out var item))
            {
                return item;
            }

            throw new Exception($"Missing {itemType} in ItemBind. You have to bind item with {itemType} type in ItemBind script.");
        }
    }
}