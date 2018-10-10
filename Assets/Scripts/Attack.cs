using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack")]
public class Attack : ScriptableObject
{
    public string AttackName;
    public int Cost;
    public int Damage;

    public Attack[] winsAgainst;
    //Probably DEBUG ONLY
    public void FireAttack() //TODO: spawns attack GOs on scene maybe?
    {
        Debug.Log(AttackName);
    }

    public void ResolveAttack(Player attackingPlayer, Player defendingPlayer, Attack otherAttack)
    {
        attackingPlayer.Population -= this.Cost;

        for (int i = 0; i < winsAgainst.Length; i++)
        {
            if (otherAttack == winsAgainst[i])
            {
                defendingPlayer.Population -= this.Damage;
                Debug.Log(AttackName + " wins against " + otherAttack.AttackName);
            }
        }
    }
}