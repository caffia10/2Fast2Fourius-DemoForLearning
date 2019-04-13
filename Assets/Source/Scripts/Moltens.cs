using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Moltens : MonoBehaviour
{
    public Image molten;
    public string[] Scenes;

    void Start()
    {
        molten.CrossFadeAlpha(0, 0.5f, false);
    }

    public void FadeOut(int s)
    {
        molten.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(ChangeScene(Scenes[s]));
    }

    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
