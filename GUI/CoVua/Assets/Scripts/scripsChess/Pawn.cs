using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Chess
{
    public bool isMoved = false;
    public override void beSelected()
    {
        switch (color)
        {
            case true:
                beSelectedBlack();
                break;
            case false:
                beSelectedWhite();
                break;
        }
    }

    private void beSelectedBlack()
    {

    }

    private void beSelectedWhite()
    {
        if (!isMoved)
        {
            //có khả năng đi 2 bước
            listTarget.Add(ChessBroard.Current._cell[position.x, position.y + 2]);
        }

        //có khả năng đi 1 bước
        listTarget.Add(ChessBroard.Current._cell[position.x, position.y + 1]);

        //xác định ô chéo để ăn
        if (position.x < 7 && ChessBroard.Current._cell[position.x + 1, position.y + 1].currentChess != null)
        {
            listTarget.Add(ChessBroard.Current._cell[position.x + 1, position.y + 1]);
        }
        if (position.x > 0 && ChessBroard.Current._cell[position.x - 1, position.y + 1].currentChess != null)
        {
            listTarget.Add(ChessBroard.Current._cell[position.x - 1, position.y + 1]);
        }

        foreach (var item in listTarget)
        {
            item.state = 2;
        }
    }

    public override void move(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
        setPosition(Convert.ToInt32(x),Convert.ToInt32(y));
        isMoved = true;
    }
}
