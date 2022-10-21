using UnityEngine;
using System;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public event Action<int,int> OnCharactersSelectEvent;

    DataSelectCharacter data=new DataSelectCharacter();
    [SerializeField] private UIShopS _uiShop;

     private int oldNumber;

    public const string KEY="SaveShop";

    private const string ACTIVE_CHARACTER = "isActive";
    private const string SELECT_CHARACTER = "select";

    public DataSelectCharacter Data=>data;

    private void Start()
    {   
        OnCharactersSelectEvent?.Invoke(_uiShop.Number,oldNumber);
        
        if (PlayerPrefs.HasKey(KEY))
        {
            data = JsonUtility.FromJson<DataSelectCharacter>(PlayerPrefs.GetString(KEY));
        }
        else
        {
            PlayerPrefs.SetString(KEY, JsonUtility.ToJson(data));
        }
    }

    public void SelectCharacters()
    {
        OnCharactersSelectEvent?.Invoke(_uiShop.Number,oldNumber);

        oldNumber=_uiShop.Number;

        data = JsonUtility.FromJson<DataSelectCharacter>(PlayerPrefs.GetString(KEY));
        data.CurentCharacter =_uiShop.Characters[_uiShop.Number].name;
        PlayerPrefs.SetString(KEY, JsonUtility.ToJson(data));

       _uiShop.SelectText.text = ACTIVE_CHARACTER;
       _uiShop.ButtonBuy.SetActive(false);
       _uiShop.SelectButton.SetActive(true);

       
    }
    public void BuyCharacters()
    {
        if (Bank.instance.IsEnoughtCoins(_uiShop.Characters[_uiShop.Number].GetComponent<Items>().PriseCharacter))
        {
            data = JsonUtility.FromJson<DataSelectCharacter>(PlayerPrefs.GetString(KEY));

            Bank.instance.SenderCoins(this, _uiShop.Characters[_uiShop.Number].GetComponent<Items>().PriseCharacter);
            data.HaveCharacters.Add(_uiShop.Characters[_uiShop.Number].name);

            PlayerPrefs.SetString(KEY, JsonUtility.ToJson(data));

            _uiShop.SelectText.text = SELECT_CHARACTER;
            _uiShop.ButtonBuy.SetActive(false);
            _uiShop.SelectButton.SetActive(true);
        }
    }
}