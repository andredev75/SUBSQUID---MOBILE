using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraLifeBoss1 : MonoBehaviour
{
    private Image HealthBar1;
    public float CurrentHealth;
    private float MaxHealth = 150f;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar1 = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = NewBoss1.vidaBoss1UI;
        HealthBar1.fillAmount = NewBoss1.vidaBoss1UI / MaxHealth;

    }
}
