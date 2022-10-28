using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaQualidade : MonoBehaviour
{
    public TMP_Dropdown  dropdown;
    public int qualidade;

    // Start is called before the first frame update
    void Start()
    {
        qualidade = PlayerPrefs.GetInt("numeroDaQualidade", 3);
        dropdown.value = qualidade;
        AjustarQualidade();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AjustarQualidade()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDaQualidade", dropdown.value);
        qualidade = dropdown.value;

    }
}
