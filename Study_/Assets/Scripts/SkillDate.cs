using System;
using UnityEngine;

/*
技能数据
*/
[Serializable]
public class SkillDate
{
    //技能ID
    public int skillID;
    //技能名称
    public string skillName;
    //技能描述
    public string description;
    //技能冷却
    public int coolTime;
    //冷却剩余
    public int coolRemain;
    //技能释放类型
    public string skillGoType;
    //技能持续时间
    public int durationTime;
    //技能消耗
    public int cost;
    //技能范围
    public int attackDistance;
    //攻击目标的类型（友军，敌人，全体）
    public int attackTragetTags;
    //技能效果
    public string[] impactType;
    //伤害比率
    //public float atkRatio;
    //技能所属
    [HideInInspector] public GameObject owner;
    //技能预制件名称
    public string prefbaName;
    //预制件对象
    [HideInInspector] public GameObject skillPrefba;
    //动画名称
    //public string animationName;
    //受击特效名称
    //public string hitFxName;
    //技能等级
    public int level;
    //技能伤害类型(1为物理，2为魔法)
    public int attackType;
    //技能执行阶段
    //1回合开始，-1为行动结束，2为移动前，-2移动后，3为攻击前，-3为攻击后，4为施法前，-4为施法后。
    public int executeStage;
}


