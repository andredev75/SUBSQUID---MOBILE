using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // messagem powerups
    public TextMeshProUGUI messagePwText;
    //public Text messagePwText;
    private bool messagePwActive = false;
    private float textPwTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (messagePwActive)
        {
            Color color = messagePwText.color;
            color.a += 2f * Time.deltaTime;
            messagePwText.color = color;


            if (color.a >= 1)
            {
                messagePwActive = false;
                textPwTimer = 0;
            }
        }

        else if (!messagePwActive)
        {
            textPwTimer += Time.deltaTime;

            if (textPwTimer >= 2f)
            {
                Color color = messagePwText.color;
                color.a -= 2f * Time.deltaTime;
                messagePwText.color = color;
            }

            /*
            if (color.a <= 0)
            {
               messagePwText.text = "";
            }
            */
            
        }
    }

    public void SetMessagePW(string messagePW)
    {
        messagePwText.text = messagePW;
        Color color = messagePwText.color;
        color.a = 0;
        messagePwText.color = color;
        messagePwActive = true;
    }
}
