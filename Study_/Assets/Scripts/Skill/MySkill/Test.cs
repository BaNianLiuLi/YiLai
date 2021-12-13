using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
/*

*/
class Test1
{
    public int age;
    public string name;
    public bool marriage;

    public int Ddd(int a)
    {
        return a + a;
    }
}

public class Test : MonoBehaviour
{
    public int number = 1;
    public int number1 = 2;

    private void Start()
    {
        //获取类的描述对象实例
        Type t = Type.GetType("Test1");

        //l利用描述对象实例，构想一个对象
        var instance = Activator.CreateInstance(t);

        //利用存放的数据成员的信息，为它们赋值
        FieldInfo[] field = t.GetFields();

        FieldInfo name = t.GetField("name");

        name.SetValue(instance,"Jack");

        Debug.Log((instance as Test1).name);

        MethodInfo m = t.GetMethod("Ddd");

        System.Object[] o = new System.Object[1];
        o[0] = 3;

        System.Object ret = m.Invoke(instance, o);

        Debug.Log(ret);
    }
}
