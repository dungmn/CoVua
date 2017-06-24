using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Chess
{
    public override void beSelected()
    {
        //di chuyển trái
        listTarget.Clear();
        moveLeft();
        //di chuyển phải
        moveRight();
        //di chuyển ngang
        moveHorizontal();
        //di chuyển dọc
        moveVertical();
        //set cell state = target
        foreach (var item in listTarget)
        {
            item.state = 2;
        }
    }
}
