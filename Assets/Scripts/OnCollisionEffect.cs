using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEffect : MonoBehaviour
{
    public PopulationManager Manager;
    public ParticleSystem Effect;
    public int Percentage = 20;
    private void OnCollisionEnter(Collision collision)
    {
        if (Random.Range(0, 101) < Percentage)
            GameObject.Instantiate(Effect, this.transform);
    }
}
