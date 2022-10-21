using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class UIShopS : MonoBehaviour
{
    [SerializeField]private SelectCharacter _selectCharacter;
    private const string ACTIVE_CHARACTER = "isActive";
    private const string SELECT_CHARACTER = "select";

    private int _number;
    private string _statuseCheck;
    private int _check;

    [SerializeField] private GameObject _shop;

    [SerializeField] private GameObject _buttonLeft;
    [SerializeField] private GameObject _buttonRight;

    [SerializeField] private GameObject _buttonBuy;
    [SerializeField] private GameObject _selectButton;
    public Text SelectText;

    [SerializeField] private GameObject[] _characters;
    public GameObject[] Characters=>_characters;
    public int Number=>_number;
    public GameObject ButtonBuy=>_buttonBuy;
    public GameObject SelectButton=>_selectButton;

    private void Start()
    {
        CloseShop();

        if (_selectCharacter.Data.CurentCharacter == _characters[_number].name)
        {
            SelectText.text = ACTIVE_CHARACTER;
            _selectButton.SetActive(true);
            _buttonBuy.SetActive(false);
        }
        else if (_selectCharacter.Data.CurentCharacter != _characters[_number].name)
            StartCoroutine(CheckHaveCharacter());

        if (_number > 0)
            _buttonLeft.SetActive(true);

        if (_number == _characters.Length)
            _buttonRight.SetActive(false);
    }

    public IEnumerator CheckHaveCharacter()
    {
        while (_statuseCheck != "Check")
        {
            if (_selectCharacter.Data.HaveCharacters.Count != _check)
            {
                if (_characters[_number].name != _selectCharacter.Data.HaveCharacters[_check])
                    _check++;
                else if (_characters[_number].name == _selectCharacter.Data.HaveCharacters[_check])
                {
                    _buttonBuy.SetActive(false);
                    _selectButton.SetActive(true);
                    SelectText.text = SELECT_CHARACTER;
                    _check = 0;
                    _statuseCheck = "Check";
                }
            }
            else if (_selectCharacter.Data.HaveCharacters.Count == _check)
            {
                _buttonBuy.SetActive(true);
                _selectButton.SetActive(false);
                SelectText.text = _characters[_number].GetComponent<Items>().PriseCharacter.ToString();
                _check = 0;
                _statuseCheck = "Check";
            }
        }
        _statuseCheck ="";

        yield return null;
    }

    public void ButtonRight()
    {
        if (_number == 0)
            _buttonLeft.SetActive(true);

        _characters[_number].SetActive(false);
        _number++;
        _characters[_number].SetActive(true);

        if (_selectCharacter.Data.CurentCharacter == _characters[_number].name)
        {
            SelectText.text = ACTIVE_CHARACTER;
            _buttonBuy.SetActive(false);
            _selectButton.SetActive(true);
        }
        else if (_selectCharacter.Data.CurentCharacter != _characters[_number].name)
            StartCoroutine(CheckHaveCharacter());

        if (_number + 1 == _characters.Length)
            _buttonRight.SetActive(false);
    }

    public void ButtonLeft()
    {
        _characters[_number].SetActive(false);
        _number--;
        _characters[_number].SetActive(true);
        _buttonRight.SetActive(true);

        if (_selectCharacter.Data.CurentCharacter == _characters[_number].name)
        {
            SelectText.text = ACTIVE_CHARACTER;
            _buttonBuy.SetActive(false);
            _selectButton.SetActive(true);

        }
        else if (_selectCharacter.Data.CurentCharacter != _characters[_number].name)
            StartCoroutine(CheckHaveCharacter());

        if (_number == 0)
            _buttonLeft.SetActive(false);
    }
    public void OpenShop()
    {
        _shop.SetActive(true);
    }
    public void CloseShop()
    {
        _shop.SetActive(false);
    }
}
