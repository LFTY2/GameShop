using Project;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class BuyButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private TMP_Text _name;
        private InventoryModel _inventoryModel;
        private ItemCreator _itemCreator;
        private ItemType _itemType;
        private ItemConfig _itemConfig;
        private Bank _bank;

        public void Start()
        {
            _bank = ModuleContainer.Instance.GetObject<Bank>();
            _itemCreator = ModuleContainer.Instance.GetObject<ItemCreator>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnBuy);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnBuy);
        }

        public void Initialize(ItemType itemType)
        {
            _itemType = itemType;
            _itemConfig = _itemCreator.GetObject(itemType);
            _icon.sprite = _itemConfig.Icon;
            _price.text = $"{_itemConfig.BasePrice}{SpriteAssetKeys.CoinSprite}";
            _name.text = _itemConfig.Name;
        }
        
        private void OnBuy()
        {
            if (_bank.TrySpendCoins(_itemConfig.BasePrice))
            {
                _inventoryModel.AddItem(_itemType);
            }
        }
    }
}