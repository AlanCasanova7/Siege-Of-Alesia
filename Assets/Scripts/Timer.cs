using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Timer : MonoBehaviour
{
    public UnityEvent OnTimerFinished;

    public FloatValue Duration;

    public FloatValue CurrentTimer;

    public bool SpawnAsEnabled = false;

    private float timer;

    private void Awake()
    {
        enabled = SpawnAsEnabled;
    }
    void OnEnable()
    {
        timer = 0f;

        if (!CurrentTimer || !Duration)
            throw new NullReferenceException("Timer requires non null FloatValues references.");

        CurrentTimer.Value = timer;
    }

    void Update()
    {
        timer += Time.deltaTime;

        CurrentTimer.Value = timer;

        if (timer > Duration.Value)
        {
            OnTimerFinished.Invoke();
        }
    }
}
