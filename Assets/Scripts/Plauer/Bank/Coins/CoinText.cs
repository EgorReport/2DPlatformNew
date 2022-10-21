using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    [SerializeField]private Text _coinText;
    public void Start()
    {
        Bank.instance.Initialize();
        _coinText.text = Bank.instance.coins.ToString();
        Bank.instance.OnCoinsValueChangeEvent += CoinsToText;
    }

    private void CoinsToText(object sender, int oldCoinsValue, int newCoinsValue)
    {
        _coinText.text = newCoinsValue.ToString();
    } 
}
