using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
棋子的数值
*/

public class PieceDate : MonoBehaviour
{
    public float hp;//生命值
    public float mp;//法力值
    public float attack;//攻击力
    public float defense;//防御力
    public float Armor;//护甲
    public float resistance;//抗性
    public float speed;//速度
    public float morale;//士气
    public float motivation;//行动力
    public float attackRange;//攻击范围
    public float HPmax;//单位的HP上限
    public float MPmax;//单位的MP上限
    public float moralemax = 10;//单位的士气上限
    public float motivationMax;//行动力上限
    public List<BuffDate> buffList = new List<BuffDate>(16);//单位存在的BUFF数量上限
    public string pot;//棋子的职介
    public bool canSpell;//是否可以施法
}
