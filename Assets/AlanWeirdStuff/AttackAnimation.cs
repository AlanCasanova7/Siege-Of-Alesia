using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    public Transform RegroupPoint;
    private Vector3 regroupPosition;

    private PopulationManager populationManager;

	void Start ()
    {
        regroupPosition = RegroupPoint.position;
        populationManager = this.GetComponentInChildren<PopulationManager>();
	}

    public void StartAnimation()
    {
        populationManager.StartRegrouping(regroupPosition, this);
    }

    public virtual void FinalAnimation()
    {
        populationManager.SetForceAll(new Vector3(1, 0, 0), 3000);
    }
}
