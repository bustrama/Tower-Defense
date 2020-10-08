﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;

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
}