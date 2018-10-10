using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum FightState
{
    SelectionPhase,
    ConfrontState,
}
[CreateAssetMenu]
public class GameManager : ScriptableObject
{
    public UnityEvent SelectionPhaseStarted;
    public UnityEvent FightPhaseStarted;

    private FightState currentState;

    private bool isPlayer1Ready;
    private bool isPlayer2Ready;


    public void SelectionFinished(Player p)
    {
        if (true)//TODO: check if p is player 1
            isPlayer1Ready = true;
        else
            isPlayer2Ready = true;

        if (isPlayer1Ready && isPlayer2Ready)
            StartFightPhase();
    }
    public void TimeIsOver()
    {
        if(currentState != FightState.ConfrontState)
        {
            StartFightPhase();
        }
    }
    public void ConfrontIsOver()
    {
        if (currentState != FightState.SelectionPhase)
        {
            StartSelectionPhase();
        }
    }

    private void StartSelectionPhase()
    {
        currentState = FightState.SelectionPhase;
        isPlayer1Ready = false;
        isPlayer2Ready = false;
        SelectionPhaseStarted.Invoke();
    }
    private void StartFightPhase()
    {
        currentState = FightState.ConfrontState;
        FightPhaseStarted.Invoke();
    }
}
