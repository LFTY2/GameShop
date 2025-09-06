namespace Project
{
    public class HealPotion : Item, IUsableItem
    {
        private HealItemConfig _healItemConfig;
        public override void Initialize()
        {
            _healItemConfig = CastConfig<HealItemConfig>();
        }
        public bool RemoveOnUse => true;
        public void Use(Player player)
        {
            player.Heal(_healItemConfig.HealAmount);
        }
    }
}