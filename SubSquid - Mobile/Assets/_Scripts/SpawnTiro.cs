using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiro : MonoBehaviour
{

    public Transform bullet;
    public Transform bullet2;

    public Transform bullet3;

    public Transform bulletPesado;

    public Transform bulletZigZag;

    public Transform bulletLaser;
        

    //public GameObject shot;
    public Transform shotSpawn;
    
    public float fireRate;
	private float nextFire;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.J) && Time.time > nextFire && Nave.isDash == false)
        {
            Tiro1();
            //FindObjectOfType<Audio_menager>().Play("tiro");
        }

        if(Input.GetKey(KeyCode.K) && Time.time > nextFire && Nave.isDash == false)
        {
            Tiro2();
        }

        if(Input.GetKey(KeyCode.L) && Time.time > nextFire && Nave.isDash == false)
        {
            Tiro3();
        }

        if(Input.GetKey(KeyCode.I) && Time.time > nextFire && Nave.isDash == false)
        {
            TiroPesado();
        }

        if(Input.GetKey(KeyCode.O) && Time.time > nextFire && Nave.isDash == false)
        {
            TiroZigZag();
        }

        if (Input.GetKey(KeyCode.U) && Time.time > nextFire && Nave.isDash == false)
        {
            TiroLaser(); 
        }




    }

    void Tiro1()
    {
        FindObjectOfType<Audio_menager>().Play("tiro");
        nextFire = Time.time + fireRate;
        Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

    }

    void Tiro2()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bullet2, shotSpawn.position, shotSpawn.rotation);
    }

    void Tiro3()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bullet3, shotSpawn.position, shotSpawn.rotation);
    }

    void TiroPesado()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bulletPesado, shotSpawn.position, shotSpawn.rotation);
    }

    void TiroZigZag()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bulletZigZag, shotSpawn.position, shotSpawn.rotation);
    }
    void TiroLaser()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bulletLaser, shotSpawn.position, shotSpawn.rotation);
    }


}
