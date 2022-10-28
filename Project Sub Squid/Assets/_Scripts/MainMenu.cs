using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

public void PlayGame()
{
    SceneManager.LoadScene("Fase1");
    Time.timeScale = 1;
}

void Start()
{
    FindObjectOfType<Audio_menager>().Play("menuinicial");
}

public void DesativarParaVideo()
{
    StartCoroutine(DesativarVideo());
}

IEnumerator DesativarVideo()
{
    yield return new WaitForSeconds(1.5f);
    gameObject.SetActive(false);
}


public void Sair()
    {
        Application.Quit();
    }

    
}
