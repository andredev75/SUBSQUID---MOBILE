using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    Animator anim; 
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void CameraTremer()
    {
        anim.Play("CameraTreme");
    }
}
