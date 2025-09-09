using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class Weapon : Item
    {
        private WeaponItemConfig _weaponItemConfig;
        public override string Name => $"{_reforgeData.ReforgeType} {Config.Name}";
        private ItemReforgeData _reforgeData;
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
            _reforgeData = ExtraData as ItemReforgeData;
            //Do something with damage _weaponItemConfig.BaseDamage
        }
    }
}