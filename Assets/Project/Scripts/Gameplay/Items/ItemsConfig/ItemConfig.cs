using UnityEngine;

public abstract class ItemConfig : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int BasePrice { get; private set; }
    public virtual bool IsStackable => true;
}