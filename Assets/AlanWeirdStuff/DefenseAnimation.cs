using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAnimation : AttackAnimation
{
    public override void StartAnimation()
    {
        Vector3 customRegroupPosition = Vector3.zero;

         populationManager.StartRegrouping(regroupPositions);
    }
}

