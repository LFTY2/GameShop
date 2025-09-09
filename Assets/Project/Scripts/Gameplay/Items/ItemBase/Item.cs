using System;
using Unity.VisualScripting;

namespace Project
{
    //Base of any Item
    public abstract class Item
    {
        public ItemConfig Config;
        public ItemExtraData ExtraData;
        public ItemType ItemType;
        public virtual string Name => Config.Name;
        public void LoadItem(ItemConfig config, ItemType itemType, ItemExtraData extraData)
        {
            Config = config;
            ExtraData = extraData;
            ItemType = itemType;
            Initialize();
        }
        public void CreateNewItem(ItemConfig config, ItemType itemType)
        {
            Config = config;
            ExtraData = GenerateExtraData();
            ItemType = itemType;
            Initialize();
        }

        public virtual ItemExtraData GenerateExtraData()
        {
            return null;
        }

        public virtual void Initialize()
        {
            
        }

        public T CastConfig<T>() where T : ItemConfig
        {
            if (Config is T castedConfig)
            {
                return Config as T;
            }
            else
            {
                throw new InvalidCastException(
                    $"Created Item {GetType().Name} of type {ItemType} needs a config of type {typeof(T).FullName}. Wrong config added in ItemCreator!");
            }
        }
    }
}