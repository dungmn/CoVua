using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Chess
{
    public override void beSelected()
    {
        listTarget.Clear();
        //di chuyển trái
        moveLeft();

        //di chuyển phải
        moveRight();

        //set cell state = target
        foreach (var item in listTarget)
        {
            item.state = 2;
        }

    }

    
}
