using UnityEngine;

public class CamerMove : MonoBehaviour
{

    [SerializeField]private SelectCharacter _selectCharacter;
    [SerializeField] private Transform[] _plauerTransform;

    private int number;

    [SerializeField] private float _camerSpeed;

private void Start() 
{
    _selectCharacter.OnCharactersSelectEvent+=SelectCharacter;    
}

    private void FixedUpdate()
    {
            Vector3 target = new Vector3 { x = _plauerTransform[number].position.x, y = _plauerTransform[number].position.y, z = _plauerTransform[number].position.z - 10 };

            Vector3 pos = Vector3.Lerp( transform.position ,target,_camerSpeed* Time.deltaTime );

            transform.position=pos;

    }
    private void SelectCharacter(int Number,int oldNumber)
    {
      number=Number;
    }
   
}
