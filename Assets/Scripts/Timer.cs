using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Timer : MonoBehaviour
{
    public UnityEvent OnTimerFinished;

    public FloatValue Duration;

    public FloatValue CurrentValue;

    public bool SpawnAsEnabled = false;

    private float timer;

    private void Awake()
    {
        enabled = SpawnAsEnabled;
    }
    void OnEnable()
    {
        timer = 0f;

        if (!CurrentValue || !Duration)
            throw new NullReferenceException("Timer requires non null FloatValues references.");

        CurrentValue.Value = timer;
    }

    void Update()
    {
        timer += Time.deltaTime;

        CurrentValue.Value = timer;

        if (timer > Duration.Value)
        {
            this.enabled = false;
            OnTimerFinished.Invoke();
        }
    }
}
