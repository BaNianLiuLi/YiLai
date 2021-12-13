using System.IO;
using UnityEditor;
using System.Windows;

/*
1.编译器类：继承自Editor类，只需要在unity编译器中执行的代码
2.菜单项  特性 MenuItem("“）  :用于修饰需要在编译器中产生菜单按钮的方法
3.AssetDatabase 只适用于编辑器中操作资源的相关功能
4.SteamingAssets：编译器特殊目录之一 ，该目录中的文件不会被压缩，适合在移动端读取资源（在PC端可以写入）。
    该  Application.persisteneDatePath  路径可以在运行时进行读写操作。Unity文件目录（安装程序时产生）。
*/

public class GenerateResConfig : Editor
{
    
    [MenuItem("Tools/Rsources/Generate ResConfig File")]
    public static void Generate()
    {
        //资源数据基础
        //1.查找 特定目录下的特定文件  比如此处的就是Assets/Resources下的prefab类型的文件
        //参数为：1.过滤器，2.在哪寻找
        string[] resFiles = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Resources" });
        //此处resFiles中储存的是资源的GUID
        for (int i = 0; i < resFiles.Length; i++)
        {
            //2.建立对应关系
            //此处需要将GUID转换成路径
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
            //通过Path.GetFileNameWithoutExtension方法，获取路径中的文件名称
            string fileName = Path.GetFileNameWithoutExtension(resFiles[i]);
            //获取文件路径
            string filePath = resFiles[i].Replace("Assets/Resources", string.Empty).Replace(".prefab",string.Empty);
            resFiles[i] = fileName + "=" + filePath;
        }

        //写入文件,将文件写进SteamingAssets
        File.WriteAllLines("Assets/SteamingAssets/ConfigMap.txt",resFiles);
        //刷新
        AssetDatabase.Refresh();
    }
}
