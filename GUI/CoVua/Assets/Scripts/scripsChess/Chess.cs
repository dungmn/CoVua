using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chess : MonoBehaviour
{
   // public Vector3 offsetPosition;
    public Point position { get; private set; }
    public ChessInfo info;
    // public int nameChess; //1: pawn, 2:rook, 3:knight, 4: bishop, 5:queen, 6: king
    public List<cell> listTarget = new List<cell>();
    public bool color; //true: black, false: white
   // private bool isAlive = true; //true: live, false: died

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
    public abstract void move(float x, float y);
    public abstract void beSelected();

}
