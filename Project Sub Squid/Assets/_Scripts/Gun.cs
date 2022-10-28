using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public TiroNew bullet;
    Vector2 direction;
    public static bool tiroExtra;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        TiroNew goBullet = go.GetComponent<TiroNew>();
        goBullet.direction = direction;
        StartCoroutine ("NoTiroExtra");
    }

    IEnumerator NoTiroExtra()
    {
        yield return new WaitForSeconds (0.5f);
        tiroExtra = false;
        
    }
}
