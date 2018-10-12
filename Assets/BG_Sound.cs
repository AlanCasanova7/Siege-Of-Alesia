using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BG_Sound : MonoBehaviour
{
    public AudioClip[] Clips;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        AudioClip start = Clips[Random.Range(0, Clips.Length)];
        source.clip = start;
        source.time = 0f;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (source.isPlaying)
            return;
        AudioClip start = Clips[Random.Range(0, Clips.Length)];
        source.clip = start;
        source.time = 0f;
        source.Play();
    }
}
