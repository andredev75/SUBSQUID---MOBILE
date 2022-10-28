using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoBoss : MonoBehaviour
{
    public float moveSpeed = 5;

    public float vidaEscudo;

    public ParticleSystem particulaExplosaoPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.y -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;

        if(pos.y >= 2.5f)
        {
            Debug.Log("Cumpriu");
            moveSpeed = -moveSpeed;
        }

        if(pos.y <= -2.5f)
        {
            Debug.Log("Cumpriu");
            moveSpeed = -moveSpeed;
        }

        if (vidaEscudo <= 0)
        {
            GameController.instance.SetScore(5);
            GameController.instance.ContadorDeinimigos();
            GameController.instance.ContadorDeinimigosPW();
            Destroy(gameObject);
            ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaExplosao.gameObject, 1f); // Destr�i a part�cula ap�s 1 segundo
            //FindObjectOfType<Audio_menager>().Play("explosion");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            Debug.Log("levou um tiro do player");
            vidaEscudo = vidaEscudo - 3;
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            Debug.Log("levou um tiro do player");
            vidaEscudo = vidaEscudo - 4;
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            Debug.Log("levou um tiro do player");
            vidaEscudo = vidaEscudo - 3;
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            Debug.Log("levou um tiro do Inimigo");
            vidaEscudo = vidaEscudo - 6;
            
        }

        if (other.gameObject.tag == "5Tiros")
        {
            Debug.Log("levou um tiro do Inimigo");
            vidaEscudo = vidaEscudo - 1f;
            
        }

    }
}
