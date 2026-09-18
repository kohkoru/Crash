using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onSceneStarded;
    [SerializeField]
    private Animator fade;
    [SerializeField]
    private string fadeOutAnimationName = "FadeOut";
    private void Start()
    {
        onSceneStarded.Invoke();
    }
    public void GoToSceneWithFade(string sceneName)
    {
        StartCoroutine(LoadSceneWithFade(sceneName));
    }
    private IEnumerator LoadSceneWithFade(string sceneName)
    {
        fade.Play(fadeOutAnimationName, 0, 0f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
