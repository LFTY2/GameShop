using System;
using System.Collections.Generic;
using Project;
using Project.Gameplay.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopController : MenuBase
{
    [SerializeField] private List<ItemType> _listedItemsOnSell;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private RectTransform _content;
    [SerializeField] private Button _inventoryButton;
    private List<BuyButton> _activeBuyButtons = new();
    private ObjectPool<BuyButton> _buyButtonPool;
    private SwitchMenu _switchMenu;
    public void Start()
    {
        _switchMenu = ModuleContainer.Instance.GetObject<SwitchMenu>();
        _inventoryButton.onClick.AddListener(OpenInventory);
        _buyButtonPool = new ObjectPool<BuyButton>(_buyButton, 10, _content);
        SpawnContent();
    }

    private void OpenInventory()
    {
        _switchMenu.OpenMenu(false);
    }

    private void SpawnContent()
    {
        foreach (var buyButton in _activeBuyButtons)
        {
            buyButton.gameObject.SetActive(false);
        }
        _activeBuyButtons.Clear();

        foreach (var itemType in _listedItemsOnSell)
        {
            BuyButton buyButton = _buyButtonPool.GetObject();
            buyButton.Initialize(itemType);
        }
    }
}