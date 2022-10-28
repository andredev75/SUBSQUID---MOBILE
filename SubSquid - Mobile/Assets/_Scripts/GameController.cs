using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class GameController : MonoBehaviour
{

    //public UnityEvent chamarBoss1;
    public GameObject gameOver;
    public GameObject winTela;
    public GameObject pauseTela;
    public GameObject volumeSlider;

    public GameObject boss1Baleia;

    public Text scoreText1;

    public TextMeshProUGUI scoreText;
    private int score;

    // chamar boss

    public static int contadorEnemy;
    public static int contadorEnemyPW;

    public GameObject pontosText;
    public GameObject tirosText;

    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        FindObjectOfType<Audio_menager>().Play("faseambientacao");
        FindObjectOfType<Audio_menager>().Play("musicafase");
        contadorEnemy = 0;
        contadorEnemyPW = 0;

        pontosText.SetActive(true);
        tirosText.SetActive(true);
    }

    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                //pauseTela.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                //pauseTela.SetActive(true);
                Time.timeScale = 1;
            }

        }
        */

        

        if(contadorEnemy == 20)
        {
            //chamarBoss1.Invoke();
            //boss1Baleia.SetActive(true);

        }

    }

    public void ShowGameOver()
    {
        StartCoroutine(GameOverCR());

    }

    IEnumerator GameOverCR()
    {

        yield return new WaitForSeconds(1.5f);
        gameOver.SetActive(true);
        Time.timeScale = 0;
        pontosText.SetActive(false);
        tirosText.SetActive(false);

        FindObjectOfType<Audio_menager>().Play("GameOver");
        FindObjectOfType<Audio_menager>().StopPlaying("musicafase");


    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
        Time.timeScale = 1;
        contadorEnemy = 0;

        pontosText.SetActive(true);
        tirosText.SetActive(true);
    }

    public void ShowWinTela()
    {
        StartCoroutine(WinGameCR());
    }

    IEnumerator WinGameCR()
    {
        yield return new WaitForSeconds(2.0f);
        winTela.SetActive(true);

        pontosText.SetActive(false);
        tirosText.SetActive(false);

    }

    public void ShowPauseTela()
    {
        
        pauseTela.SetActive(true);
        //volumeSlider.SetActive(true);
        Time.timeScale = 0;
        SpawnEnemy.timeRun = false;
        FindObjectOfType<Audio_menager>().StopPlaying("musicafase");
        FindObjectOfType<Audio_menager>().Play("Pause");

        
    }

    public void Resume()
    {
        pauseTela.SetActive(false);
        //volumeSlider.SetActive(false);
        Time.timeScale = 1;
        SpawnEnemy.timeRun = true;
        FindObjectOfType<Audio_menager>().Play("musicafase");
        FindObjectOfType<Audio_menager>().StopPlaying("Pause");

        pontosText.SetActive(true);
        tirosText.SetActive(true);
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("_MenuInicial");
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void SetScore(int scorePoints)
    {
        score += scorePoints;
        scoreText1.text = score.ToString();
        scoreText.text = score.ToString();
        
    }

    public void ContadorDeinimigos()
    {
        contadorEnemy += 1;
    }

    public void ContadorDeinimigosPW()
    {
        contadorEnemyPW += 1;
    }

}
