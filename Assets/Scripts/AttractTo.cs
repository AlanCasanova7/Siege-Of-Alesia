using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractTo : MonoBehaviour
{
    public float MaxVelocity = 5f;
    //public Transform transformToGoTo;

    private Vector3 attractionPoint;
    private float forceToAttractPoint;
    private bool hasToBeAttracted;
    private Rigidbody thisRigidBody;

    private float MaxFreezeTime = 0.6f;
    // Use this for initialization
    void Start ()
    {
        thisRigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (thisRigidBody.isKinematic)
        {
            MaxFreezeTime -= Time.deltaTime;
            if (MaxFreezeTime <= 0)
            {
                MaxFreezeTime = 0.6f;
                thisRigidBody.isKinematic = false;
            }
        }

        if (!hasToBeAttracted)
            return;

        Vector3 directionToCenter = (attractionPoint - this.transform.position).normalized;
        float distance = directionToCenter.magnitude;
        thisRigidBody.AddForce(directionToCenter * distance * forceToAttractPoint);
        thisRigidBody.velocity = new Vector3(Mathf.Clamp(thisRigidBody.velocity.x, -MaxVelocity, MaxVelocity), Mathf.Clamp(thisRigidBody.velocity.y, -MaxVelocity, MaxVelocity), Mathf.Clamp(thisRigidBody.velocity.z, -MaxVelocity, MaxVelocity));
    }

    public void SetAttractionPoint(Vector3 attractionPoint, float forceToAttractPoint)
    {
        this.attractionPoint = attractionPoint;
        this.forceToAttractPoint = forceToAttractPoint;
        hasToBeAttracted = true;
    }

    public void StopAttracting()
    {
        attractionPoint = Vector3.zero;
        forceToAttractPoint = 0;
        hasToBeAttracted = false;
    }
}
