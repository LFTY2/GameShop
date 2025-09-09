using System;

namespace Project
{
    [Serializable]
    public class ItemSaveData
    {
        public ItemType ItemType;
        public int Amount;
        public string ExtraData;

        public ItemExtraData GetExtraData()
        {
            return SaveController.ConvertToData<ItemExtraData>(ExtraData, null);
        }
    }
}