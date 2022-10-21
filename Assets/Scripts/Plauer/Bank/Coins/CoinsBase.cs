using UnityEngine;

public class CoinsBase : MonoBehaviour
{
    private const int _amount=1;

    public void AddCoinsToBank()
    {
        Bank.instance.AddCoins(this, _amount);
    }
}
