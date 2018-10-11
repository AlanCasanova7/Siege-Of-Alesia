using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour
{
    private AttractTo[] bodiesToAttract;

	void Start ()
    {
        bodiesToAttract = this.GetComponentsInChildren<AttractTo>();
	}
	
    public void StartAnimation(Vector3 regroupPosition)
    {
        for (int i = 0; i < bodiesToAttract.Length; i++)
        {
            bodiesToAttract[i].SetAttractionPoint(regroupPosition, 200);
        }
    }

    public void FireAnimation()
    {

    }
}
