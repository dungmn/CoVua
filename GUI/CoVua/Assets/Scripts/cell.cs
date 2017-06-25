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
    private Material targetMaterial;
    private Material selectedMaterial;

    MeshRenderer my_renderer;
    void Start()
    {
        my_renderer = GetComponent<MeshRenderer>();
        targetMaterial = Resources.Load<Material>("ColorCell/target");
        selectedMaterial = Resources.Load<Material>("ColorCell/selected");
        changeCellColor();
    }

    void Update()
    {
        changestateCell();
    }

    public void changestateCell()
    {

        switch (state)
        {
            case 0:
                changeCellColor();
                break;
            case 1: //selected
                if (flagSelected)
                    my_renderer.material = selectedMaterial;
                break;
            case 2: //target
                my_renderer.material = targetMaterial;
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
        this.currentChess = c; //set cell hiện tại = chess c;
        c.currentCell = this; // set current cell của Chess c = cell hiện tại
    }

    public void OnMouseDown()
    {
        if (currentChess == null && state == 0)
            return;

        if (state == 2)
        {
            if (currentChess != null && currentChess.color != ControlGame.current.player)
            {
                /*
                    currentChess.isAlive = false;
                    currentChess.transform.position = new Vector3(-1, -1, 0);
                */

                if (currentChess.info.name == "b_king")
                    ControlGame.current.isEndGame(false);
                else
                    if (currentChess.info.name == "w_king")
                    ControlGame.current.isEndGame(true);

                currentChess.destroyChess();
                currentChess = null;
            }

            if (currentChess == null)
                doMoveAndChangeCellState();
        }
        else
            if (currentChess.color == ControlGame.current.player)
            {
                returnStateCellBefore(); //trả lại state cell trước đó 
                state = 1; //selected
                currentChess.beSelected();
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

    public void doMoveAndChangeCellState()
    {
        currentChess = ChessBroard.currentCellBefore.currentChess;
        currentChess.currentCell = this;
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
}
