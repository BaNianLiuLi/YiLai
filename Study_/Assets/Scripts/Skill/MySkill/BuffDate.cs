using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
Buff����
*/
[Serializable]
public class BuffDate
{
    //ִ��˳��
    public int executeOrder;

    //Buff����
    public string BuffName;

    //BuffЧ���Լ��������ֵ
    public Dictionary<string, int> BuffEffectList;

    //�����غ�
    public int Duration;

}
