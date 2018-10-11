using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack")]
public class Attack : ScriptableObject
{
    public GameObject AnimationPrefab;
    public Sprite Image;

    public FloatValue FervorMultiplier;
    public FloatValue DamageMultiplier;
    public FloatValue RecoveryMultiplier;

    public int Cost;
    public int Damage;
    public int Fervor;

    public Attack[] winsAgainst;

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
            }
        }
    }
}