using System.Collections.Generic;
using System.IO;
using UnityEngine;
/*
资源管理器
*/
public class ResourceManager
{
    private static Dictionary<string, string> configMap;

    //作用：初始化类的静态成员
    //时机：类被加载时执行一次
    static ResourceManager()
    {
        //加载文件
        string fileContent = GetConfigFile("ConfigMap.txt");

        // 解析文件（string -- > Dictionary<string,string>）
        BuildMap(fileContent);
    }


    private static void BuildMap(string fileContent)
    {
        configMap = new Dictionary<string, string>();
        //文件名= 路径\r\n文件名 = 路径
        using (StringReader reader = new StringReader(fileContent))
        {
            string line;
            //读取一行数据
            while ((line = reader.ReadLine()) != null)
            {
                //解析数据
                string[] keyValue = line.Split('=');

                //文件名 keyValue[0],路径 keyValue[1]
                configMap.Add(keyValue[0], keyValue[1]);
            }



            //读取一行数据
            // string line = reader.ReadLine();
            //如果数据不为空/判断不为空
            // while (line != null)
            // {
            //用等号拆分
            //  string[] keyValue = line.Split('=');
            //文件名 keyValue[0],路径 keyValue[1]
            // configMap.Add(keyValue[0], keyValue[1]);

            //继续读取文件
            //  line = reader.ReadLine();
            //   }
            //当程序退出using代码块，自动调用reader.Dispose();
        }

    }

    public static string GetConfigFile(string filename)
    {

        //ConfigMao.txt

        //为了解决可能存在的移动端无法获取资源的问题

        //如果在编译器下
        //if (Application.platform == RuntimePlatform.WindowsEditor)
        //string url = "file://"+Application.streamingAssetsPath+"/ConfigMap.txt";
        string url;
#if UNITY_EDITOR || UNITY_STANDALONE
        //                      datePath 会直接定位到 streamingAssetsPath
        url = "file://" + Application.dataPath + "/StreamingAssets/" + filename;
#elif UNITY_IPHONE
//如果在ios下
         url = "file://" + Application.dataPath + "/Raw/"+filename;
#elif UNITY_ANDROID
        //如果在android下
        url = "jar:file://" + Application.dataPath + "!/assets/"+filename;
#endif
       WWW www = new WWW(url);
        //UnityWebRequest
       
        while (true)
        {
            //判断，资源是否加载完成，如果加载成功才返回
            if (www.isDone)
            {
                return www.text;
            }
        }
    }

    public static T Load<T>(string prefabName) where T : Object
    {
        //prefabeName --> prefabPath
        string prefabPath = configMap[prefabName];
        return Resources.Load<T>("");
    }
}
