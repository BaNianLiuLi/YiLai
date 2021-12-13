using System.IO;
using UnityEditor;
using System.Windows;

/*
1.�������ࣺ�̳���Editor�ֻ࣬��Ҫ��unity��������ִ�еĴ���
2.�˵���  ���� MenuItem("����  :����������Ҫ�ڱ������в����˵���ť�ķ���
3.AssetDatabase ֻ�����ڱ༭���в�����Դ����ع���
4.SteamingAssets������������Ŀ¼֮һ ����Ŀ¼�е��ļ����ᱻѹ�����ʺ����ƶ��˶�ȡ��Դ����PC�˿���д�룩��
    ��  Application.persisteneDatePath  ·������������ʱ���ж�д������Unity�ļ�Ŀ¼����װ����ʱ��������
*/

public class GenerateResConfig : Editor
{
    
    [MenuItem("Tools/Rsources/Generate ResConfig File")]
    public static void Generate()
    {
        //��Դ���ݻ���
        //1.���� �ض�Ŀ¼�µ��ض��ļ�  ����˴��ľ���Assets/Resources�µ�prefab���͵��ļ�
        //����Ϊ��1.��������2.����Ѱ��
        string[] resFiles = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Resources" });
        //�˴�resFiles�д��������Դ��GUID
        for (int i = 0; i < resFiles.Length; i++)
        {
            //2.������Ӧ��ϵ
            //�˴���Ҫ��GUIDת����·��
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
            //ͨ��Path.GetFileNameWithoutExtension��������ȡ·���е��ļ�����
            string fileName = Path.GetFileNameWithoutExtension(resFiles[i]);
            //��ȡ�ļ�·��
            string filePath = resFiles[i].Replace("Assets/Resources", string.Empty).Replace(".prefab",string.Empty);
            resFiles[i] = fileName + "=" + filePath;
        }

        //д���ļ�,���ļ�д��SteamingAssets
        File.WriteAllLines("Assets/SteamingAssets/ConfigMap.txt",resFiles);
        //ˢ��
        AssetDatabase.Refresh();
    }
}
