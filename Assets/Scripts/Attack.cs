using System;
using UnityEngine;

[System.Serializable]
public class Attack
{
    public string AttackName;

    internal void FireAttack()
    {
        Debug.Log(AttackName);
    }
}