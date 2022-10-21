using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacterOnScene : MonoBehaviour
{
    DataSelectCharacter data=new DataSelectCharacter();
    [SerializeField]private SelectCharacter _selectCharacter;
    [SerializeField]private GameObject[] _characters;

public void Start()
{
Bank.instance.Initialize();

_selectCharacter.OnCharactersSelectEvent+=LoadCharacter;
}

private void LoadCharacter(int number,int oldNumber)
{
_characters[oldNumber].SetActive(false);

_characters[number].SetActive(true);
}
}

