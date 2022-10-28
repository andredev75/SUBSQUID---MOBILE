using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameLootLoading : MonoBehaviour
{
    //public Text porcetagem;
    public Image barrinhaImage;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        string sceneName = PlayerPrefs.GetString("SCENE_TO_LOAD", "_MenuInicial");
        PlayerPrefs.SetString("SCENE_TO_LOAD", "_MenuInicial");
        PlayerPrefs.Save();
        barrinhaImage.fillAmount = 0;
        //porcetagem.text = "0%";

        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public static void LoadScene(string sceneName)
    {
        PlayerPrefs.SetString("SCENE_TO_LOAD", sceneName);
        PlayerPrefs.Save();
        SceneManager.LoadScene("_Loading");

    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return new WaitForSeconds(1);
        System.GC.Collect();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        //asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            //porcetagem.text = (asyncLoad.progress * 100).ToString("N0") + "%";
            barrinhaImage.fillAmount = asyncLoad.progress;
            yield return new WaitForEndOfFrame();
        }


    }

}
