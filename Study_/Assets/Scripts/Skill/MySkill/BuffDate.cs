using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
Buff数据
*/
[Serializable]
public class BuffDate
{
    //执行顺序
    public int executeOrder;

    //Buff名称
    public string BuffName;

    //Buff效果以及具体的数值
    public Dictionary<string, int> BuffEffectList;

    //持续回合
    public int Duration;

}
