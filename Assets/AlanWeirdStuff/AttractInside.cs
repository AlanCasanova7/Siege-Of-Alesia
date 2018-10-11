using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractInside : MonoBehaviour
{
    public Transform tr;

    private Rigidbody[] bodies;
    public bool CollectingBodies;

	void Start ()
    {
        RagdollHandler[] ragHandler = this.GetComponentsInChildren<RagdollHandler>();
        bodies = new Rigidbody[ragHandler.Length];
        for (int i = 0; i < ragHandler.Length; i++)
        {
            //for (int j = 0; j < ragHandler[i].Bodies.Length; j++)
            //{
            //    ragHandler[i].Bodies[j].Body.maxDepenetrationVelocity = 1;
            //}
            bodies[i] = ragHandler[i].Bodies[2].Body;
            ragHandler[i].ActivatePhysics();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (CollectingBodies)
                CollectingBodies = false;
            else
                CollectingBodies = true;
        }

        if (CollectingBodies)
            CollectBodies();
        else
            ShotBodies();
    }

    public void CollectBodies()
    {
        Vector3 pos;
        if (tr = null)
        {
            pos = this.transform.position;
        }
        else
            pos = this.tr.position;

        for (int i = 0; i < bodies.Length; i++)
        {
            Vector3 directionToCenter = (pos - bodies[i].transform.position).normalized;
            float distance = directionToCenter.magnitude;
            bodies[i].AddForce(directionToCenter * distance * 200);
            bodies[i].velocity = new Vector3(Mathf.Clamp(bodies[i].velocity.x, -100, 100), Mathf.Clamp(bodies[i].velocity.y, -100, 100), Mathf.Clamp(bodies[i].velocity.z, -100, 100));
        }
    }

    public void ShotBodies()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 1);
        if (colliders.Length >= 45 * 6)
        {
            for (int i = 0; i < bodies.Length; i++)
            {
                bodies[i].AddForce(new Vector3(3000, 0, 0));
            }
        }
    }
}
