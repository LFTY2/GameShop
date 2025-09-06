using UnityEngine;

[CreateAssetMenu(menuName = "Config/Items/Equipment", fileName = "EquipmentItem")]
public class EquipmentItemConfig : ItemConfig
{
    [field: SerializeField] public int AttackBonus { get; private set; }
}