using System.Collections.Generic;
using Project;
using Project.Gameplay.UI;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MenuBase
{
    [SerializeField] private ItemCell _itemCell;
    [SerializeField] private Button _shopButton;
    [SerializeField] private RectTransform _content;
    private InventoryModel _inventoryModel;
    private ObjectPool<ItemCell> _itemCellPool;
    private List<ItemCell> _activeItemCells = new();
    private SwitchMenu _switchMenu;

    private void Start()
    {
        _switchMenu = ModuleContainer.Instance.GetObject<SwitchMenu>();
        _shopButton.onClick.AddListener(OpenShop);
        SpawnContent();
        _inventoryModel.OnItemDataChanged += SpawnContent;
        _itemCellPool = new ObjectPool<ItemCell>(_itemCell, 3, _content);
    }

    private void OpenShop()
    {
        _switchMenu.OpenMenu(false);
    }

    public void SpawnContent()
    {
        foreach (var buyButton in _activeItemCells)
        {
            buyButton.gameObject.SetActive(false);
        }
        _activeItemCells.Clear();

        foreach (var itemSlot in _inventoryModel.Items)
        {
            ItemCell itemCell = _itemCellPool.GetObject();
            itemCell.Initialize(itemSlot);
        }
    }
}