using System;
using Project;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinAmount;
    private Bank _bank;
    public void Start()
    {
        _bank = ModuleContainer.Instance.GetObject<Bank>();
        OnEnable();
    }

    public void OnEnable()
    {
        if (_bank != null)
        {
            _bank.OnChange += SyncCoins;
            SyncCoins(_bank.Coins);
        }
    }

    public void SyncCoins(int amount)
    {
        _coinAmount.text = $"{_bank.Coins}{SpriteAssetKeys.CoinSprite}";
    }

    public void OnDisable()
    {
        if (_bank != null)
        {
            _bank.OnChange -= SyncCoins;
        }
    }
}
