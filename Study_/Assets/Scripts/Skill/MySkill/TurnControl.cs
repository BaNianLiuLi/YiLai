using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
棋子权限控制器
获取所有棋子的行为权限，并且随着游戏的进行而更改
*/

public class TurnControl : MonoBehaviour
{
    //获取所有棋子的行动器
    List<PieceAction> PieceActions = new List<PieceAction>();

    private void Start()
    {
        InitPieceAction();
    }

    /// <summary>
    /// 初始化棋子控制器
    /// </summary>
    public void InitPieceAction()
    {
        foreach (var piece in GameManager.instance.Pieces)
        {
            PieceActions.Add(piece.GetComponent<PieceAction>());
        }
    }

   /// <summary>
   /// 开启棋子的行动回合
   /// </summary>
   /// <param name="piece">需要开启行动回合的棋子</param>
    public void StartPieceAction(PieceAction _piece)
    {
        _piece.canAttack = true;
        _piece.canMove = true;
        _piece.canCasting = true;
        _piece.canUseActiveSkill = true;
    }

    /// <summary>
    /// 关闭棋子的行动回合
    /// </summary>
    /// <param name="_piece">需要关闭行动回合的棋子</param>
    public void ClosePieceAction(PieceAction _piece)
    {
        _piece.canAttack = false;
        _piece.canMove = false;
        _piece.canCasting = false;
        _piece.canUseActiveSkill = false;
    }

}
