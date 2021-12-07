using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/*
Buff״̬������
*/

public class PieceStateTurn : MonoBehaviour
{
    public static PieceStateTurn instance;

    [Header("Buff��Ϣ�ı�")]
    public TextAsset BuffDateText;

    //��Ҫ���������
    public List<PieceDate> pieceDates = new List<PieceDate>();

    private void Start()
    {
        StartPieceStateTurn();

        PieceStateMange(GameManager.instance.PiecesNumber, 1);

        Debug.Log("��������");
    }

    //��ʼ������״̬����ű�
    public void StartPieceStateTurn()
    {
        foreach (var piece in GameManager.instance.Pieces)
        {
            pieceDates.Add(piece.GetComponent<PieceDate>());
        }
    }

    /// <summary>
    /// ��ȡ���Ҹ��ݽ׶ν�����Ҫ���������Buff
    /// </summary>
    /// <param name="_piecedates">��Ҫ���������</param>
    /// <param name="_stage">��Ҫ����Ľ׶�</param>
    public void PieceStateMange(List<PieceDate> _piecedates, int _stage)
    {
        //��Ҫ�����Buff�б�
        List<BuffDate> result = new List<BuffDate>();
        
        //��ȡ��Ҫ�����Buff
        for (int i = 0; i < _piecedates.Count; i++)

        {
            switch (_stage)
            {
                //�غϿ�ʼʱ����
                case 1:
                    foreach (var buff in _piecedates[i].buffList)
                    {
                        if (buff.executeOrder == 1)
                        {
                            result.Add(buff);
                        }
                        //�������ȡ��Buff
                        SettlementBuff(result);
                        //�����Ҫ�����Buff���ݱ�
                        result.Clear();
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// Buff����
    /// </summary>
    /// <param name="_buffs">�Ѿ���ȡ����Ҫ�����Buff</param>
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

    //�������ýű���˳����ʼ��
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




    //��ȡBUFF������
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
