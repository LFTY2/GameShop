using System;

namespace Project
{
    public class ItemCreator : MapCreator<ItemType, ItemConfig>
    {
        public void Awake()
        {
            Initialize();
        }

        public Item CreateItem(ItemType itemType)
        {
            Type type = ItemBind.GetItem(itemType);
            Item item = (Item)Activator.CreateInstance(type);
    
            item.CreateNewItem(GetObject(itemType), itemType);
            return item;
        }

        public Item CreateItem(ItemType itemType, ItemExtraData itemExtraData)
        {
            Type type = ItemBind.GetItem(itemType);
            Item item = (Item)Activator.CreateInstance(type);
            item.LoadItem(GetObject(itemType), itemType, itemExtraData);
            return item;
        }
    }
}