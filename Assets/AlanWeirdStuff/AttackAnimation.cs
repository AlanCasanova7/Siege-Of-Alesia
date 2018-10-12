using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAnimation : MonoBehaviour
{
    public string triggerName;

    public ParticleSystem OnGroupingEffect;
    public ParticleSystem OnFinalAnimEffect;

    public Transform[] RegroupPoints;
    [SerializeField]
    protected Vector3[] regroupPositions;

    protected PopulationManager populationManager;
    [SerializeField]
    protected float finalTime = 3f;

    protected BooleanValue endAnim;
    private float timer;

    protected virtual void Start()
    {
        this.enabled = false;
        regroupPositions = new Vector3[RegroupPoints.Length];
        for (int i = 0; i < RegroupPoints.Length; i++)
        {
            regroupPositions[i] = RegroupPoints[i].position;
        }
        populationManager = this.GetComponentInChildren<PopulationManager>();
    }
    public void StartAnimation(BooleanValue endAnim)
    {
        this.endAnim = endAnim;
        StartAnimation();
    }
    protected virtual void Update()
    {
        timer += Time.deltaTime;
        if (timer > finalTime)
        {
            endAnim.Value = true;
            this.enabled = false;
            this.endAnim = null;
        }
    }
    public virtual void StartAnimation()
    {
        populationManager.StartRegrouping(regroupPositions);
        if (OnGroupingEffect)
            OnGroupingEffect.Play();
    }

    public virtual void FinalAnimation()
    {
        if (!endAnim)
            return;
        if (OnFinalAnimEffect)
            OnFinalAnimEffect.Play();

        timer = 0f;

        this.enabled = true;
    }
}
