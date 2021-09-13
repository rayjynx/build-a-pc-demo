using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneController : MonoBehaviour
{
    public string nextScene = "MainScene";
    IEnumerator Start()
    {
        while (!GameSettings.Instance.IsReady)
        {
            yield return null;
        }
        SceneManager.LoadScene(nextScene);
    }

}
