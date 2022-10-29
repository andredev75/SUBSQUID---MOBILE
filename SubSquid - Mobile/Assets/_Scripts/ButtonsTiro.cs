using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsTiro : MonoBehaviour
{
    bool podeAtirarNormal;
    bool pareDeAtirar;
    public float fireRateButton;
    public float fireRate;
	private float nextFire;


    bool podeAtirarNormalEsp;
    bool pareDeAtirarEsp;
    public float fireRateButtonEsp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(podeAtirarNormal)
        {  
                AtirarPeloBotao();
        }

        if(podeAtirarNormalEsp)
        {
            AtirarPeloBotaoEsp();
        }

    }

    public void PointerDownTiro()
    {
        pareDeAtirar = false;
        Invoke("MakeFireVariableTrue", fireRateButton);
    }

    public void PointerUpTiro()
    {
        podeAtirarNormal = false;
        pareDeAtirar = true;
    }

    void MakeFireVariableTrue()
    {
        podeAtirarNormal = true;
    }

    void MakeFireVariableFalse()
    {
        podeAtirarNormal = false;
        if(pareDeAtirar == false)
        {
            Invoke("MakeFireVariableTrue", fireRateButton);
        }
    }

    void AtirarPeloBotao()
    {
            MakeFireVariableFalse();
            Debug.Log("está sendo chamado");
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                SpawnTiroNew.instance.Tiro();

            }
        
    }


    // tiro especial

    public void PointerDownTiroEsp()
    {
        pareDeAtirarEsp = false;
        Invoke("MakeFireVariableTrueEsp", fireRateButtonEsp);
    }

    public void PointerUpTiroEsp()
    {
        podeAtirarNormalEsp = false;
        pareDeAtirarEsp = true;
    }

    void MakeFireVariableTrueEsp()
    {
        podeAtirarNormalEsp = true;
    }

    void MakeFireVariableFalseEsp()
    {
        podeAtirarNormalEsp = false;
        if(pareDeAtirarEsp == false)
        {
            Invoke("MakeFireVariableTrueEsp", fireRateButtonEsp);
        }
    }

    void AtirarPeloBotaoEsp()
    {
            MakeFireVariableFalseEsp();
            Debug.Log("está sendo chamado tiro especial");
            Nave.instance.TiroEspecialButton();
    }
}
