using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
���ӽű�
*/
public class PieceAction : MonoBehaviour
{
    public string post;//���ӵ�ְ��
    public int playerNumber;//�����ж����

    public bool Ranged;//�Ƿ�߱�Զ�̹�������
    public bool canAttack;//�Ƿ���Թ���
    public bool canMove;//�Ƿ�����ƶ�
    public bool canCasting;//�Ƿ����ʩ��
    public bool canUseActiveSkill;//�Ƿ����ʹ����������

    public bool hasAttack;//�Ƿ��Ѿ�����
    public bool hasMove;//�Ƿ��Ѿ��ƶ�
    public bool hasCasting;//�Ƿ��Ѿ�ʩ��
    public bool hasUseActiveSkill;//�Ƿ��Ѿ�ʹ����������
    public bool attackable;//�Ƿ��ܱ�ѡ��ΪĿ��
    
    public float actionTime;//�ж�ʱ��
    //�����߼��ʱ����⵽�����Collider����������������
    //Physics2D.queriesStartInColliders = false;


    //��ɫ�ƶ�
    public void Move(GameObject endpoint)
    {
        GameManager.instance.CloseMoveRange();

        PathFinding pf = FindObjectOfType<PathFinding>();
        StartCoroutine(FindTile(pf.GetPath(endpoint)));

        hasMove = true;
    }
    //����·���ƶ�
    IEnumerator FindTile(List<Tile> pathTile)
    {
        foreach (Tile p in pathTile)
        {
            transform.position = p.transform.position + new Vector3(0, 0, -0.1f);
            yield return new WaitForSeconds(0.5f);//ÿ0.5��ִ��һ��
        }
    }

    //��ɫ����
    public void Attack(float _attack)
    {

    }

    //���ѡ���¼�
    private void OnMouseDown()
    {
        UIManager.instance.ShowInfo(GameManager.instance.selectPiece.GetComponent<PieceDate>());
        GameManager.instance.ShowAttackRange(gameObject);
        GameManager.instance.ShowMoveRange(gameObject);
        //�����ѡ�е���������Ϊ��ǰѡ������
        GameManager.instance.selectPiece = gameObject;
        if (GameManager.instance.selectPiece.GetComponent<PieceAction>().hasAttack)
        {
            Debug.Log("���Ѿ����й������ˣ�");
            //����Ҫ��ʾ�������������
        }
        else if (GameManager.instance.selectPiece.GetComponent<PieceAction>().hasAttack == false && gameObject != GameManager.instance.selectPiece)
        {
            Attack(GameManager.instance.selectPiece.GetComponent<PieceDate>().attack);
        }
    }

    //�����Ƿ���Թ���
    public void SetAttackAble(bool _canAttack)
    {
        PieceAction[] p = FindObjectsOfType<PieceAction>();
        foreach (var canAttack in p)
        {
            if ((Mathf.Abs(GameManager.instance.selectPiece.transform.position.x - canAttack.transform.position.x) +
            Mathf.Abs(GameManager.instance.selectPiece.transform.position.y - canAttack.transform.position.y)) <=
            GameManager.instance.selectPiece.GetComponent<PieceDate>().attackRange)
            {
                canAttack.attackable = _canAttack;
            }
        }
    }


}

