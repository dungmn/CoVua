using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{

    public bool color; //0: white, 1: black
    public int state; //0: normal, 1: Hover, 2: selected, 3: targeted
    private int ChessPresent;
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
            case 1: //hover
                my_renderer.material = hoverMaterial;
                break;
            case 2: //selected
                my_renderer.material = selectedMaterial;
                currentChess.beSelected();
                break;
            case 3:
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
       // if (currentChess != null)
            this.state = 2; //selected
    }

    public void OnMouseEnter()
    {
        this.state = 1; //hover
    }

    public void OnMouseExit()
    {
        if (this.state == 1)
        {
            changeCellColor();
            this.state = 0; //normal
        }

    }

    internal void setCurrentChess(ref Rook p)
    {
        throw new NotImplementedException();
    }
}
