using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ButtonLoadOtherScene(string scene)
    {
        GameLootLoading.LoadScene(scene);
    }
}
