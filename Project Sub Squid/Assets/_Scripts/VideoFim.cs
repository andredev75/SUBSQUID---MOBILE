using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFim : MonoBehaviour
{

    public VideoPlayer video;


    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;   
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckOver (VideoPlayer vp)
    {
        gameObject.SetActive(false);
        GameLootLoading.LoadScene("Fase1");
    }
}
