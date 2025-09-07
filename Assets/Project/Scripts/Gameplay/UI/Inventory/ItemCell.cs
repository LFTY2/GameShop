using System;
using Project;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemAmount;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private Button _useButton;
    private ItemSlot _itemSlot;
    private Player _player;

    public void Start()
    {
        _player = ModuleContainer.Instance.GetObject<Player>();
    }

    private void OnEnable()
    {
        _useButton.onClick.AddListener(Use);
    }

    private void OnDisable()
    {
        _useButton.onClick.RemoveListener(Use);
    }

    public void Initialize(ItemSlot itemSlot)
    {
        _itemSlot = itemSlot;
        _useButton.interactable = itemSlot.Item is IUsableItem;
        _itemAmount.text = _itemSlot.Amount.ToString();
        _itemName.text = _itemSlot.Item.Config.Name;
        _itemAmount.gameObject.SetActive(_itemSlot.Item.Config.IsStackable);
    }
    public void Use()
    {
        (_itemSlot.Item as IUsableItem).Use(_player);
    }
}