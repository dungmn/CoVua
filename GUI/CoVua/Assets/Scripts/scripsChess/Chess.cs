using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Chess : MonoBehaviour
{
    // public Vector3 offsetPosition;
    public Point position;
    public ChessInfo info;
    // public int nameChess; //1: pawn, 2:rook, 3:knight, 4: bishop, 5:queen, 6: king
    public List<cell> listTarget = new List<cell>();
    public bool color; //true: black, false: white
    public bool isAlive = true; //true: live, false: died

    public void setInfo(ChessInfo _info)
    {
        this.info = _info;
        this.position = new Point(_info.x, _info.y);
        this.transform.position = new Vector3(_info.x, _info.y);

    }

    public void setPosition(int x, int y)
    {
        position = new Point(x, y);

    }

    public void destroyChess()
    {
        Destroy(this.gameObject);
    }
    public virtual void move(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
        setPosition(Convert.ToInt32(x), Convert.ToInt32(y));
        ControlGame.current.switchPlayer();
    }
    public abstract void beSelected();

    public bool isCellPosition(int x, int y)
    {
        if (x < 0 || x > 7)
            return false;
        if (y < 0 || y > 7)
            return false;
        return true;
    }

    //lấy toạ độ y khi di chuyển chéo trái
    private int getYLeft(int x)
    {
        //tìm phương trình đường thẳng qua bishop và // với y = -x + 1
        int c = position.x + position.y; //tìm phương trình đường thẳng có dạng y = -x + c
        return -x + c;
    }

    //lấy toạ độ y khi di chuyển chéo phải
    private int getYRight(int x)
    {
        //tìm phương trình đường thẳng qua bishop và // với y = x
        int c = position.y - position.x; //tìm phương trình đường thẳng có dạng y = x + c
        return x + c;
    }

    public void moveLeft()
    {
        int i = position.x + 1;
        int j;
        while (i < 8)
        {

            j = getYLeft(i);
            if (j < 0)
                break;
            if (ChessBroard.Current._cell[i, j].currentChess != null)
            {
                if (ChessBroard.Current._cell[i, j].currentChess.color != ControlGame.current.player)
                    listTarget.Add(ChessBroard.Current._cell[i, j]);
                break;
            }
            else
                listTarget.Add(ChessBroard.Current._cell[i, j]);

            i++;
        }

        i = position.x - 1;
        while (i >= 0)
        {
            j = getYLeft(i);
            if (j > 7)
                break;
            if (ChessBroard.Current._cell[i, j].currentChess != null)
            {
                if (ChessBroard.Current._cell[i, j].currentChess.color != ControlGame.current.player)
                    listTarget.Add(ChessBroard.Current._cell[i, j]);
                break;
            }
            else
                listTarget.Add(ChessBroard.Current._cell[i, j]);

            i--;
        }
    }

    public void moveRight()
    {
        int i = position.x + 1;
        int j;
        while (i < 8)
        {

            j = getYRight(i);
            if (j > 7)
                break;
            if (ChessBroard.Current._cell[i, j].currentChess != null)
            {
                if (ChessBroard.Current._cell[i, j].currentChess.color != ControlGame.current.player)
                    listTarget.Add(ChessBroard.Current._cell[i, j]);
                break;
            }
            else
                listTarget.Add(ChessBroard.Current._cell[i, j]);

            i++;
        }

        i = position.x - 1;
        while (i >= 0)
        {

            j = getYRight(i);
            if (j < 0)
                break;
            if (ChessBroard.Current._cell[i, j].currentChess != null)
            {
                if (ChessBroard.Current._cell[i, j].currentChess.color != ControlGame.current.player)
                    listTarget.Add(ChessBroard.Current._cell[i, j]);
                break;
            }
            else
                listTarget.Add(ChessBroard.Current._cell[i, j]);

            i--;
        }
    }

    public void moveHorizontal()
    {
        for (int i = position.x + 1; i < 8; i++)
        {
            if (ChessBroard.Current._cell[i, position.y].currentChess != null)
            {
                if (ChessBroard.Current._cell[i, position.y].currentChess.color != ControlGame.current.player)
                    listTarget.Add(ChessBroard.Current._cell[i, position.y]);
                break;
            }
            else
                listTarget.Add(ChessBroard.Current._cell[i, position.y]);
        }

        for (int i = position.x - 1; i >= 0; i--)
        {
            if (ChessBroard.Current._cell[i, position.y].currentChess != null)
            {
                if (ChessBroard.Current._cell[i, position.y].currentChess.color != ControlGame.current.player)
                    listTarget.Add(ChessBroard.Current._cell[i, position.y]);
                break;
            }
            else
                listTarget.Add(ChessBroard.Current._cell[i, position.y]);
        }
    }

    public void moveVertical()
    {
        for (int i = position.y + 1; i < 8; i++)
        {
            if (ChessBroard.Current._cell[position.x, i].currentChess != null)
            {
                if (ChessBroard.Current._cell[position.x, i].currentChess.color != ControlGame.current.player)
                    listTarget.Add(ChessBroard.Current._cell[position.x, i]);
                break;
            }
            else
                listTarget.Add(ChessBroard.Current._cell[position.x, i]);

        }

        for (int i = position.y - 1; i >= 0; i--)
        {
            if (ChessBroard.Current._cell[position.x, i].currentChess != null)
            {
                if (ChessBroard.Current._cell[position.x, i].currentChess.color != ControlGame.current.player)
                    listTarget.Add(ChessBroard.Current._cell[position.x, i]);
                break;
            }
            else
                listTarget.Add(ChessBroard.Current._cell[position.x, i]);

        }
    }
}
