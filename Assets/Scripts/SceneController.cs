using System.Collections;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine Events;
using UnityEngine SceneManagement;
using System.Collentions;

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
        yield return WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
