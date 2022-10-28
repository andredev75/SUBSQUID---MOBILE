using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroZigZag : MonoBehaviour
{
    public float speedTiro = 30f;

     public float tempoMinimo = 3f;
    public float tempoMaximo;
    private float tempo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speedTiro * Time.deltaTime;

        tempo += Time.deltaTime;

        if (tempo< tempoMinimo)
        {
            transform.position += Vector3.down * speedTiro * Time.deltaTime;
        }

        if(tempo> tempoMinimo)
        {
        transform.position += Vector3.up * speedTiro * Time.deltaTime;
        }

        if(tempo > tempoMaximo)
        {
            tempo = 0;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 0.1f);
        }

    }
}
