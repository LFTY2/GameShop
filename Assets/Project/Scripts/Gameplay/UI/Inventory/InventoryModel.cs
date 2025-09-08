using System;
using System.Collections.Generic;

namespace Project
{
    public class InventoryModel : IInitializable
    {
        public event Action OnItemDataChanged;
        public List<ItemSlot> Items { get; private set; } 
        private const string DataKey = "Inventory";
        private ItemCreator _itemCreator;
        public void Initialize()
        {
            _itemCreator = ModuleContainer.Instance.GetObject<ItemCreator>();
            Items = SaveController.Load(DataKey, new List<ItemSlot>());
        }
        public void AddItem(ItemType itemType, int amount = 1)
        {
            Item item = _itemCreator.CreateItem(itemType);
            ItemSlot itemSlot = new ItemSlot(item, amount);
            AddItem(itemSlot);
        }

        public void AddItem(ItemSlot itemSlot)
        {
            if (!itemSlot.Item.Config.IsStackable)
            {
                Items.Add(itemSlot);
            }
            else
            {
                bool isStacked = false;
                foreach (var item in Items)
                {
                    if (item.Item.ItemType == itemSlot.Item.ItemType)
                    {
                        item.Amount += item.Amount;
                        isStacked = true;
                    }
                }

                if (!isStacked)
                {
                    Items.Add(itemSlot);
                }
            }
            OnDataChange();
        }

        //Example of use: pressing on item in inventory 
        public bool TryUseItem(ItemSlot itemSlot, Player player)
        {
            if (itemSlot.Item is IUsableItem usableItem && itemSlot.Amount > 0)
            {
                usableItem.Use(player);
                if (usableItem.RemoveOnUse)
                {
                    itemSlot.Amount--;
                    OnDataChange();
                }
                
                return true;
            }
            return false;
        }

        //Example of use: pressing hotkey to use heal potion, finds all heal potions ready to use
        public List<ItemSlot> GetItemsOfType<T>(T type) where T : ItemConfig
        {
            List<ItemSlot> items = new ();
            foreach (var item in Items)
            {
                if (item.Item.Config is T)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        private void OnDataChange()
        {
            OnItemDataChanged?.Invoke();
            SaveController.Save(DataKey, Items);
        }

        
    }
}