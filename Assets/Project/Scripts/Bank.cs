using System;

namespace Project
{
    public class Bank : IInitializable
    {
        private const string Key = "Coins";
        public int Coins { get; private set; }
        public event Action<int> OnChange;

        public void AddCoins(int amount)
        {
            Coins += amount;
            OnCoinsChange();
        }

        public bool TrySpendCoins(int amount)
        {
            if (Coins >= amount)
            {
                Coins -= amount;
                OnCoinsChange();
                return true;
            }
            return false;
        }

        public void Initialize()
        {
            Coins = SaveController.Load(Key, 1000);
        }

        public void OnCoinsChange()
        {
            OnChange?.Invoke(Coins);
            SaveController.Save(Key, Coins);
        }
    }
}