using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeguir : MonoBehaviour
{

    //public Rigidbody rbEnemy;
    public float velocidadeInimigo;

    public GameObject enemySeguir;


    public float vidaInimigoSeguir = 2f;
    public float danoSofridoSeguir = 3f;


    public Transform posicaoDoJogador;

    public ParticleSystem particulaExplosaoPrefab;

    public GameObject[] powerUpDropavelPrefab;

    public int randomPW;

    // Start is called before the first frame update
    void Start()
    {
        //rbEnemy = this.GetComponent<Rigidbody>();
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform;
        enemySeguir.transform.Rotate(0, 260, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (posicaoDoJogador.gameObject != null)
        {
            if (enemySeguir.transform.position.x - posicaoDoJogador.transform.position.x > posicaoDoJogador.transform.position.x)
            {
            
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeInimigo * Time.deltaTime);
            //enemySeguir.transform.Rotate(0, 260, 0);
            //Debug.Log("Ta indo para Esquerda");
            //VirarParaEsquerda();

                
            }

            if (enemySeguir.transform.position.x - posicaoDoJogador.transform.position.x < posicaoDoJogador.transform.position.x)
            {
            
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeInimigo * Time.deltaTime);
            //enemySeguir.transform.Rotate(0, 90, 0);
            //Debug.Log("Ta indo para Direita");
            //VirarParaDireita();
            }
            //rbEnemy.velocity = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeInimigo);
        }

        if(vidaInimigoSeguir <= 0)
        {
             if (GameController.contadorEnemyPW >= 5)
            {
                GameController.contadorEnemyPW = 0;
                randomPW = Random.Range(0 ,powerUpDropavelPrefab.Length);
                GameObject powerUpDropavel = Instantiate(this.powerUpDropavelPrefab[randomPW], this.transform.position, Quaternion.identity);

            }
            GameController.instance.SetScore(5);
            GameController.instance.ContadorDeinimigos();
            GameController.instance.ContadorDeinimigosPW();
            Destroy(gameObject);
            ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaExplosao.gameObject, 1f); // Destr�i a part�cula ap�s 1 segundo
            FindObjectOfType<Audio_menager>().Play("explosion");
        }
    }

    void VirarParaEsquerda()
    {
        enemySeguir.transform.Rotate(0, 260, 0);
    }

    void VirarParaDireita()
    {
        enemySeguir.transform.Rotate(0, 90, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            
            vidaInimigoSeguir = vidaInimigoSeguir - 3;
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            
            vidaInimigoSeguir = vidaInimigoSeguir - 4;
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            
            vidaInimigoSeguir = vidaInimigoSeguir - 3;
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            
            vidaInimigoSeguir = vidaInimigoSeguir - 6;
            
        }

        if (other.gameObject.tag == "5Tiros")
        {
            
            vidaInimigoSeguir = vidaInimigoSeguir - 1f;
            
        }

        if (other.gameObject.tag == "TiroZigZag")
        {
            vidaInimigoSeguir = vidaInimigoSeguir - 6;
            
        }
        

        if (other.gameObject.tag == "Player")
        {
            
            Destroy(this.gameObject, 0.1f);
            ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaExplosao.gameObject, 1f); // Destr�i a part�cula ap�s 1 segundo
            FindObjectOfType<Audio_menager>().Play("explosion");
        }

    }

}
