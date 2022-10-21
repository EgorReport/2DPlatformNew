using System;
using UnityEngine;

public class Bank
{
    public event Action<object, int, int >OnCoinsValueChangeEvent;

    private const string KEY="BANK_KEY";

    public static Bank instance
    {
        get
        {
            if (_instance == null)
                _instance = new Bank();
            return _instance;
        }
    }

    private static Bank _instance;

    public  int coins{get;private set;}

    public void AddCoins(object sender, int amount)
    {
        var oldCoinsValue = coins;
        coins += amount;

        Save();

        OnCoinsValueChangeEvent?.Invoke(sender, oldCoinsValue, coins);
    }

    public void SenderCoins(object sender, int amount)
    {
        var oldCoinsValue = coins;
        coins -= amount;

         Save();

        OnCoinsValueChangeEvent?.Invoke(sender, oldCoinsValue, coins);
    }

public void Initialize() 
{
    coins =PlayerPrefs.GetInt(KEY);
}
    public  void Save() 
    {
       PlayerPrefs.SetInt(KEY,coins);
    }

    public bool IsEnoughtCoins(int amount)
    {
        return amount<=coins;
    }
}
