using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Chess
{
    public bool isMoved = false;

    //tìm các nước đi có thể đi
    public override void beSelected()
    {
        listTarget.Clear();
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

    //quân đen
    private void beSelectedBlack()
    {
        if (!isMoved)
        {
            //có khả năng đi 2 bước
            if (ChessBroard.Current._cell[position.x, position.y - 1].currentChess == null)
                if (ChessBroard.Current._cell[position.x, position.y - 2].currentChess == null)
                listTarget.Add(ChessBroard.Current._cell[position.x, position.y - 2]);
        }

        //có khả năng đi 1 bước
        if (ChessBroard.Current._cell[position.x, position.y - 1].currentChess == null)
            listTarget.Add(ChessBroard.Current._cell[position.x, position.y - 1]);

        //xác định ô chéo để ăn
        if (position.x < 7 && ChessBroard.Current._cell[position.x + 1, position.y - 1].currentChess != null)
        {
            if (ChessBroard.Current._cell[position.x + 1, position.y - 1].currentChess.color != ControlGame.current.player)
                listTarget.Add(ChessBroard.Current._cell[position.x + 1, position.y - 1]);
        }
        if (position.x > 0 && ChessBroard.Current._cell[position.x - 1, position.y - 1].currentChess != null)
        {
            if (ChessBroard.Current._cell[position.x - 1, position.y - 1].currentChess.color != ControlGame.current.player)
                listTarget.Add(ChessBroard.Current._cell[position.x - 1, position.y - 1]);
        }

        foreach (var item in listTarget)
        {
            item.state = 2;
        }
    }

    //quân trắng
    private void beSelectedWhite()
    {
        if (!isMoved)
        {
            //có khả năng đi 2 bước
            if (ChessBroard.Current._cell[position.x, position.y + 1].currentChess == null)
                if (ChessBroard.Current._cell[position.x, position.y + 2].currentChess == null)
                    listTarget.Add(ChessBroard.Current._cell[position.x, position.y + 2]);
        }

        //có khả năng đi 1 bước
        if (ChessBroard.Current._cell[position.x, position.y + 1].currentChess == null)
            listTarget.Add(ChessBroard.Current._cell[position.x, position.y + 1]);

        //xác định ô chéo để ăn
        if (position.x < 7 && ChessBroard.Current._cell[position.x + 1, position.y + 1].currentChess != null)
        {
            if (ChessBroard.Current._cell[position.x + 1, position.y + 1].currentChess.color != ControlGame.current.player)
                listTarget.Add(ChessBroard.Current._cell[position.x + 1, position.y + 1]);
        }
        if (position.x > 0 && ChessBroard.Current._cell[position.x - 1, position.y + 1].currentChess != null)
        {
            if (ChessBroard.Current._cell[position.x - 1, position.y + 1].currentChess.color != ControlGame.current.player)
                listTarget.Add(ChessBroard.Current._cell[position.x - 1, position.y + 1]);
        }

        //gán state cell = target
        foreach (var item in listTarget)
        {
            item.state = 2;
        }
    }

    public override void move(float x, float y)
    {
        isMoved = true;
        base.move(x, y);
    }
}
