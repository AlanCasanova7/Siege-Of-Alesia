using System;
using UnityEngine;


/*
 Fervore da -3 a 3.
 Aumenta con mossa, quando aumenta l altro diminuisce
 Piu fervore: costo fervore diminuisce e  recovery aumenta
 
     
     
     */
[CreateAssetMenu(fileName = "Attack")]
public class Attack : ScriptableObject
{
    public FloatValue FervorMultiplier;
    public FloatValue DamageMultiplier;
    public FloatValue RecoveryMultiplier;

    public string AttackName;
    public int Cost;
    public int Damage;
    public int Fervor;

    public Attack[] winsAgainst;
    //Probably DEBUG ONLY
    public void FireAttack(BooleanValue endStatus) //TODO: spawns attack GOs on scene maybe?
    {
        Debug.Log(AttackName);
    }

    public void ResolveAttack(Player attackingPlayer, Player defendingPlayer, Attack otherAttack)
    {
        int totalCost = this.Cost;
        //reduce recovery cost if fervor is positive
        if (totalCost < 0)
            totalCost -= (int)(RecoveryMultiplier.Value * totalCost * attackingPlayer.Fervor.Value);

        //se mossa corrent aumenta fervore aumenta/riduci costo
        if (Fervor > 0)
        {
            totalCost = totalCost + (int)(totalCost * FervorMultiplier.Value * attackingPlayer.Fervor.Value);
        }

        attackingPlayer.Population.Value -= totalCost;

        for (int i = 0; i < winsAgainst.Length; i++)
        {
            int totalDamage = this.Damage;
            totalDamage = totalDamage + (int)(totalDamage * DamageMultiplier.Value * attackingPlayer.Fervor.Value);
            if (otherAttack == winsAgainst[i])
            {
                defendingPlayer.Population.Value -= totalDamage;
                Debug.Log(AttackName + " wins against " + otherAttack.AttackName);
            }
        }
    }
}