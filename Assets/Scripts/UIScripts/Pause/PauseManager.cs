using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMeny;

    private void Start()
    {
        _pauseMeny.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale=0;
        _pauseMeny.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        _pauseMeny.SetActive(false);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
}
