using UnityEngine;
public class RecoveryAttack : AttackAnimation
{
    public float Force;
    public float MaxVelocityForForceApplication;
    public override void StartAnimation()
    {
        if (OnGroupingEffect)
            OnGroupingEffect.Play();
        populationManager.StartFakeRegrouping();
        FinalAnimation();
    }
    protected override void Update()
    {
        populationManager.SetForceAllIfSlowerThanThereshold(transform.up, Force, MaxVelocityForForceApplication);
        base.Update();
    }
    public override void FinalAnimation()
    {
        if (!endAnim)
            return;
        base.FinalAnimation();
    }
}