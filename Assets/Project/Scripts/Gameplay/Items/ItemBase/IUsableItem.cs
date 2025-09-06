namespace Project
{
    public interface IUsableItem
    {
        bool RemoveOnUse { get; }
        void Use(Player player);
    }
}