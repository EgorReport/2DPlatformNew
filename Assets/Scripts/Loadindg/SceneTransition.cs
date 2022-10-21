using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]private Text _loadingText;
    [SerializeField]private Image _loadingImage;

    private static SceneTransition instans;
    private static bool ShouldPlayOpeningAnimtion;

    private Animator animator;
    private AsyncOperation loadingScene;
    public static void SwitchToScene(int numberScene)
    {
       instans.animator.SetTrigger("EndTriger");

       instans.loadingScene=SceneManager.LoadSceneAsync(numberScene);
       instans.loadingScene.allowSceneActivation=false;
    }
    private void Start() 
    {
        instans=this;

        animator=GetComponent<Animator>();

        if(ShouldPlayOpeningAnimtion)
        animator.SetTrigger("StartTriger");
    }

    private void Update() 
    {
    _loadingText.text=Mathf.RoundToInt(loadingScene.progress*100)+"%";
    _loadingImage.fillAmount=loadingScene.progress; 
    }

    public void OnAnimationOver()
    {
       ShouldPlayOpeningAnimtion=true;
       loadingScene.allowSceneActivation = true;
    }
}
