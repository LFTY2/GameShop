using UnityEngine;

public class Player
{
    private int _maxHealth = 100;
    public int Health { get; private set; } = 50;
    public int Damage { get; private set; }

    public void Heal(int amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, _maxHealth);
        Debug.Log($"Healed on {amount}");
    }
        
    public void IncreaseDamage(int amount)
    {
        Damage += amount;
        Debug.Log($"Damage increased {amount}");
    }

    public void TeleportHome()
    {
        Debug.Log("Teleporting home");
    }
}