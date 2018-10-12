using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    public bool Paused { get; private set; }
    public GameObject PauseMenu;
    public KeyCode PauseButton;

    float prevTimeScale;
    private void Start()
    {
        Paused = false;
        PauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(PauseButton))
        {
            if (Paused)
                UnpauseGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (Paused)
            return;
        Paused = true;
        prevTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }
    public void UnpauseGame()
    {
        if (!Paused)
            return;
        Paused = false;
        Time.timeScale = prevTimeScale;
        PauseMenu.SetActive(false);
    }
}
