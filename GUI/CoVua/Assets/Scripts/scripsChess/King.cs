using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Chess
{
    List<Point> unitKing;
    void Start()
    {
        unitKing = new List<Point>();
        unitKing.Add(new Point(0,1));
        unitKing.Add(new Point(1,0));
        unitKing.Add(new Point(0,-1));
        unitKing.Add(new Point(-1,0));
        unitKing.Add(new Point(1,1));
        unitKing.Add(new Point(-1,1));
        unitKing.Add(new Point(1,-1));
        unitKing.Add(new Point(-1,-1));
    }
    public override void beSelected()
    {
        listTarget.Clear();
        int i = position.x;
        int j = position.y;

        foreach (var item in unitKing)
        {
            if (isCellPosition(i + item.x, j + item.y))
                if (ChessBroard.Current._cell[i + item.x, j + item.y].currentChess != null)
                {
                    if (ChessBroard.Current._cell[i + item.x, j + item.y].currentChess.color != ControlGame.current.player)
                        listTarget.Add(ChessBroard.Current._cell[i + item.x, j + item.y]);
                }
                else
                    listTarget.Add(ChessBroard.Current._cell[i + item.x, j + item.y]);
        }

        foreach (var item in listTarget)
        {
            item.state = 2;
        }
    }
}
