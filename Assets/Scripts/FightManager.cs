using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public GameManager GameManager;
    public Player Player1;
    public Player Player2;
    public BooleanValue Attack1EndStatus;
    public BooleanValue Attack2EndStatus;

    public void ResolveAttack()
    {
        if (GameManager.CurrentState != FightState.ConfrontState)
            return;

        if (Player1.ChosenAttacks.Count == 0)
        {
            GameManager.ConfrontIsOver();
            return;
        }


        Attack attack1 = Player1.ChosenAttacks.Dequeue();
        Attack attack2 = Player2.ChosenAttacks.Dequeue();

        Attack1EndStatus.Value = false;
        attack1.ResolveAttack(Player1, Player2, attack2);
        attack1.FireAttack(Attack1EndStatus);

        Attack2EndStatus.Value = false;
        attack2.ResolveAttack(Player2, Player1, attack1);
        attack2.FireAttack(Attack2EndStatus);

        Debug.Log("P1: " + Player1.Population);
        Debug.Log("P2: " + Player2.Population);

        if (Player1.Population <= 0)
        {
            GameManager.CallGameOver(Player2);
        }
        if (Player2.Population <= 0)
        {
            GameManager.CallGameOver(Player1);
        }

    }
}

