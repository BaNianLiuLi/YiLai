using System.Collections.Generic;
using System.Collections;
using UnityEngine;


/*
 * ��ͼ������
*/

namespace YiLaiDemo.Map
{
    public class MapGenerator : MonoBehaviour
    {
        string prefabPath = "Assets/Prefrom/Map/Cube.prefab";//Ԥ�����·��
        float distance = 1.0f;//�ؿ�֮��ľ���
        string mapCreateMode = "wave"; //��ͼ�����ɷ�ʽ
        GameObject parent;//��ͼ���ؽű����ڵ�����Ϊ������
        Vector3 vector = new Vector3(0, 0, 0);//��ͼ���ɵ����ĵ�
        int mapH = 15;//��ͼ�Ŀ��
        int mapV = 9;//��ͼ�ĸ߶�

        Object mapPrefab;
        private Dictionary<int, Map_Config> MapNumber;

        /// <summary>
        /// ��ʼ����ͼ����
        /// </summary>
        private void InitMapDate()
        {
            LoadMapPrefab();
        }

        /// <summary>
        /// ���ص�ͼԤ����
        /// </summary>
        private void LoadMapPrefab()
        {
            mapPrefab = Resources.Load(prefabPath);
        }

        /// <summary>
        /// �������ɷ�ʽ���ɵ�ͼ
        /// </summary>
        private void CreateMap()
        {
            switch (mapCreateMode)
            {
                case "wave":
                    CreatMap_Wave();
                    break;

            }
        }

        /// <summary>
        /// ������ʽ�����ɵ�ͼ
        /// </summary>
        private void CreatMap_Wave()
        {
            int mapNumber = 0;
            GameObject maps;//�����ж��ؿ��Ƿ�����

            int numH = 3;
            int numV = 6;
            while (mapNumber < 135)
            {
                for (int i = 0; i < 4; i++)
                {

                }
                StartCoroutine(CreatMap(vector, "Up"));
            }
        }

        //���ɵؿ�
        IEnumerator CreatMap(Vector3 vector, string direction)
        {
            switch (direction)
            {
                case "Up":
                    Instantiate(mapPrefab, vector + new Vector3(0, distance, 0), new Quaternion(0, 0, 0, 0));
                    break;
                case "Right":
                    Instantiate(mapPrefab, vector + new Vector3(distance, 0, 0), new Quaternion(0, 0, 0, 0));
                    break;
                case "Down":
                    Instantiate(mapPrefab, vector + new Vector3(0, -distance, 0), new Quaternion(0, 0, 0, 0));
                    break;
                case "Left":
                    Instantiate(mapPrefab, vector + new Vector3(-distance, 0, 0), new Quaternion(0, 0, 0, 0));
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

