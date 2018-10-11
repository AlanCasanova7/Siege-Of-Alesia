using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopulationManager : MonoBehaviour
{
    public UnityEvent regroupingFinished;

    private AttractTo[] bodiesToAttract;
    private float stageCooldown;
    private bool regrouping;

    private Vector3[] regroupPositions;
    private AttackAnimation animationHandler;

    void Start()
    {
        bodiesToAttract = this.GetComponentsInChildren<AttractTo>();
        stageCooldown = 2f;
        regrouping = false;
    }

    public void Update()
    {
        if (regrouping)
        {
            stageCooldown -= Time.deltaTime;
            for (int i = 0; i < bodiesToAttract.Length; i++)
            {
                bodiesToAttract[i].SetAttractionPoint(regroupPositions[i % regroupPositions.Length], 200);
            }
        }

        if (stageCooldown <= 0)
        {
            regrouping = false;
            animationHandler.FinalAnimation();
        }
    }

    public void StartRegrouping(Vector3 regroupPosition, AttackAnimation owner)
    {
        this.regroupPositions[0] = regroupPosition;
        regrouping = true;
        stageCooldown = 3f;
        animationHandler = owner;
    }

    public void StartRegrouping(Vector3[] regroupPositions, AttackAnimation owner)
    {
        for (int i = 0; i < regroupPositions.Length; i++)
        {
            this.regroupPositions[i] = regroupPositions[i];
        }
        regrouping = true;
        stageCooldown = 3f;
        animationHandler = owner;
    }

    public void SetForceAll(Vector3 direction, float force)
    {
        for (int i = 0; i < bodiesToAttract.Length; i++)
        {
            bodiesToAttract[i].GetComponent<Rigidbody>().AddForce(direction * force);
        }
    }
}
