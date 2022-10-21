using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{  
[SerializeField]private int number;
 private Coins _coins;
    private void Start()
    {
        if(PlayerPrefs.GetString(number.ToString())=="false")
        {
           gameObject.SetActive(false);
        }
        _coins = new Coins();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInput>().isActiveAndEnabled)
        {
            PlayerPrefs.SetString(number.ToString(),"false");
           _coins.AddCoinsToBank();
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
