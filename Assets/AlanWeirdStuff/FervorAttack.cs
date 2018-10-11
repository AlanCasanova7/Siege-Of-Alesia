using UnityEngine;
public class FervorAttack : AttackAnimation
{
    public float Force = 7500f;

    public bool Save = false;


    protected override void Start()
    {
        this.enabled = false;
        this.populationManager = this.GetComponentInChildren<PopulationManager>();
    }

    public override void FinalAnimation()
    {
        if (!endAnim)
            return;
        base.FinalAnimation();

       populationManager.SetForceAll(this.transform.up, Force);
    }

    public void OnValidate()
    {
        if (Save)
        {
            regroupPositions = new Vector3[RegroupPoints.Length];
            for (int i = 0; i < RegroupPoints.Length; i++)
            {
                regroupPositions[i] = RegroupPoints[i].position;
            }
            Save = false;
        }
    }
    //private void OnValidate()
    //{
    //    ForceDirection.Normalize();
    //}
}