using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
����Ȩ�޿�����
��ȡ�������ӵ���ΪȨ�ޣ�����������Ϸ�Ľ��ж�����
*/

public class TurnControl : MonoBehaviour
{
    //��ȡ�������ӵ��ж���
    List<PieceAction> PieceActions = new List<PieceAction>();

    private void Start()
    {
        InitPieceAction();
    }

    /// <summary>
    /// ��ʼ�����ӿ�����
    /// </summary>
    public void InitPieceAction()
    {
        foreach (var piece in GameManager.instance.Pieces)
        {
            PieceActions.Add(piece.GetComponent<PieceAction>());
        }
    }

   /// <summary>
   /// �������ӵ��ж��غ�
   /// </summary>
   /// <param name="piece">��Ҫ�����ж��غϵ�����</param>
    public void StartPieceAction(PieceAction _piece)
    {
        _piece.canAttack = true;
        _piece.canMove = true;
        _piece.canCasting = true;
        _piece.canUseActiveSkill = true;
    }

    /// <summary>
    /// �ر����ӵ��ж��غ�
    /// </summary>
    /// <param name="_piece">��Ҫ�ر��ж��غϵ�����</param>
    public void ClosePieceAction(PieceAction _piece)
    {
        _piece.canAttack = false;
        _piece.canMove = false;
        _piece.canCasting = false;
        _piece.canUseActiveSkill = false;
    }

}
