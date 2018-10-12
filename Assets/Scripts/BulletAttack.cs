using UnityEngine;
public class BulletAttack : AttackAnimation
{
    public float Force = 5000f;
    public Transform target;

    public override void FinalAnimation()
    {
        if (!endAnim)
            return;
        base.FinalAnimation();


        populationManager.SetForceAll(this.target.position - this.regroupPositions[0], Force);

    }
    //private void OnValidate()
    //{
    //    ForceDirection.Normalize();
    //}
}