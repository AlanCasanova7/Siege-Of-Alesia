using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack")]
public class Attack : ScriptableObject
{
    public string AttackName;

    public Attack[] winsAgainst;
    //Probably DEBUG ONLY
    public void FireAttack()
    {
        Debug.Log(AttackName);
    }

    public void ResolveAttack(Player attackingPlayer, Player defendingPlayer, Attack otherAttack)
    {
        for (int i = 0; i < winsAgainst.Length; i++)
        {
            if (otherAttack == winsAgainst[i])
            {
                Debug.Log(AttackName + " wins against " + otherAttack.AttackName);
            }
        }
    }
}