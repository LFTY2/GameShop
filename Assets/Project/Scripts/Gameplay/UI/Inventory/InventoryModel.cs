using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class InventoryModel : IInitializable
    {
        public event Action OnItemDataChanged;
        public List<ItemSlot> Items { get; private set; } = new();
        private const string DataKey = "Inventory";
        private ItemCreator _itemCreator;
        public void Initialize()
        {
            _itemCreator = ModuleContainer.Instance.GetObject<ItemCreator>();
            List<ItemSaveData> itemSaveData = SaveController.Load(DataKey, new InventoryData()).ItemSaveData;
            foreach (var saveData in itemSaveData)
            {
                Item item = _itemCreator.CreateItem(saveData.ItemType, saveData.GetExtraData());
                ItemSlot itemSlot = new ItemSlot(item, saveData.Amount);
                Items.Add(itemSlot);
            }
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
                        item.Amount += itemSlot.Amount;
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
            SaveItems();
        }

        public void SaveItems()
        {
            List<ItemSaveData> itemSaveData = new();
            foreach (var item in Items)
            {
                itemSaveData.Add(item.GetSaveItemData());
            }
            SaveController.Save(DataKey, new InventoryData(itemSaveData));
        }


        public void RemoveItem(ItemSlot itemSlot, int amount = 1)
        {
            if (Items.Contains(itemSlot))
            {
                itemSlot.Amount--;
                if (itemSlot.Amount <= 0)
                {
                    Items.Remove(itemSlot);
                }
                OnDataChange();
            }
            else
            {
                Debug.LogError($"Item not exits in this model");
            }
        }
    }

    [Serializable]
    public class InventoryData
    {
        public List<ItemSaveData> ItemSaveData;
        public InventoryData()
        {
            ItemSaveData = new();
        }

        public InventoryData(List<ItemSaveData> itemSaveData)
        {
            ItemSaveData = itemSaveData;
        }
    }
}