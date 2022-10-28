using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    [SerializeField]
    //private float speed = 2f;

    
    public float vidaBoss2 = 600;
    public static float vidaDoBoss2UI;
    public float danoBoss2 = 3.0f;
    

    //private float timer;
    public float speed = 10.0f;
    public float eixoX;

    public GameObject boss2;

    public Rigidbody rbBoss2;

    public float rotationY = 250;

    public float rotationX;

    private Transform player;

    public Transform posicaoDoBoss2;

    public Material[] materialBoss;

    public Color danoCor;

    public float timeCorDano = 0.01f;

    public GameObject powerUpDropavelPrefab;

    public Transform pontosdeSpawnPWBoss;

    public ParticleSystem particulaExplosaoPrefab;

    public Transform[] pontosDeExplosao;


    void Start()
    {
        rbBoss2 = this.GetComponent<Rigidbody>();
        posicaoDoBoss2 = GameObject.FindGameObjectWithTag("PontoDoBoss2").transform;
        pontosdeSpawnPWBoss = GameObject.Find("PontoDeSpawnPW2").transform;
        SpawnEnemy.instancia.ShowLifeBoss2();
    }

    // Update is called once per frame
    void Update()
    {
        if (posicaoDoBoss2.gameObject != null)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoBoss2.position, speed * Time.deltaTime);
        }

        if(vidaBoss2 <= 0)
        {
            GameController.instance.SetScore(100);
            GameController.instance.ShowWinTela();
            SpawnEnemy.instancia.QuitLifeBoss2();
            SpawnEnemy.boss2NaCena = false;
            SpawnEnemy.boss2JaMorreu = true;
            ParticleSystem particulaExplosao1 = Instantiate(this.particulaExplosaoPrefab, pontosDeExplosao[0].position, Quaternion.identity);
            ParticleSystem particulaExplosao2 = Instantiate(this.particulaExplosaoPrefab, pontosDeExplosao[1].position, Quaternion.identity);
            ParticleSystem particulaExplosao3 = Instantiate(this.particulaExplosaoPrefab, pontosDeExplosao[2].position, Quaternion.identity);
            ParticleSystem particulaExplosao4 = Instantiate(this.particulaExplosaoPrefab, pontosDeExplosao[3].position, Quaternion.identity);
            ParticleSystem particulaExplosao5 = Instantiate(this.particulaExplosaoPrefab, pontosDeExplosao[4].position, Quaternion.identity);
            ParticleSystem particulaExplosao6 = Instantiate(this.particulaExplosaoPrefab, pontosDeExplosao[5].position, Quaternion.identity);
            ParticleSystem particulaExplosao7 = Instantiate(this.particulaExplosaoPrefab, pontosDeExplosao[6].position, Quaternion.identity);
            ParticleSystem particulaExplosao8 = Instantiate(this.particulaExplosaoPrefab, pontosDeExplosao[7].position, Quaternion.identity);
            Destroy(gameObject);
        }

        vidaDoBoss2UI = vidaBoss2;
    }

    IEnumerator DanoCor()
    {
        GetComponent<Renderer>().materials[0].color = danoCor;

        yield return new WaitForSeconds(timeCorDano);

        GetComponent<Renderer>().materials[0].color = materialBoss[0].color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            StartCoroutine(DanoCor());
            
            vidaBoss2 = vidaBoss2 - 3;
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            StartCoroutine(DanoCor());
           
            vidaBoss2 = vidaBoss2 - 4;
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            StartCoroutine(DanoCor());
            
            vidaBoss2 = vidaBoss2 - 3;
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            StartCoroutine(DanoCor());
            
            vidaBoss2 = vidaBoss2 - 6;
            
        }

        if (other.gameObject.tag == "5Tiros")
        {
            StartCoroutine(DanoCor());
           
            vidaBoss2 = vidaBoss2 - 1f;
            
        }

    }
}
