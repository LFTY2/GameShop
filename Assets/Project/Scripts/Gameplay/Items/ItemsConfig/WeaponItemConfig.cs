using UnityEngine;

[CreateAssetMenu(menuName = "Config/Items/Weapon", fileName = "WeaponItem")]
public class WeaponItemConfig : ItemConfig
{
    [field: SerializeField] public int BaseDamage { get; private set; }
    public override bool IsStackable => false; 
}