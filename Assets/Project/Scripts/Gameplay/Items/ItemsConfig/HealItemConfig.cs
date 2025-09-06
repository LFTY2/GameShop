using UnityEngine;

[CreateAssetMenu(menuName = "Config/Items/Heal", fileName = "HealItem")]
public class HealItemConfig : ItemConfig
{
    [field: SerializeField] public int HealAmount { get; private set; }
}