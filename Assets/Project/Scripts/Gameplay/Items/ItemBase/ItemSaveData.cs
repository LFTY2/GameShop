using System;

namespace Project
{
    [Serializable]
    public class ItemSaveData
    {
        public ItemType ItemType;
        public int Amount;
        public ItemExtraData ExtraData;
    }
}