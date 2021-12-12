using System.Collections.Generic;
using System.Collections;
using UnityEngine;


/*
 * 地图生成器
*/

namespace YiLaiDemo.Map
{
    public class MapGenerator : MonoBehaviour
    {
        string prefabPath = "Assets/Prefrom/Map/Cube.prefab";//预制体的路径
        float distance = 1.0f;//地块之间的距离
        string mapCreateMode = "wave"; //地图的生成方式
        GameObject parent;//地图主控脚本所在的物体为父物体
        Vector3 vector = new Vector3(0, 0, 0);//地图生成的中心点
        int mapH = 15;//地图的宽度
        int mapV = 9;//地图的高度

        Object mapPrefab;
        private Dictionary<int, Map_Config> MapNumber;

        /// <summary>
        /// 初始化地图数据
        /// </summary>
        private void InitMapDate()
        {
            LoadMapPrefab();
        }

        /// <summary>
        /// 加载地图预制体
        /// </summary>
        private void LoadMapPrefab()
        {
            mapPrefab = Resources.Load(prefabPath);
        }

        /// <summary>
        /// 根据生成方式生成地图
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
        /// “波浪式”生成地图
        /// </summary>
        private void CreatMap_Wave()
        {
            int mapNumber = 0;
            GameObject maps;//用于判定地块是否生成

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

        //生成地块
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

