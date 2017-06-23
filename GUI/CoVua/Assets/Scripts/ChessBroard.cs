using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBroard : MonoBehaviour
{
    public static ChessBroard Current;
    public static cell currentCellBefore; //lấy cell trước khi selected lần 2
    public GameObject CellPrefap;
    public cell[,] _cell;
    private List<Chess> listChess;  //lưu quân cờ
    // Use this for initialization
    public void Start()
    {
        initChessBoard();
        initChessOnBoard();
    }

    void Awake()
    {
       
        Current = this;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void initChessBoard()
    {
        _cell = new cell[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject g = Instantiate(CellPrefap, new Vector3(i, j), Quaternion.identity);
                g.transform.parent = this.transform.GetChild(0); //cell sinh ra sẽ là con của chessbroard
                _cell[i, j] = g.GetComponent<cell>();
                if ((i + j) % 2 == 0)
                {
                    _cell[i, j].color = true; //tạo bàn cờ đen trắng
                }
            }
        }
    }

    public void initChessOnBoard()
    {
        listChess = new List<Chess>();
        List<ChessInfo> list = new List<ChessInfo>();
        //pawn
        for (int i = 0; i < 8; i++)
        {
            list.Add(new ChessInfo() { name = "w_pawn", path = "chessType/pawn_white", x = i, y = 1 });
            list.Add(new ChessInfo() { name = "b_pawn", path = "chessType/pawn_black", x = i, y = 6 });
        }

        //rook, knight, bishop, queen, king, bishop, knight, rook
        //--white
        list.Add(new ChessInfo() { name = "w_rook", path = "chessType/rook_white", x = 0, y = 0 });
        list.Add(new ChessInfo() { name = "w_knight", path = "chessType/knight_white", x = 1, y = 0 });
        list.Add(new ChessInfo() { name = "w_bishop", path = "chessType/bishop_white", x = 2, y = 0 });
        list.Add(new ChessInfo() { name = "w_queen", path = "chessType/queen_white", x = 3, y = 0 });
        list.Add(new ChessInfo() { name = "w_king", path = "chessType/king_white", x = 4, y = 0 });
        list.Add(new ChessInfo() { name = "w_bishop", path = "chessType/bishop_white", x = 5, y = 0 });
        list.Add(new ChessInfo() { name = "w_knight", path = "chessType/knight_white", x = 6, y = 0 });
        list.Add(new ChessInfo() { name = "w_rook", path = "chessType/rook_white", x = 7, y = 0 });
        //---black
        list.Add(new ChessInfo() { name = "b_rook", path = "chessType/rook_black", x = 0, y = 7 });
        list.Add(new ChessInfo() { name = "b_knight", path = "chessType/knight_black", x = 1, y = 7 });
        list.Add(new ChessInfo() { name = "b_bishop", path = "chessType/bishop_black", x = 2, y = 7 });
        list.Add(new ChessInfo() { name = "b_queen", path = "chessType/queen_black", x = 3, y = 7 });
        list.Add(new ChessInfo() { name = "b_king", path = "chessType/king_black", x = 4, y = 7 });
        list.Add(new ChessInfo() { name = "b_bishop", path = "chessType/bishop_black", x = 5, y = 7 });
        list.Add(new ChessInfo() { name = "b_knight", path = "chessType/knight_black", x = 6, y = 7 });
        list.Add(new ChessInfo() { name = "b_rook", path = "chessType/rook_black", x = 7, y = 7 });

        foreach (var item in list)
        {
            GameObject GO = Instantiate(Resources.Load<GameObject>(item.path));
            GO.transform.parent = transform.GetChild(1);
            GO.name = item.name;
            Chess p = GO.GetComponent<Chess>();
            p.setInfo(item);
            listChess.Add(p);
            _cell[item.x, item.y].setCurrentChess(p);
        }
    }

}
