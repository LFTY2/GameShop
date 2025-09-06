using System;

namespace Project
{
    public class Bank
    {
        public int Coins { get; private set; }
        public event Action<int> OnChange;

        public void AddCoins(int amount)
        {
            Coins += amount;
            OnChange?.Invoke(Coins);
        }

        public bool TrySpendCoins(int amount)
        {
            if (Coins >= amount)
            {
                Coins -= amount;
                OnChange?.Invoke(Coins);
                return true;
            }
            return false;
        }
    }
}