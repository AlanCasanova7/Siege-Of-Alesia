﻿using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack")]
public class Attack : ScriptableObject
{
    public Fervor FervorValues;
    public Sprite Image;

    //public FloatValue FervorMultiplier;
    //public FloatValue DamageMultiplier;
    //public FloatValue RecoveryMultiplier;

    public string attName;

    public int Cost;
    public int Damage;
    public int Fervor;

    public Attack[] winsAgainst;

    public void ResolveAttack(Player attackingPlayer, Player defendingPlayer, Attack otherAttack, FightResult resP1, FightResult resP2)
    {
        int totalCost = this.Cost;
        //reduce recovery cost if fervor is positive
        if (totalCost < 0)
            totalCost -= (totalCost + FervorValues.RecoverValues[attackingPlayer.Fervor.Value]);

        //se mossa corrent aumenta fervore aumenta/riduci costo
        if (Fervor > 0)
        {
            totalCost = totalCost + (int)(totalCost + FervorValues.SelfDmgValues[attackingPlayer.Fervor.Value]);
        }

        resP1.SelfDamage = totalCost;

        Debug.LogFormat(attName + " against " + otherAttack.attName);

        for (int i = 0; i < winsAgainst.Length; i++)
        {
            int totalDamage = this.Damage;
            totalDamage = totalDamage + (int)(totalDamage + FervorValues.DmgValues[attackingPlayer.Fervor.Value]);
            if (otherAttack == winsAgainst[i])
            {
                resP2.ReceivedDamage = totalDamage;
            }
        }
    }
}