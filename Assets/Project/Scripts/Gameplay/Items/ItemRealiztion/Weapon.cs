using System.Collections.Generic;

namespace Project
{
    public class Weapon : Item
    {
        private WeaponItemConfig _weaponItemConfig;
        private readonly List<ReforgeType> _possibleReforge = new()
        {
            ReforgeType.Deadly, ReforgeType.Fast, ReforgeType.Furious, ReforgeType.Godly, ReforgeType.Slow,
            ReforgeType.Trash,
        };
        public override ItemExtraData GenerateExtraData()
        {
            return new ItemReforgeData(_possibleReforge.GetRandom());
        }

        public override void Initialize()
        {
            _weaponItemConfig = CastConfig<WeaponItemConfig>();
            
            //Do something with damage _weaponItemConfig.BaseDamage
        }
    }
}