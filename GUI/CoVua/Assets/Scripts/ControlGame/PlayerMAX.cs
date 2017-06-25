using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMAX : MonoBehaviour
{
    public static bool isActive = true; //true: Activate, false: deactivate
    // Use this for initialization
    void Start()
    {
        if (isActive)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlGame.current.player)
        {
            int lenght = ChessBroard.Current.listChessBlack.Count - 1; //số phần tử của listChessBlack - 1 để random
            System.Random rand = new System.Random();

            while (MAXmove(rand.Next(0, lenght)));
        }

    }

    private bool MAXmove(int index)
    {
        System.Random rand = new System.Random();
        
        ChessBroard.Current.listChessBlack[index].currentCell.OnMouseDown(); //click vô cell đó
        if (ChessBroard.Current.listChessBlack[index].listTarget.Count == 0) //Nếu ko có target trả về false
            return true;
        else
        {
            int length = ChessBroard.Current.listChessBlack[index].listTarget.Count - 1; //số phần tử listtarget - 1 để random
            ChessBroard.Current.listChessBlack[index].listTarget[rand.Next(0, length)].OnMouseDown(); //click vô target
        }
        return false;
    }
}


