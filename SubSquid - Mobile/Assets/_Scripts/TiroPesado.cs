using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPesado : MonoBehaviour
{
    public float speedTiroPesado = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speedTiroPesado * Time.deltaTime;
        Destroy(this.gameObject, 5.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject, 0.1f);
        }

        if (other.gameObject.tag == "Boss1")
        {
            Destroy(this.gameObject, 0.1f);
        }

        if (other.gameObject.tag == "Boss2")
        {
            Destroy(this.gameObject, 0.1f);
        }

        if (other.gameObject.tag == "EscudoBoss")
        {
           
            Destroy(this.gameObject);
        }

    }
}
