namespace Project
{
    public class ItemCreator : MapCreator<ItemType, ItemConfig>
    {
        public void Awake()
        {
            Initialize();
        }

        public T CreateItem<T>(ItemType itemType) where T : Item, new()
        {
            T item = new T();
            item.CreateNewItem(GetObject(itemType), itemType);
            return item;
        }

        public T CreateItem<T>(ItemType itemType, ItemExtraData itemExtraData) where T : Item, new()
        {
            T item = new T();
            item.LoadItem(GetObject(itemType), itemType, itemExtraData);
            return item;
        }
    }


    public enum ItemType
    {
        Item1 = 0,
        Item2 = 1,
        Item3 = 2,
    }
}