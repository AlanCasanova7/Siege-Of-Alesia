using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tornado : MonoBehaviour
{
    //To make the boxes and spheres being sucked up by the tornado, I have 4 forces and the strength of the force is based on the distance to the center of the tornado and the distance to the top of the tornado.I tweak the strength of the forces with animation curves, so stuff further away and not being affected in the same way as stuff closer to the tornado.
    
    //- Force 1 is a suction force that makes the stuff move towards the tornado
    //- Force 2 is a rotation force to make the stuff spin around the tornado, which I apply perpendicular to the center of the tornado
    //- Force 3 is a lift force to make the stuff move up
    //- Force 4 is a centrifugal force to make the stuff move away from the tornado

    private Rigidbody[] bodies;

    public AnimationCurve suctionForceMultiplier;
    public float suctionBasicForce;

    public AnimationCurve liftForceMultiplier;
    public float liftBasicForce;

    public AnimationCurve centrifugalForceMultiplier;
    public float centrifugalBasicForce;

    public float maxSqrDistance;
    //public AnimationCurve suctionForceMultiplier;
    //public AnimationCurve suctionForceMultiplier;

    private void Start()
    {
        RagdollHandler[] ragHandler = this.GetComponentsInChildren<RagdollHandler>();
        bodies = new Rigidbody[ragHandler.Length];
        for (int i = 0; i < ragHandler.Length; i++)
        {
            bodies[i] = ragHandler[i].Bodies[2].Body;
            ragHandler[i].ActivatePhysics();
        }
    }

    private void FixedUpdate()
    {
        Vector3 pos = this.transform.position;

        for (int i = 0; i < bodies.Length; i++)
        {
            Vector3 directionToCenter = pos - bodies[i].transform.position;
            float distance = directionToCenter.sqrMagnitude;

            float evaluation = distance / maxSqrDistance;

            float suctionMultiplier = suctionForceMultiplier.Evaluate(evaluation);
            float liftMultiplier = liftForceMultiplier.Evaluate(evaluation);
            float centrifugalMultiplier = centrifugalForceMultiplier.Evaluate(evaluation);

            Vector3 finalForce = Vector3.zero;

            finalForce += directionToCenter.normalized * suctionMultiplier * suctionBasicForce;
            finalForce += this.transform.up * liftMultiplier * liftBasicForce;
            finalForce -= directionToCenter.normalized * centrifugalBasicForce * centrifugalMultiplier;

            Quaternion q = Quaternion.AngleAxis(10, new Vector3(0, 1, 0));
            bodies[i].MovePosition(q * (bodies[i].transform.position - this.transform.position) + this.transform.position);
            bodies[i].MoveRotation(bodies[i].transform.rotation * q);

            bodies[i].AddForce(finalForce);
        }

        //Vector3 suctionForceV = 
    }
}
