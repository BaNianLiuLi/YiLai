using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
���̽ű�
*/

public class Tile : MonoBehaviour
{
    //�Ƿ���Ե���
    public bool canArrive;
    //�Ƿ���Թ�����
    public bool canAttack;

    public GameObject attackRange;
    public GameObject moveRange;

    //�Ƿ��Ѿ���������
    public bool isExplored;
    //��ǰ�ڵ�ͨ����һ�����ڵ�����������
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
    //������¼�
    private void OnMouseDown()
    {
        UIManager.instance.CloseInfo();
        //�ƶ�
        if (GameManager.instance.selectPiece.GetComponent<PieceAction>().hasMove == false)
        {
            if (canArrive)
            {
                GameManager.instance.selectPiece.GetComponent<PieceAction>().Move(gameObject);
            }
        }
        else
        {
            Debug.Log("���Ѿ��ƶ�����!");
        }
    }

    //ȷ�����������ĸ���λ����
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
