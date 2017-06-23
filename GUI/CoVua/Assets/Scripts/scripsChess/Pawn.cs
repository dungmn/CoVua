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
        Debug.Log(position.x + "," + position.y);
        if (!isMoved)
        {
            //có khả năng đi 2 bước
            ChessBroard.Current._cell[position.x, position.y + 2].state = 1;
        }

        //có khả năng đi 1 bước
        ChessBroard.Current._cell[position.x, position.y + 1].state = 1;
        //xác định ô chéo để ăn
        if (position.x < 7 && ChessBroard.Current._cell[position.x + 1, position.y + 1].currentChess != null)
            ChessBroard.Current._cell[position.x + 1, position.y + 1].state = 1;
        if (position.x > 0 && ChessBroard.Current._cell[position.x - 1, position.y + 1].currentChess != null)
            ChessBroard.Current._cell[position.x - 1, position.y + 1].state = 1;

    }

    public override void move()
    {
        throw new NotImplementedException();
    }
}
