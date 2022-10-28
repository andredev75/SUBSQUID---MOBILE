using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneSwitchScript : MonoBehaviour
{

    public Button [] botões; 
    private void Update()
    {
        for(int i = 0; i<botões.Length; i++)
        {
            if(i + 2 > PlayerPrefs.GetInt("faseCompletada"))
            {
            botões[i].interactable = false;

            }
        }
    }

    public void EscolherFase1()
    {
        SceneManager.LoadScene("Fase1");
        Time.timeScale = 1;
    }

    public void EscolherFase2()
    {
        SceneManager.LoadScene("Fase2");
        Time.timeScale = 1;
    }

    public void EscolherFase3()
    {
        SceneManager.LoadScene("Fase3");
        Time.timeScale = 1;
    }
public void SelectFase()
    {
        SceneManager.LoadScene("_SelectFase");
    }
    public void MenuInicial()
    {
        SceneManager.LoadScene("_MenuInicial");
    }


    public void Sair()
    {
        Application.Quit();
    }

    /*public void callLevels()
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("faseAtual") + 1);
        }
    */
}
