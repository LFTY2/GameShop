using System;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class ShopController : MenuBase
{
    [SerializeField] private List<ItemType> _listedItemsOnSell;
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private RectTransform _content;
    private List<BuyButton> _activeBuyButtons = new();
    private ObjectPool<BuyButton> _buyButtonPool;
    public void Start()
    {
        _buyButtonPool = new ObjectPool<BuyButton>(_buyButton, 10, _content);
        SpawnContent();
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