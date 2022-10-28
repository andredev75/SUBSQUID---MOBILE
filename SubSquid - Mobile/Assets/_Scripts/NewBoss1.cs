using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBoss1 : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float speed = 8f;
    [SerializeField] float speedAttack = 16f;
    [SerializeField] float attack1Duration = 1.0f;
    [SerializeField] float stateNormalDuration = 8f;
    [SerializeField] float vidaBoss1 = 100f;

    public static float vidaBoss1UI;

    public GameObject boss1;
    private Transform posicaoDoJogador;

    public Transform posicaoDoBoss1;

    private Vector2 target;

    public ParticleSystem particulaExplosaoPrefab;

    public GameObject vidaDropavelPrefab;

    public Material[] materialBoss;

    public Color danoCor;

    public float timeCorDano = 0.01f;

    public Transform HealthBar;
    public GameObject HealthBarObject;

    private Vector3 healthBarScale;
    private float healthPercent;


    
    


    Animator animator;
    Rigidbody2D physics;
    SpriteRenderer sprite;

    enum State { Normal, Attack1, Attack2, Attack3}

    State state = State.Normal;
    




    void Start()
    {
        //rbEnemy = this.GetComponent<Rigidbody>();
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform;
        posicaoDoBoss1 = GameObject.FindGameObjectWithTag("PontoDoBoss1").transform;
        target = new Vector2(posicaoDoBoss1.position.x, posicaoDoBoss1. position.y);
        
        boss1.transform.Rotate(0, 90, 0);

        healthBarScale = HealthBar.localScale;
        healthPercent = healthBarScale.x / vidaBoss1;
        
    }

    void UpdateHealthBar()
    {
        healthBarScale.x = healthPercent * vidaBoss1;
        HealthBar.localScale = healthBarScale; 

    }

    void Update()
    {
         if(vidaBoss1 <= 0)
        {
            GameController.instance.SetScore(100);
            SpawnEnemy.boss1NaCena = false;
            SpawnEnemy.boss1JaMorreu = true;
            //GameController.instance.ShowWinTela();
            Destroy(gameObject);
            FindObjectOfType<Audio_menager>().Play("ExplosionBaleia");
            ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaExplosao.gameObject, 1f); // Destr�i a part�cula ap�s 1 segundo
            GameObject vidaDropavel = Instantiate(this.vidaDropavelPrefab, this.transform.position, Quaternion.identity);
        }

        vidaBoss1UI = vidaBoss1;
    }


    void FixedUpdate()
    {
        
        switch (state)
        {
            case State.Normal: NormalState(); break;
            case State.Attack1: Attack1State(); break;
            case State.Attack2: Attack2State(); break;
            case State.Attack3: Attack3State(); break;
        }

    }

     IEnumerator DanoCor()
    {
        //GetComponent<Renderer>().materials[0].color = danoCor;

        yield return new WaitForSeconds(timeCorDano);

        //GetComponent<Renderer>().materials[0].color = materialBoss[0].color;
    }

    void NormalState()
    {
        

        currentAttack += Time.fixedDeltaTime;

        if (posicaoDoBoss1.gameObject != null)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoBoss1.position, speed * Time.deltaTime);
        }

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            state = State.Attack1;
        }


        /*
        if (currentAttack > stateNormalDuration)
        {
            state = State.Attack1;
            currentAttack = 0f;
        }
        */
    }

    

    void Attack1State()
    {
        

        currentAttack += Time.fixedDeltaTime;

        if (posicaoDoJogador.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, speedAttack * Time.deltaTime);
        }

        if (currentAttack > attack1Duration)
        {
            state = State.Normal;
            currentAttack = 0f;
        }

        //StartCoroutine("VoltarNormalState");

    }
     

    void Awake()
    {
        animator = GetComponent<Animator>();
        physics = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    float currentAttack;
    void Attack2State()
    {
    
    
    }

    void Attack3State()
    {
    
    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            StartCoroutine(DanoCor());
            
            vidaBoss1 = vidaBoss1 - 3;
            UpdateHealthBar();
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            StartCoroutine(DanoCor());
            
            vidaBoss1 = vidaBoss1 - 4;
            UpdateHealthBar();
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            StartCoroutine(DanoCor());
            
            vidaBoss1 = vidaBoss1 - 3;
            UpdateHealthBar();
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            StartCoroutine(DanoCor());
           
            vidaBoss1 = vidaBoss1 - 6;
            UpdateHealthBar();
            
        }

        if (other.gameObject.tag == "5Tiros")
        {
            StartCoroutine(DanoCor());
          
            vidaBoss1 = vidaBoss1 - 1f;
            UpdateHealthBar();
            
        }

        if (other.gameObject.tag == "TiroZigZag")
        {
            UpdateHealthBar();
            StartCoroutine(DanoCor());
            vidaBoss1 = vidaBoss1 - 6;
            
        }

    }
}
