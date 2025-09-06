using System.Collections.Generic;
using Project;
using UnityEngine;

public class InventoryControllerView : MenuBase
{
    [SerializeField] private ItemCell _itemCell;
    [SerializeField] private RectTransform _content;
    private InventoryModel _inventoryModel;
    private ObjectPool<ItemCell> _itemCellPool;
    private List<ItemCell> _activeItemCells = new();
    private void Start()
    {
        SpawnContent();
        _inventoryModel.OnItemDataChanged += SpawnContent;
        _itemCellPool = new ObjectPool<ItemCell>(_itemCell, 3, _content);
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