using UnityEngine;
public class BulletAttack : AttackAnimation
{
    public float Force = 5000f;

    public override void FinalAnimation()
    {
        if (!endAnim)
            return;
        base.FinalAnimation();

        populationManager.SetForceAll(this.transform.forward, Force);
    }
    //private void OnValidate()
    //{
    //    ForceDirection.Normalize();
    //}
}