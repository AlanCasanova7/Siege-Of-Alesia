using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{

    public PhysicsHolder[] Bodies = new PhysicsHolder[0];
    public bool StartWithPhysicsEnabled = false;

    void OnEnable()
    {
        ChangePhysics(StartWithPhysicsEnabled);
    }

    public void ChangePhysics(bool value)
    {
        for (int i = 0; i < Bodies.Length; i++)
        {
            PhysicsHolder holder = Bodies[i];
            if (holder.Collider)
            {
                holder.Collider.enabled = value;
            }
            if (holder.Joint)
            {
                holder.Joint.enableCollision = value;
                holder.Joint.enablePreprocessing = value;
                holder.Joint.enableProjection = value;
            }
            if (holder.Body)
            {
                holder.Body.isKinematic = !value;
                holder.Body.useGravity = value;
            }
        }
    }
    public void ActivatePhysics()
    {
        ChangePhysics(true);
    }
    public void DeactivatePhysics()
    {
        ChangePhysics(false);
    }
}
