using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///�ͷ������ù���:�ṩ�����ͷ��������㷨����Ĺ���
///���ã�������Ĵ�����ʹ�÷���
/// <summary>
public class DeployerConfigFactory : MonoBehaviour
{
    public static IAttackeSelector CreatAttackeSelector(SkillDate _Date)
    {
        //skillDate.attackType
        //ѡ��������������
        //ARPDemo.Skill. + ö���� +AttackType
        //��������ѡ��Sector  :  ARPDemo.Skill.Sector.AttackType
        string className = string.Format("ARPDemo.Skill.{0}AttackType",_Date.attackType);
        return CreateObject<IAttackeSelector>(className);
    }

    public static IAttackeSelector[] CreatAttackeSelectors(SkillDate _Date)
    {
        IAttackeSelector[] impacts = new IAttackeSelector[_Date.impactType.Length];
        //Ӱ�������淶
        for (int i = 0; i < _Date.impactType.Length; i++)
        {
            string classImpact = string.Format("ARPDemo.Skill.AttackType");
            impacts[i] = CreateObject<IAttackeSelector>(classImpact);
        }
        return impacts;
    }

    private static T CreateObject<T>(string className) where T : class
    {
        //Type type = Type.GetType(className);
        // return Activator.CreateInstance(type) as T;

        //�������д���ֻ���ڲ��ԣ������������õģ������ã�
        return null;
    }
}
