namespace Project
{
    public class Teleporter : Item, IUsableItem
    {
        public bool RemoveOnUse => true;
        public void Use(Player player)
        {
            player.TeleportHome();
        }
    }
}