﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameOverUI;
    public GameObject completeLevel;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
            EndGame();
    }

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevel.SetActive(true);
    }
}
