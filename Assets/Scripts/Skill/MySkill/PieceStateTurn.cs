using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/*
Buff状态更新器
*/

public class PieceStateTurn : MonoBehaviour
{
    public static PieceStateTurn instance;

    [Header("Buff信息文本")]
    public TextAsset BuffDateText;

    //需要结算的棋子
    public List<PieceDate> pieceDates = new List<PieceDate>();

    private void Start()
    {
        StartPieceStateTurn();

        PieceStateMange(GameManager.instance.PiecesNumber, 1);

        Debug.Log("问题在哪");
    }

    //初始化棋子状态变更脚本
    public void StartPieceStateTurn()
    {
        foreach (var piece in GameManager.instance.Pieces)
        {
            pieceDates.Add(piece.GetComponent<PieceDate>());
        }
    }

    /// <summary>
    /// 获取并且根据阶段结算需要结算的棋子Buff
    /// </summary>
    /// <param name="_piecedates">需要结算的棋子</param>
    /// <param name="_stage">需要结算的阶段</param>
    public void PieceStateMange(List<PieceDate> _piecedates, int _stage)
    {
        //需要结算的Buff列表
        List<BuffDate> result = new List<BuffDate>();
        
        //获取需要结算的Buff
        for (int i = 0; i < _piecedates.Count; i++)

        {
            switch (_stage)
            {
                //回合开始时结算
                case 1:
                    foreach (var buff in _piecedates[i].buffList)
                    {
                        if (buff.executeOrder == 1)
                        {
                            result.Add(buff);
                        }
                        //结算掉获取的Buff
                        SettlementBuff(result);
                        //清空需要结算的Buff数据表
                        result.Clear();
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// Buff结算
    /// </summary>
    /// <param name="_buffs">已经获取的需要结算的Buff</param>
    private void SettlementBuff(List<BuffDate> _buffs)
    {
        Type t = Type.GetType("BuffEffect");
        var instance = Activator.CreateInstance(t);
        foreach (var buff in _buffs)
        {
            //foreach (var effect in buff.BuffEffectList)
            //{
            //    MethodInfo m = t.GetMethod(effect.Key);
            //    System.Object[] o = new System.Object[2];
            //    o[0] = this;
            //    o[1] = effect.Value;
            //    System.Object ret = m.Invoke(instance, o);
            //}
        }
    }

    //单例化该脚本，顺道初始化
    void Awake()
    {
        BuffDateText = Resources.Load<TextAsset>("SkillDateStore/buffDateText");

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }




    //获取BUFF的数据
    //public void GetBuffDate()
    //{
    //    buffDate.Clear();

    //    var txtDate = BuffDateText.text.Split('\n');
    //    for (int i = 0; i < txtDate.Length; i++)
    //    {
    //        if (!txtDate[0].Equals('#'))
    //        {
    //            var sectionDate = txtDate[i].Split(';');
    //            buffDate.Add(sectionDate[0], sectionDate);
    //        }
    //    }
    //}
}
