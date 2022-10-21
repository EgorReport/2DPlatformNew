using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelPased : MonoBehaviour
{
   [SerializeField]private int _nextLevel;

    private static LevelPased _instance;

    private int levelReched;

  void Start()
  {
    levelReched=PlayerPrefs.GetInt("levelReached");
  }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInput>().isActiveAndEnabled)
        {
           SceneManager.LoadScene(levelReched);
           PlayerPrefs.SetInt("levelReached",_nextLevel);
        }
    }
}
