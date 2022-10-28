using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroNew : MonoBehaviour
{

    public Vector2 direction = new Vector2(1, 0);

    public float speed = 6;

    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
        Destroy(gameObject, 15f);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject, 0.1f);
        }

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
