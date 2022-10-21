using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
   [SerializeField] private GameObject _levelMenu;
   [SerializeField] private Button[] _levelButtons;

  private int levelReched;
  void Start()
  {
    levelReched=PlayerPrefs.GetInt("levelReached",1);

   for(int i=0;i<_levelButtons.Length;i++)
   {
      if(i+1>levelReched)
        _levelButtons[i].interactable=false;
   }
  }
   public void Close()
   {
      _levelMenu.SetActive(false);
   }
   public void SelectScene(int numberScene)
   {
       SceneManager.LoadScene(numberScene);
       Time.timeScale = 1;
   }
}
