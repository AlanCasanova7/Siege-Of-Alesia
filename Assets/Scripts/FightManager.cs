using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public GameManager GameManager;
    public Player Player1;
    public Player Player2;

    public void ResolveAttack()
    {
        Attack attack1 = Player1.ChosenAttacks.Dequeue();
        Attack attack2 = Player2.ChosenAttacks.Dequeue();

        attack1.ResolveAttack(Player1, Player2, attack2);
        attack2.ResolveAttack(Player2, Player1, attack1);

        Debug.Log(Player1.Population);
        Debug.Log(Player2.Population);

        if (Player1.Population <= 0)
        {
            GameManager.CallGameOver(Player2);
        }
        if (Player2.Population <= 0)
        {
            GameManager.CallGameOver(Player1);
        }

        if (GameManager.currentState != FightState.ConfrontState)
            return;

        if (Player1.ChosenAttacks.Count == 0)
        {
            GameManager.ConfrontIsOver();
            return;
        }

        this.ResolveAttack();
    }
}

