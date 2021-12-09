using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
棋子脚本
*/
public class PieceAction : MonoBehaviour
{
    public string post;//棋子的职介
    public int playerNumber;//棋子行动编号

    public bool Ranged;//是否具备远程攻击能力
    public bool canAttack;//是否可以攻击
    public bool canMove;//是否可以移动
    public bool canCasting;//是否可以施法
    public bool canUseActiveSkill;//是否可以使用主动技能

    public bool hasAttack;//是否已经攻击
    public bool hasMove;//是否已经移动
    public bool hasCasting;//是否已经施法
    public bool hasUseActiveSkill;//是否已经使用主动技能
    public bool attackable;//是否能被选中为目标
    
    public float actionTime;//行动时间
    //将射线检测时，检测到自身的Collider后，无视自身继续检测
    //Physics2D.queriesStartInColliders = false;


    //角色移动
    public void Move(GameObject endpoint)
    {
        GameManager.instance.CloseMoveRange();

        PathFinding pf = FindObjectOfType<PathFinding>();
        StartCoroutine(FindTile(pf.GetPath(endpoint)));

        hasMove = true;
    }
    //根据路径移动
    IEnumerator FindTile(List<Tile> pathTile)
    {
        foreach (Tile p in pathTile)
        {
            transform.position = p.transform.position + new Vector3(0, 0, -0.1f);
            yield return new WaitForSeconds(0.5f);//每0.5秒执行一次
        }
    }

    //角色攻击
    public void Attack(float _attack)
    {

    }

    //鼠标选中事件
    private void OnMouseDown()
    {
        UIManager.instance.ShowInfo(GameManager.instance.selectPiece.GetComponent<PieceDate>());
        GameManager.instance.ShowAttackRange(gameObject);
        GameManager.instance.ShowMoveRange(gameObject);
        //将鼠标选中的棋子设置为当前选中棋子
        GameManager.instance.selectPiece = gameObject;
        if (GameManager.instance.selectPiece.GetComponent<PieceAction>().hasAttack)
        {
            Debug.Log("您已经进行过攻击了！");
            //这里要显示攻击对象的属性
        }
        else if (GameManager.instance.selectPiece.GetComponent<PieceAction>().hasAttack == false && gameObject != GameManager.instance.selectPiece)
        {
            Attack(GameManager.instance.selectPiece.GetComponent<PieceDate>().attack);
        }
    }

    //设置是否可以攻击
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

