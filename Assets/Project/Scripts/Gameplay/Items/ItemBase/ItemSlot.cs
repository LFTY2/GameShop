namespace Project
{
    //Represent item in inventory or storage
    public class ItemSlot
    {
        public Item Item;
        public int Amount;
        
        public ItemSaveData GetSaveItemData()
        {
            return new ItemSaveData() { ItemType = Item.ItemType, Amount = Amount, ExtraData = Item.ExtraData };
        }
    }
}