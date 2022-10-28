using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    public MeshRenderer mr;
    public float speedmr;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(speedmr * Time.deltaTime, 0);

    }
}
