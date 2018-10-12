using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedCollider : MonoBehaviour
{
    public BoxCollider collider;

    public float TTime;
    private float currentTime;

    private float privateTimer = 3f;

    public void Activation()
    {
        currentTime = TTime;
        collider.enabled = true;

        privateTimer = 0;
    }

    private void Update()
    {
        if(privateTimer < 3)
        {
            privateTimer += Time.deltaTime;
            return;
        }

        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            collider.enabled = false;
        }
    }
}
