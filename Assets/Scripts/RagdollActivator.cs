using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollActivator : MonoBehaviour {

    private RagdollHandler[] toActivate;
    public KeyCode Activator;
    public Vector3 Force;

    void Start ()
    {
        toActivate = GetComponentsInChildren<RagdollHandler>();
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(Activator))
        {
            ActivateAllRagdolls();
        }
	}

    public void ActivateAllRagdolls()
    {
        for (int i = 0; i < toActivate.Length; i++)
        {
            toActivate[i].ActivatePhysics();
            for (int j = 0; j < toActivate[i].Bodies.Length; j++)
            {
                toActivate[i].Bodies[j].Body.AddForce(Force);
            }
        }
    }
}
