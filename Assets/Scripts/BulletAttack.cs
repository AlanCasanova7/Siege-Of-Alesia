using UnityEngine;
public class BulletAttack : AttackAnimation
{
    public float Force = 5000f;
    public Transform target;

    public override void FinalAnimation()
    {
        Debug.Log("ATTACK");

        if (!endAnim)
            return;
        base.FinalAnimation();

        Debug.Log(regroupPositions[0] + this.transform.root.name);

        populationManager.SetForceAll(this.target.position - this.regroupPositions[0], Force);

    }
    //private void OnValidate()
    //{
    //    ForceDirection.Normalize();
    //}
}