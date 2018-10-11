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
    // Use this for initialization
    void Start ()
    {
        //attractionPoint = transformToGoTo.position;
        //SetAttractionPoint(attractionPoint, 2000f);
    }

    // Update is called once per frame
    void Update ()
    {
        if (!hasToBeAttracted)
            return;

        Vector3 directionToCenter = (attractionPoint - this.transform.position).normalized;
        float distance = directionToCenter.magnitude;
        Rigidbody thisRigidBody = this.GetComponent<Rigidbody>();
        thisRigidBody.velocity = new Vector3(Mathf.Clamp(thisRigidBody.velocity.x, -100, 100), Mathf.Clamp(thisRigidBody.velocity.y, -100, 100), Mathf.Clamp(thisRigidBody.velocity.z, -100, 100));
        thisRigidBody.AddForce(directionToCenter * distance * 200);
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
