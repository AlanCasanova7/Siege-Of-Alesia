using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEffect : MonoBehaviour
{
    public PopulationManager Manager;
    public ParticleSystem Effect;
    public AudioClip[] Sounds;
    public AudioSource EffectSource;
    public int Percentage = 20;
    private void OnCollisionEnter(Collision collision)
    {
        if (Random.Range(0, 101) < Percentage)
        {
            Effect.time = 0f;
            Effect.Play();
            if (EffectSource.isPlaying)
                return;
            AudioClip start = Sounds[Random.Range(0, Sounds.Length)];
            EffectSource.clip = start;
            EffectSource.time = 0f;
            EffectSource.Play();
        }
    }
}
