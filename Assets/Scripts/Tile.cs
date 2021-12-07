using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
棋盘脚本
*/

public class Tile : MonoBehaviour
{
    //是否可以到达
    public bool canArrive;
    //是否可以攻击到
    public bool canAttack;

    public GameObject attackRange;
    public GameObject moveRange;

    //是否已经搜索过了
    public bool isExplored;
    //当前节点通过哪一个父节点搜索而来的
    public Tile exploreForm;

    public int tilePlayerNumber;

    public void Awake()
    {
        tilePlayerNumber = 999;
    }

    public void Start()
    {
        SetPlayNumber(true);
    }
    //鼠标点击事件
    private void OnMouseDown()
    {
        UIManager.instance.CloseInfo();
        //移动
        if (GameManager.instance.selectPiece.GetComponent<PieceAction>().hasMove == false)
        {
            if (canArrive)
            {
                GameManager.instance.selectPiece.GetComponent<PieceAction>().Move(gameObject);
            }
        }
        else
        {
            Debug.Log("您已经移动过了!");
        }
    }

    //确定该区块由哪个单位控制
    public void SetPlayNumber(bool _control)
    {
        PieceAction[] AllPiece = FindObjectsOfType<PieceAction>();
        foreach (var piece in AllPiece)
        {
            if (piece.gameObject.transform.position.x == transform.position.x && piece.gameObject.transform.position.y == transform.position.y)
            {
                if (_control)
                {
                    tilePlayerNumber = piece.playerNumber;
                }
                else
                {
                    tilePlayerNumber = 999;
                }
            }
        }
    }

}
