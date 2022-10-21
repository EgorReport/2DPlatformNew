using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   [SerializeField] private GameObject _options;
   [SerializeField] private GameObject _levelMenu;
private void Start() 
{
   _levelMenu.SetActive(false);
   _options.SetActive(false);
}

   public void Play()
   {
      SceneManager.LoadScene(1);
      Time.timeScale = 1;
   }
   public void Quit()
   {
      Application.Quit();
   }
   public void OpenOptions()
   {
      _options.SetActive(true);
   }
   public void OpenLevelMenu()
   {
      _levelMenu.SetActive(true);
   }
}
