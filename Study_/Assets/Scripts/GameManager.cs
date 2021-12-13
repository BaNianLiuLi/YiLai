using System.Collections.Generic;
using UnityEngine;

/*
游戏管理脚本
*/

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] Tiles;
    public GameObject[] Pieces;

    public List<GameObject> moveList;
    public List<GameObject> attackList;

    //选中的棋子
    public GameObject selectPiece;
    //选中的棋盘
    public GameObject selectPiecePoint;
    //当前回合行动棋子
    public GameObject actionPiece;

    public bool inAttack;
    public bool inMove;
    public bool getTime;
    public bool TurnOpen;

    public float time;

    public List<PieceAction> PiecesAction;
    public List<PieceDate> PiecesNumber;
    //public int MainPlayer;

    private void Start()
    {
        getTime = true;
        PieceOrder();

        PieceAction[] piecesaction = FindObjectsOfType<PieceAction>();
        PieceDate[] piecesnumber = FindObjectsOfType<PieceDate>();
        foreach (var p in piecesaction)
        {
            PiecesAction.Add(p);
        }

        foreach (var p in piecesnumber)
        {
            PiecesNumber.Add(p);
        }

        Tiles = GameObject.FindGameObjectsWithTag("Tile");
    }
    private void Update()
    {
        if (getTime)
        {
            time += Time.deltaTime;
        }

        TimeArrive();
        //鼠标右键时，关闭所有范围显示
        if (Input.GetMouseButton(1))
        {
            CloseAttackRange();
            CloseMoveRange();

        }
    }

    //时间检测，如果到时间则开启回合
    private void TimeArrive()
    {
        foreach (PieceAction t in PiecesAction)
        {
            if (time >= t.actionTime && TurnOpen == false)
            {
                selectPiece = t.gameObject;
                actionPiece = t.gameObject;
                TurnStart();
            }
        }
    }
    //显示移动范围
    public void ShowMoveRange(GameObject _this)
    {
        //Debug.Log("已经显示移动范围了!");
        CloseMoveRange();
        foreach (var tile in Tiles)
        {
            float moverange = _this.GetComponent<PieceDate>().motivation;
            if ((Mathf.Abs(_this.transform.position.x - tile.transform.position.x) +
                Mathf.Abs(_this.transform.position.y - tile.transform.position.y))
                <= moverange && tile.GetComponent<Tile>().tilePlayerNumber == 999)
            {
                tile.GetComponent<Tile>().canArrive = true;
                tile.GetComponent<Tile>().moveRange.SetActive(true);
                moveList.Add(tile);
            }
        }
    }
    //关闭移动范围显示
    public void CloseMoveRange()
    {
        foreach (var movelist in moveList)
        {
            movelist.GetComponent<Tile>().canArrive = false;
            movelist.GetComponent<Tile>().moveRange.SetActive(false);
        }
        moveList.Clear();
    }
    //显示攻击范围
    public void ShowAttackRange(GameObject _this)
    {
        CloseAttackRange();
        foreach (var tile in Tiles)
        {
            float attackrange = _this.GetComponent<PieceDate>().attackRange;
            if ((Mathf.Abs(_this.transform.position.x - tile.transform.position.x) + Mathf.Abs(_this.transform.position.y
                - tile.transform.position.y)) <= attackrange && tile.GetComponent<Tile>().tilePlayerNumber != _this.GetComponent<PieceAction>().playerNumber)
            {
                tile.GetComponent<Tile>().canAttack = true;
                tile.GetComponent<Tile>().attackRange.SetActive(true);
                attackList.Add(tile);
                if (tile.GetComponent<Tile>().tilePlayerNumber != 999)
                {
                    tile.GetComponent<Tile>().canAttack = true;
                }
            }
        }
    }
    //关闭攻击范围显示
    public void CloseAttackRange()
    {
        foreach (var attacklist in attackList)
        {
            attacklist.GetComponent<Tile>().canAttack = false;
            attacklist.GetComponent<Tile>().attackRange.SetActive(false);
        }
        attackList.Clear();

    }

    //回合开始
    public void TurnStart()
    {
        TurnOpen = true;
        getTime = false;
        CloseMoveRange();
        CloseAttackRange();

        ShowMoveRange(actionPiece);
        ShowAttackRange(actionPiece);

        inMove = true;
        inAttack = true;

        foreach (var tile in Tiles)
        {
            if (tile.gameObject.transform.position.x == actionPiece.gameObject.transform.position.x
                && tile.gameObject.transform.position.y == actionPiece.gameObject.transform.position.y)
            {
                selectPiecePoint = tile;
            }
        }
        
    }
    //回合结束
    public void TurnEnd()
    {
        TurnOpen = false;
        CloseMoveRange();
        CloseAttackRange();

        inAttack = false;
        inMove = false;

        //PiecesAction.Remove(selectPiece.GetComponent<PieceAction>());

        getTime = true;

        if (PiecesAction.Count == 0)
        {
            Debug.Log("已经重置回合了");
            time = 0;
            PieceAction[] piece = FindObjectsOfType<PieceAction>();
            foreach (var p in piece)
            {
                PiecesAction.Add(p);
            }

            PieceOrder();
        }
    }

    //棋子行动顺序计算
    private void PieceOrder()
    {
        PieceDate[] all_p = FindObjectsOfType<PieceDate>();
        foreach (var p in all_p)
        {
            if (!p.GetComponent<PieceAction>().hasMove)
            {
                p.GetComponent<PieceAction>().actionTime = 100.0f / p.speed;
            }
        }

    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

}
