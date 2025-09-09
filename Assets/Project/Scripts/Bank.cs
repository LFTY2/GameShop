using System;

namespace Project
{
    public class Bank
    {
        private const string Key = "Coins";
        public CoinsAmount CoinsAmount { get; private set; } = SaveController.Load(Key, new CoinsAmount(10000));
        public event Action<int> OnChange;
        
        public int Coins => CoinsAmount.Coins;

        public void AddCoins(int amount)
        {
            CoinsAmount.Coins += amount;
            OnCoinsChange();
        }

        public bool TrySpendCoins(int amount)
        {
            if (Coins >= amount)
            {
                CoinsAmount.Coins -= amount;
                OnCoinsChange();
                return true;
            }
            return false;
        }

      
        public void OnCoinsChange()
        {
            OnChange?.Invoke(Coins);
            SaveController.Save(Key, CoinsAmount);
        }
    }
    
    [Serializable]
    public class CoinsAmount
    {
        public int Coins;

        public CoinsAmount(int coins)
        {
            Coins = coins;
        }
    }
}