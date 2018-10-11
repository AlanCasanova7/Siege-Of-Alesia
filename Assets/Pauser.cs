using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{

    public GameObject PauseMenu;
    public KeyCode PauseButton;

    float prevTimeScale;
    private void Start()
    {
        PauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(PauseButton))
        {
            if (PauseMenu.activeSelf)
                UnpauseGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (PauseMenu.activeSelf)
            return;

        prevTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }
    public void UnpauseGame()
    {
        Time.timeScale = prevTimeScale;
        PauseMenu.SetActive(false);
    }
}
