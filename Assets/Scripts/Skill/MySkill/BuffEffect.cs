using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Buff效果储存脚本
*/

public class BuffEffect
{
    //生命值增加
    public void HpUp( PieceDate _object,int _number)
    {
        _object.hp += _number;
    }
}
