using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField]
    //private float speed = 2f;

    
    public float vidaBoss1 = 10.0f;
    public float danoBoss1 = 3.0f;
    

    //private float timer;
    public float velocity = 10.0f;
    public float eixoX;

    public GameObject boss1;

    public Rigidbody rbBoss1;

    public float rotationY = 250;

    public float rotationX;

    public float fireRate;
	private float nextFire;

    // tiro que segue
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    private Transform player;


    //

    void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss1.transform.Rotate(rotationX, rotationY, 0);
        rbBoss1 = this.GetComponent<Rigidbody>();
        timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {
        //rbBoss1.velocity = new Vector3(-speed, 0, 0);
        
        

        if(vidaBoss1 <= 0)
        {
            GameController.instance.SetScore(100);
            SpawnEnemy.boss1NaCena = false;
            //Destroy(gameObject);
        }

        if(timeBtwShots <=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            
            vidaBoss1 = vidaBoss1 - danoBoss1;
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
           
            vidaBoss1 = vidaBoss1 - 2;
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            
            vidaBoss1 = vidaBoss1 - 1;
        }

        if (other.gameObject.tag == "TiroPesado")
        {
           
            vidaBoss1 = vidaBoss1 - 4;
            
        }

        if (other.gameObject.tag == "5Tiros")
        {
            
            vidaBoss1 = vidaBoss1 - 0.5f;
            
        }

       

    }
}