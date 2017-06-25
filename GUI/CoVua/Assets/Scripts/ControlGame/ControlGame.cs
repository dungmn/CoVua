using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGame : MonoBehaviour
{
    public static ControlGame current;
    private bool stateGame; //true: playing, false: GameOver
    public bool player = false; //true: MAX(black), false:MIN(white)

    void Awake()
    {
        current = this;
        player = false; //Min player 
        stateGame = true;
    }

    public void GameMode(bool b)
    {
        PlayerMAX.isActive = b;
    }

    public void switchPlayer()
    {
        player = !player;
    }

    public bool isGameState()
    {
        return true;
    }

    public void isEndGame(bool player)
    {
        if (player)
            SceneManager.LoadScene("BlackWin");
        else
            SceneManager.LoadScene("WhiteWin");
    }
}
