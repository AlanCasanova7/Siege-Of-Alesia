using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private float collisionDisableCooldown = 0.1f;
    private bool hasBeenHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasBeenHit)
        {
            GetComponent<RagdollActivator>().ActivateAllRagdolls();
            hasBeenHit = true;
        }
    }

    public void Update()
    {
        if (!hasBeenHit)
            return;

        collisionDisableCooldown -= Time.deltaTime;
        if(collisionDisableCooldown <= 0)
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
