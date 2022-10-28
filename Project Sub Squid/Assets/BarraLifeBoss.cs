using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraLifeBoss : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 800f;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Boss2.vidaDoBoss2UI;
        HealthBar.fillAmount = Boss2.vidaDoBoss2UI / MaxHealth;

    }
}
