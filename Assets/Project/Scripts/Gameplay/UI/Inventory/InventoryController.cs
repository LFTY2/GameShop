using System.Collections.Generic;
using Project;
using Project.Gameplay.UI;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MenuBase
{
    [SerializeField] private InventoryCell _itemCell;
    [SerializeField] private Button _shopButton;
    [SerializeField] private RectTransform _content;
    private InventoryModel _inventoryModel;
    private ObjectPool<InventoryCell> _itemCellPool;
    private List<InventoryCell> _activeItemCells = new();
    private SwitchMenu _switchMenu;

    public void Awake()
    {
        _switchMenu = ModuleContainer.Instance.GetObject<SwitchMenu>();
        _inventoryModel = ModuleContainer.Instance.GetObject<InventoryModel>();
    }

    public void Initialize()
    {
        _shopButton.onClick.AddListener(OpenShop);
        _inventoryModel.OnItemDataChanged += SpawnContent;
        _itemCellPool = new ObjectPool<InventoryCell>(_itemCell, 3, _content);
        SpawnContent();
    }

    private void OpenShop()
    {
        _switchMenu.OpenMenu(true);
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
            InventoryCell itemCell = _itemCellPool.GetObject();
            itemCell.Initialize(itemSlot);
            _activeItemCells.Add(itemCell);
        }
    }
}