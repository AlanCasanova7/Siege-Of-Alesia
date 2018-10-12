using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedCollider : MonoBehaviour
{
    public BoxCollider bCollider;

    public float TTime;
    private float currentTime;

    private float privateTimer = 3f;

    public void Activation()
    {
        currentTime = TTime;

        privateTimer = 0;
    }

    private void Update()
    {
        if(privateTimer < 3)
        {
            privateTimer += Time.deltaTime;
            return;
        }

        bCollider.enabled = true;

        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            bCollider.enabled = false;
        }
    }
}
