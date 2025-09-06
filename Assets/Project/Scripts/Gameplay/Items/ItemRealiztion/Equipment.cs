namespace Project
{
    public class Equipment : Item, IUsableItem
    {
        private EquipmentItemConfig _equipItemConfig;
        public override void Initialize()
        {
            _equipItemConfig = CastConfig<EquipmentItemConfig>();
        }
        public bool RemoveOnUse => true;
        public void Use(Player player)
        {
            player.Heal(_equipItemConfig.AttackBonus);
        }
    }
}