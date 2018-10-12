using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBG : MonoBehaviour {

    public AudioClip Clip1;
    public AudioClip Clip2;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        AudioClip start =Clip1;
        source.clip = start;
        source.loop = false;
        source.time = 0f;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (source.isPlaying)
            return;
        AudioClip start = Clip2;
        source.clip = start;
        source.loop = true;
        source.time = 0f;
        source.Play();
    }
}
