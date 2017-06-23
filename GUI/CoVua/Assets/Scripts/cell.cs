using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{

    public bool color; //0: white, 1: black
    public int state; //0: normal, 1: selected, 2: targeted
    public bool flagSelected = false;
    public Chess currentChess;
    private Material blackMaterial;
    private Material whiteMaterial;
    private Material hoverMaterial;
    private Material selectedMaterial;

    MeshRenderer my_renderer;
    void Start()
    {
        changeCellColor();
    }

    void Update()
    {
        changestateCell();
    }
    public void changestateCell()
    {
        my_renderer = GetComponent<MeshRenderer>();
        hoverMaterial = Resources.Load<Material>("ColorCell/hover");
        selectedMaterial = Resources.Load<Material>("ColorCell/selected");
        switch (state)
        {
            case 0:
                changeCellColor();
                break;
            case 1: //selected
                if (flagSelected)
                    my_renderer.material = selectedMaterial;
                currentChess.beSelected();
                break;
            case 2: //target
                my_renderer.material = hoverMaterial;
                break;

            default:

                break;
        }
    }

    public void changeCellColor()
    {
        my_renderer = GetComponent<MeshRenderer>();
        blackMaterial = Resources.Load<Material>("ColorCell/black");
        whiteMaterial = Resources.Load<Material>("ColorCell/white");

        switch (color)
        {
            case true:
                my_renderer.material = blackMaterial;
                break;
            case false:
                my_renderer.material = whiteMaterial;
                break;
        }
    }

    public void setPosition(Vector3 vt)
    {
        this.transform.position = vt;
    }

    public void setCurrentChess(Chess c)
    {
        this.currentChess = c;
    }

    public void OnMouseDown()
    {
        if (currentChess == null && state == 0)
            return;

        if (state == 2)
        {
            currentChess = ChessBroard.currentCellBefore.currentChess;

            currentChess.move(transform.position.x, transform.position.y);
            ChessBroard.currentCellBefore.state = 0;
            foreach (var item in ChessBroard.currentCellBefore.currentChess.listTarget)
            {
                item.state = 0;
            }
            ChessBroard.currentCellBefore.currentChess = null;
            ChessBroard.currentCellBefore = null;
            currentChess.listTarget.Clear();
            state = 0;
        }
        else
        if (currentChess.color == ControlGame.current.player)
        {
            returnStateCellBefore(); //trả lại state cell trước đó 
            state = 1; //selected
            flagSelected = true;
        }

    }

    public void returnStateCellBefore()
    {
        if (ChessBroard.currentCellBefore)
        {
            ChessBroard.currentCellBefore.flagSelected = false;
            ChessBroard.currentCellBefore.state = 0;
            foreach (var item in ChessBroard.currentCellBefore.currentChess.listTarget)
            {
                item.state = 0;
            }
        }
        ChessBroard.currentCellBefore = this;
    }

    internal void setCurrentChess(ref Rook p)
    {
        throw new NotImplementedException();
    }
}
