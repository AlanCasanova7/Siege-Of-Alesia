using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEffect : MonoBehaviour
{

    public ParticleSystem Effect;
    private void OnCollisionEnter(Collision collision)
    {
        if (Effect)
            GameObject.Instantiate(Effect, this.transform);
    }
}
