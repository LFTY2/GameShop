using System;
using Project;

namespace Project
{
    [Serializable]
    public class ItemReforgeData : ItemExtraData
    {
        public ReforgeType ReforgeType;

        public ItemReforgeData(ReforgeType reforgeType)
        {
            ReforgeType = reforgeType;
        }
    }
}