using Project;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemAmount;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private Button _useButton;
    [SerializeField] private Image _itemImage;
    private ItemSlot _itemSlot;
    private Player _player;
    private InventoryModel _inventoryModel;

    public void Awake()
    {
        _player = ModuleContainer.Instance.GetObject<Player>();
        _inventoryModel = ModuleContainer.Instance.GetObject<InventoryModel>();
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
        if (itemSlot.Item.Config.IsStackable)
        {
            _itemAmount.gameObject.SetActive(true);
            _itemAmount.text = $"{_itemSlot.Amount}{SpriteAssetKeys.InventorySprite}";
        }
        else
        {
            _itemAmount.gameObject.SetActive(false);
        }

        _itemImage.sprite = itemSlot.Item.Config.Icon;
        _itemName.text = _itemSlot.Item.Name;
        _itemAmount.gameObject.SetActive(_itemSlot.Item.Config.IsStackable);
    }
    public void Use()
    {
        if (_itemSlot.Item is IUsableItem usable)
        {
            usable.Use(_player);
            _inventoryModel.RemoveItem(_itemSlot, 1);
        }
    }
}