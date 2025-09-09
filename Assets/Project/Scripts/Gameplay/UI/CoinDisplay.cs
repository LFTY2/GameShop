using System;
using Project;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinAmount;
    private Bank _bank;

    public void Awake()
    {
        _bank = ModuleContainer.Instance.GetObject<Bank>();
    }

    
    public void OnEnable()
    {
        _bank.OnChange += SyncCoins;
        SyncCoins(_bank.Coins);
    }

    public void SyncCoins(int amount)
    {
        _coinAmount.text = $"{_bank.Coins}{SpriteAssetKeys.CoinSprite}";
    }

    public void OnDisable()
    {
        _bank.OnChange -= SyncCoins;
    }
}
