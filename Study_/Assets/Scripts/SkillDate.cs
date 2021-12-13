using System;
using UnityEngine;

/*
��������
*/
[Serializable]
public class SkillDate
{
    //����ID
    public int skillID;
    //��������
    public string skillName;
    //��������
    public string description;
    //������ȴ
    public int coolTime;
    //��ȴʣ��
    public int coolRemain;
    //�����ͷ�����
    public string skillGoType;
    //���ܳ���ʱ��
    public int durationTime;
    //��������
    public int cost;
    //���ܷ�Χ
    public int attackDistance;
    //����Ŀ������ͣ��Ѿ������ˣ�ȫ�壩
    public int attackTragetTags;
    //����Ч��
    public string[] impactType;
    //�˺�����
    //public float atkRatio;
    //��������
    [HideInInspector] public GameObject owner;
    //����Ԥ�Ƽ�����
    public string prefbaName;
    //Ԥ�Ƽ�����
    [HideInInspector] public GameObject skillPrefba;
    //��������
    //public string animationName;
    //�ܻ���Ч����
    //public string hitFxName;
    //���ܵȼ�
    public int level;
    //�����˺�����(1Ϊ����2Ϊħ��)
    public int attackType;
    //����ִ�н׶�
    //1�غϿ�ʼ��-1Ϊ�ж�������2Ϊ�ƶ�ǰ��-2�ƶ���3Ϊ����ǰ��-3Ϊ������4Ϊʩ��ǰ��-4Ϊʩ����
    public int executeStage;
}


