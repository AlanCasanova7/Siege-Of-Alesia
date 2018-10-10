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

    public FightState CurrentState { get; private set; }

    public BooleanValue Player1ReadyStatus;
    public BooleanValue Player2ReadyStatus;

    public Player WinningPlayer;

    private void OnEnable()
    {
        this.StartSelectionPhase();
    }

    private void Update()
    {
        if (CurrentState == FightState.SelectionPhase && Player1ReadyStatus.Value && Player2ReadyStatus.Value)
            StartFightPhase();
    }

    internal void CallGameOver(Player winningPlayer)
    {
        WinningPlayer = winningPlayer;
        GameOver.Invoke();
        Debug.Log("GAME OVER");
        this.enabled = false;
        CurrentState = FightState.GameOver;
    }

    public void TimeIsOver()
    {
        if (CurrentState != FightState.ConfrontState)
        {
            TimeOver.Invoke();
            StartFightPhase();
        }
    }
    public void ConfrontIsOver()
    {
        if (CurrentState != FightState.SelectionPhase)
        {
            StartSelectionPhase();
        }
    }

    private void StartSelectionPhase()
    {
        Debug.Log("Start Selection");
        CurrentState = FightState.SelectionPhase;
        Player1ReadyStatus.Value = false;
        Player2ReadyStatus.Value = false;
        SelectionPhaseStarted.Invoke();
    }
    private void StartFightPhase()
    {
        Debug.Log("Start Fight");
        CurrentState = FightState.ConfrontState;
        FightPhaseStarted.Invoke();
    }
}
