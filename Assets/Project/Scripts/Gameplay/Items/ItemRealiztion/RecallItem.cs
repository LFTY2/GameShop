namespace Project
{
    public class RecallItem : Item, IUsableItem
    {
        public bool RemoveOnUse => true;
        public void Use(Player player)
        {
            player.TeleportHome();
        }
    }
}