using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class ImageEvent : UnityEvent<Sprite>
{

}
public class FightManager : MonoBehaviour
{
    public GameManager GameManager;
    public ImageEvent Move1Started;
    public ImageEvent Move2Started;
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
        AttackAnimation anim1 = Player1.ChosenAttacksAnim.Dequeue();
        AttackAnimation anim2 = Player2.ChosenAttacksAnim.Dequeue();

        Move1Started.Invoke(attack1.Image);
        Move2Started.Invoke(attack2.Image);

        if (attack1.Fervor != attack2.Fervor)
        {
            Player1.Fervor.Value += attack1.Fervor - attack2.Fervor;
            Player2.Fervor.Value += attack2.Fervor - attack1.Fervor;
        }

        anim1.StartAnimation(Attack1EndStatus);
        anim2.StartAnimation(Attack2EndStatus);

        Attack1EndStatus.Value = false;
        attack1.ResolveAttack(Player1, Player2, attack2);

        Attack2EndStatus.Value = false;
        attack2.ResolveAttack(Player2, Player1, attack1);

        Debug.Log("P1: " + Player1.Population.Value);
        Debug.Log("P2: " + Player2.Population.Value);

        if (Player1.Population.Value <= 0)
        {
            GameManager.CallGameOver(Player2);
        }
        if (Player2.Population.Value <= 0)
        {
            GameManager.CallGameOver(Player1);
        }

    }
}

