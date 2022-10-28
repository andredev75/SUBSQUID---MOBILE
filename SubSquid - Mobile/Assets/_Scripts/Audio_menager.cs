using UnityEngine.Audio;
using System;
using UnityEngine;

public class Audio_menager : MonoBehaviour
{

    public Sound[] sounds;

    public static Audio_menager instance1;
    // Start is called before the first frame update
    void Awake()
    {

        if (instance1 == null)
            instance1 = this;
        else 
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.outputAudioMixerGroup = s.group;

           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop  = s.loop;
        }  
    }

    public void Start() 
    {
        //Play("Ambiente");

        //if(!Race_Menager.instance.Isstarting)
        //{
           // Play("Tema");
        //}

    }

  
    public void Play (string name)
    {
        
        Sound s = Array.Find(sounds,sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + "Não encontrado");
            return;
        }
            
        s.source.Play();
    }

     public void StopPlaying (string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
        }

        //s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        //s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Pause ();
    }

    




















}
