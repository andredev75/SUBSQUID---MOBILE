using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaFullScreen : MonoBehaviour
{
    public Toggle toggle;
    
    public TMP_Dropdown resolucionesDropDown;
    Resolution [] resoluciones;

    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
           toggle.isOn = false; 
        }

        RevisarResolucion();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarFullScreen(bool fullScreenCompleto)
    {
        Screen.fullScreen = fullScreenCompleto;

    }

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);
            
            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;

            }

        }

        resolucionesDropDown.AddOptions(opciones);
        resolucionesDropDown.value = resolucionActual;
        resolucionesDropDown.RefreshShownValue();

        resolucionesDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }

    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolucionesDropDown.value);

        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);

    }



}
