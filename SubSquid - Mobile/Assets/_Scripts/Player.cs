using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 10.0f;
    public float rotation = 90.0f;

    public float dashSpeed;


    
    

    void Start () 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(-x, y , 0) * velocity;

        transform.Translate(dir * Time.deltaTime);

        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(dir * Time.deltaTime * dashSpeed);
        }
    }
}