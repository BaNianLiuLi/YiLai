using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
���ӵ���ֵ
*/

public class PieceDate : MonoBehaviour
{
    public float hp;//����ֵ
    public float mp;//����ֵ
    public float attack;//������
    public float defense;//������
    public float Armor;//����
    public float resistance;//����
    public float speed;//�ٶ�
    public float morale;//ʿ��
    public float motivation;//�ж���
    public float attackRange;//������Χ
    public float HPmax;//��λ��HP����
    public float MPmax;//��λ��MP����
    public float moralemax = 10;//��λ��ʿ������
    public float motivationMax;//�ж�������
    public List<BuffDate> buffList = new List<BuffDate>(16);//��λ���ڵ�BUFF��������
    public string pot;//���ӵ�ְ��
    public bool canSpell;//�Ƿ����ʩ��
}
