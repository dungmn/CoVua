using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour {
    public static ControlGame current;
    private bool stateGame; //true: playing, false: exit
    public bool player = false; //true: MAX(black), false:MIN(white)

    void Awake()
    {
        current = this;
        player = false; //Min player 
        stateGame = true;
    }

    public void switchPlayer()
    {
        player = !player;
    }
    
}
