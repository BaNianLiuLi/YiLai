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
        //��ȡ�����������ʵ��
        Type t = Type.GetType("Test1");

        //l������������ʵ��������һ������
        var instance = Activator.CreateInstance(t);

        //���ô�ŵ����ݳ�Ա����Ϣ��Ϊ���Ǹ�ֵ
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
