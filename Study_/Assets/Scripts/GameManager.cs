using System.Collections.Generic;
using UnityEngine;

/*
��Ϸ����ű�
*/

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] Tiles;
    public GameObject[] Pieces;

    public List<GameObject> moveList;
    public List<GameObject> attackList;

    //ѡ�е�����
    public GameObject selectPiece;
    //ѡ�е�����
    public GameObject selectPiecePoint;
    //��ǰ�غ��ж�����
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
        //����Ҽ�ʱ���ر����з�Χ��ʾ
        if (Input.GetMouseButton(1))
        {
            CloseAttackRange();
            CloseMoveRange();

        }
    }

    //ʱ���⣬�����ʱ�������غ�
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
    //��ʾ�ƶ���Χ
    public void ShowMoveRange(GameObject _this)
    {
        //Debug.Log("�Ѿ���ʾ�ƶ���Χ��!");
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
    //�ر��ƶ���Χ��ʾ
    public void CloseMoveRange()
    {
        foreach (var movelist in moveList)
        {
            movelist.GetComponent<Tile>().canArrive = false;
            movelist.GetComponent<Tile>().moveRange.SetActive(false);
        }
        moveList.Clear();
    }
    //��ʾ������Χ
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
    //�رչ�����Χ��ʾ
    public void CloseAttackRange()
    {
        foreach (var attacklist in attackList)
        {
            attacklist.GetComponent<Tile>().canAttack = false;
            attacklist.GetComponent<Tile>().attackRange.SetActive(false);
        }
        attackList.Clear();

    }

    //�غϿ�ʼ
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
    //�غϽ���
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
            Debug.Log("�Ѿ����ûغ���");
            time = 0;
            PieceAction[] piece = FindObjectsOfType<PieceAction>();
            foreach (var p in piece)
            {
                PiecesAction.Add(p);
            }

            PieceOrder();
        }
    }

    //�����ж�˳�����
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
