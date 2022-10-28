using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_ASSETS : MonoBehaviour
{
   
    private float b;

    [SerializeField]
    private float rotacao;
    // Update is called once per frame
    void Update()
    {
        RODAR();
    }

    void RODAR ()
    {
        b = b + Time.deltaTime * rotacao;
        transform.rotation = Quaternion.Euler(0,0,b);
    }
}
