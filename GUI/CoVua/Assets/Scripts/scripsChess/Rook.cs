using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chess
{
    // Use this for initialization
    public override void beSelected()
    {
        listTarget.Clear();
        //Di chuyển ngang
        moveHorizontal();

        //Di chuyển dọc
        moveVertical();

        //set cell state = target
        foreach (var item in listTarget)
        {
            item.state = 2;
        }
    }

    
}
