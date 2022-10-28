using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LogicanVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudioMixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);

    }

    public void SetVolumeSFX(float sliderValue)
    {
        myAudioMixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);

    }
}
