using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroBoss1 : MonoBehaviour
{

    public float speed;

    private Transform  player;
    private Vector2 target;

    public ParticleSystem particulaExplosaoTiroBossPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player. position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

        Destroy(gameObject, 15.0f);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
        ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoTiroBossPrefab, this.transform.position, Quaternion.identity);
        Destroy(particulaExplosao.gameObject, 1f); // Destr�i a part�cula ap�s 1 segundo
    }
}
