using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVida : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;

    public GameObject pW;
    public float speed = 5;

    public float rotationX;

    public float rotationY;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        pW.transform.Rotate(rotationX, rotationY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(-speed, 0, 0);
        Destroy(this.gameObject, 30.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            FindObjectOfType<UIManager>().SetMessagePW("PowerUp Actived");
        }

    }
}
