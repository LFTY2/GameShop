namespace Project
{
    //Represent item in inventory or storage
    public class ItemSlot
    {
        public Item Item;
        public int Amount;

        public ItemSlot(Item item, int amount)
        {
            Item = item;
            Amount = amount;
        }

        public ItemSaveData GetSaveItemData()
        {
            return new ItemSaveData() { ItemType = Item.ItemType, Amount = Amount, ExtraData = SaveController.ConvertToJson(Item.ExtraData) };
        }
    }
}