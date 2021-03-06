﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum FightState
{
    Introduction,
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

    public GameResult GameOverResults;

    public FightState CurrentState { get; private set; }

    public BooleanValue Player1ReadyStatus;
    public BooleanValue Player2ReadyStatus;

    public Player Player1;
    public Player Player2;

    public GameObject Tutorial;
    public GameObject First;
    public GameObject Second;

    [SerializeField]
    private IntValue[] intValuesToReset;
    [SerializeField]
    private BooleanValue[] boolValuesToReset;
    [SerializeField]
    private FloatValue[] floatValuesToReset;

    private void Awake()
    {
        CurrentState = FightState.Introduction;
        Tutorial.SetActive(true);
        First.SetActive(false);
        Second.SetActive(false);
    }
    private void OnEnable()
    {
        if (CurrentState != FightState.Introduction)
            StartSelectionPhase();
    }

    public void IntroductionOver()
    {
        if (CurrentState == FightState.Introduction)
        {
            Tutorial.SetActive(false);
            First.SetActive(true);
            Second.SetActive(true);
            StartSelectionPhase();
        }
    }

    private void Start()
    {
        GameOverResults.Reset();
        if (intValuesToReset != null)
        {
            for (int i = 0; i < intValuesToReset.Length; i++)
            {
                intValuesToReset[i].OnEnable();
            }
        }
        if (boolValuesToReset != null)
        {
            for (int i = 0; i < boolValuesToReset.Length; i++)
            {
                boolValuesToReset[i].OnEnable();
            }
        }
        if (floatValuesToReset != null)
        {
            for (int i = 0; i < floatValuesToReset.Length; i++)
            {
                floatValuesToReset[i].OnEnable();
            }
        }
        GameOverResults.TotalTime = Time.time;
    }

    private void Update()
    {
        if (Input.anyKeyDown && CurrentState == FightState.Introduction)
        {
            IntroductionOver();
            return;
        }
        if (CurrentState == FightState.SelectionPhase && Player1ReadyStatus.Value && Player2ReadyStatus.Value)
            StartFightPhase();
    }

    internal void CallGameOver(Player winningPlayer)
    {
        GameOverResults.IndexWinner = winningPlayer.Index;
        GameOverResults.FervorWinner = winningPlayer.Fervor.Value;
        GameOverResults.PopulationWinner = winningPlayer.Population.Value;
        GameOverResults.TotalTime = Time.time - GameOverResults.TotalTime;
        GameOver.Invoke();
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
        if (Player1.Population.Value <= 0)
        {
            CallGameOver(Player2);
            return;
        }
        if (Player2.Population.Value <= 0)
        {
            CallGameOver(Player1);
            return;
        }
        CurrentState = FightState.SelectionPhase;
        Player1ReadyStatus.Value = false;
        Player2ReadyStatus.Value = false;
        SelectionPhaseStarted.Invoke();
    }
    private void StartFightPhase()
    {
        CurrentState = FightState.ConfrontState;
        GameOverResults.TotalGameTurns++;
        FightPhaseStarted.Invoke();
    }
}
