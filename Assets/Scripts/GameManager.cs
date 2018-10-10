using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum FightState
{
    SelectionPhase,
    ConfrontState,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    public UnityEvent TimeOver;
    public UnityEvent SelectionPhaseStarted;
    public UnityEvent FightPhaseStarted;
    public UnityEvent GameOver;

    public FightState currentState { get; private set; }

    private bool isPlayer1Ready;
    private bool isPlayer2Ready;

    public Player WinningPlayer;

    private void OnEnable()
    {
        this.StartSelectionPhase();
    }

    public void SelectionFinished(Player p)
    {
        if (p.Index == 0)//TODO: check if p is player 1
            isPlayer1Ready = true;
        else
            isPlayer2Ready = true;

        if (isPlayer1Ready && isPlayer2Ready)
            StartFightPhase();
    }

    internal void CallGameOver(Player winningPlayer)
    {
        WinningPlayer = winningPlayer;
        GameOver.Invoke();
        Debug.Log("GAME OVER");
        this.enabled = false;
        currentState = FightState.GameOver;
    }

    public void TimeIsOver()
    {
        if(currentState != FightState.ConfrontState)
        {
            TimeOver.Invoke();
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
        Debug.Log("Start Selection");
        currentState = FightState.SelectionPhase;
        isPlayer1Ready = false;
        isPlayer2Ready = false;
        SelectionPhaseStarted.Invoke();
    }
    private void StartFightPhase()
    {
        Debug.Log("Start Fight");
        currentState = FightState.ConfrontState;
        FightPhaseStarted.Invoke();
    }
}
