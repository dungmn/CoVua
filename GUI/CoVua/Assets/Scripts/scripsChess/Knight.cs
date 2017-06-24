using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Chess
{
    List<Point> unitKnight;

    void Start()
    {
        unitKnight = new List<Point>();
        unitKnight.Add(new Point(1, 2));
        unitKnight.Add(new Point(2, 1));
        unitKnight.Add(new Point(2, -1));
        unitKnight.Add(new Point(1, -2));
        unitKnight.Add(new Point(-1, -2));
        unitKnight.Add(new Point(-2, -1));
        unitKnight.Add(new Point(-2, 1));
        unitKnight.Add(new Point(-1, 2));
    }
    public override void beSelected()
    {
        listTarget.Clear();
        int i = position.x;
        int j = position.y;
        foreach (var item in unitKnight)
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
