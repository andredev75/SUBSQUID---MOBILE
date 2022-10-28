using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiroEnemy : MonoBehaviour
{
    public Transform bulletEnemy;

    //public GameObject shot;
	public Transform shotSpawnEnemy;

    public float fireRate;
	private float nextFire;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletEnemy, shotSpawnEnemy.position, shotSpawnEnemy.rotation);
        }
    }
        
}