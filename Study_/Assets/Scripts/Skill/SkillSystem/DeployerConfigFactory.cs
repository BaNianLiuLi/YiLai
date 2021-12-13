using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///释放器配置工厂:提供创建释放器各种算法对象的功能
///作用：将对象的创建和使用分离
/// <summary>
public class DeployerConfigFactory : MonoBehaviour
{
    public static IAttackeSelector CreatAttackeSelector(SkillDate _Date)
    {
        //skillDate.attackType
        //选区对象命名规则
        //ARPDemo.Skill. + 枚举名 +AttackType
        //例如扇形选区Sector  :  ARPDemo.Skill.Sector.AttackType
        string className = string.Format("ARPDemo.Skill.{0}AttackType",_Date.attackType);
        return CreateObject<IAttackeSelector>(className);
    }

    public static IAttackeSelector[] CreatAttackeSelectors(SkillDate _Date)
    {
        IAttackeSelector[] impacts = new IAttackeSelector[_Date.impactType.Length];
        //影响命名规范
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

        //下面这行代码只用于测试，让它不报错用的，不适用！
        return null;
    }
}
