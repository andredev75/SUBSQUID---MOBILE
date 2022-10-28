using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZag : MonoBehaviour
{

    public float moveSpeed = 5;

    public float vidaEnemyGroup = 5;
    public float danoEnemyGroup = 2;

    public ParticleSystem particulaExplosaoPrefab;
    public ParticleSystem particulaSanguePrefab;

    public GameObject[] powerUpDropavelPrefab;

    public int randomPW;

    //public Rigidbody enemyG;

    // Start is called before the first frame update
    void Start()
    {
        //enemyG = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        


        if(vidaEnemyGroup <= 0)
        {
             if (GameController.contadorEnemyPW >= 5)
            {
                GameController.contadorEnemyPW = 0;
                randomPW = Random.Range(0 ,powerUpDropavelPrefab.Length);
                GameObject powerUpDropavel = Instantiate(this.powerUpDropavelPrefab[randomPW], this.transform.position, Quaternion.identity);

            }
            GameController.instance.SetScore(10);
            GameController.instance.ContadorDeinimigos();
            GameController.instance.ContadorDeinimigosPW();
            Destroy(gameObject);
            ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaExplosao.gameObject, 1f); // Destr�i a part�cula ap�s 1 segundo
            FindObjectOfType<Audio_menager>().Play("explosion");
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;

        if(pos.x < -50)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            
            vidaEnemyGroup = vidaEnemyGroup - 3;
            ParticleSystem particulaSangue = Instantiate(this.particulaSanguePrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaSangue.gameObject, 0.2f); // Destr�i a part�cula ap�s 1 segundo
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            
            vidaEnemyGroup = vidaEnemyGroup - 4;
            ParticleSystem particulaSangue = Instantiate(this.particulaSanguePrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaSangue.gameObject, 0.2f); // Destr�i a part�cula ap�s 1 segundo
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            
            vidaEnemyGroup = vidaEnemyGroup - 3;
            ParticleSystem particulaSangue = Instantiate(this.particulaSanguePrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaSangue.gameObject, 0.2f); // Destr�i a part�cula ap�s 1 segundo
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            
            vidaEnemyGroup = vidaEnemyGroup - 6;
            ParticleSystem particulaSangue = Instantiate(this.particulaSanguePrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaSangue.gameObject, 0.2f); // Destr�i a part�cula ap�s 1 segundo
        }

        if (other.gameObject.tag == "5Tiros")
        {
            
            vidaEnemyGroup = vidaEnemyGroup - 1f;
            ParticleSystem particulaSangue = Instantiate(this.particulaSanguePrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaSangue.gameObject, 0.2f); // Destr�i a part�cula ap�s 1 segundo
        }

        if (other.gameObject.tag == "TiroZigZag")
        {
            vidaEnemyGroup = vidaEnemyGroup - 6;
            ParticleSystem particulaSangue = Instantiate(this.particulaSanguePrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaSangue.gameObject, 0.2f); // Destr�i a part�cula ap�s 1 segundo
            
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
