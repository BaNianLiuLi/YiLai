using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using UnityEngine;
using Object = UnityEngine.Object;


/*
 * 地图生成器
*/

namespace YiLaiDemo.Map
{
    public class MapGenerator : MonoBehaviour
    {
        string prefabPath = "Prefabs/Map/Cube"; //预制体的路径
        float distance = 1.0f; //地块之间的距离
        string mapCreateMode = "wave"; //地图的生成方式
        GameObject parent; //地图主控脚本所在的物体为父物体
        Vector3 startVector = new Vector3(0, 0, 0); //地图生成的中心点
        int mapH = 15; //地图的宽度
        int mapV = 9; //地图的高度
        public GameObject mapStart;


        public List<GameObject> Maps;
        GameObject mapPrefab;
        private Dictionary<int, Transform> mapCreateOrder;
        public void Awake()
        {
            InitMapDate();
        }

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
            mapPrefab = Resources.Load<GameObject>(prefabPath);
            CreateMap();
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
        private Dictionary<int, Transform> CreatMap_Wave()
        {
            //定义临时表
            List<Point> coordinates = new List<Point>();
            //1.将初始地点的位置转化为坐标并加入到表中
            Point point = new Point((int) (startVector.x / distance), (int) (startVector.z / distance));
            coordinates.Add(point);
            //遍历表
            foreach (var c in coordinates)
            {
                if (c.X<14)
                {//可以生成
                    
                }
            }
            
            
            // //定义一个临时变量用以储存数据
            // GameObject t;
            // //生成初始地块
            // var v = Instantiate(mapPrefab, vector, new Quaternion(0, 0, 0, 0));
            // //获取初始地块的组件
            // BlockData v_m = v.GetComponent<BlockData>();
            // //将初始地块加入进地图列表
            // Maps.Add(v);
            // //设置初始地块的坐标
            // v_m.h = (int) (v.transform.position.x / distance);
            // v_m.v = (int) (v.transform.position.z / distance);
            //
            // List<GameObject> _child = new List<GameObject>();
            // //当地块的数量满足的时候，停止生成
            // while (Maps.Count < 135)
            // {
            //     //判断是否能生成上方地块
            //     if (v_m.h < 14 && v_m.v > 0 && v_m.v < 9)
            //     {
            //         //是否超出边界
            //         var v_m_c = v_m.GetComponent<BlockData>().child;
            //         foreach (var c in v_m_c)
            //         {
            //             //获取子列表中的地块引用
            //             var c_m = c.GetComponent<BlockData>();
            //             if (c_m.h == v_m.h + 1 && c_m.v == v_m.v)
            //             {
            //                 //是否已经生成过了
            //                 //生成初始地块上方的地块1
            //                 t = Instantiate(mapPrefab, vector + new Vector3(distance, 0, 0), new Quaternion(0, 0, 0, 0));
            //                 //将地块1的父节点设为初始地块
            //                 var t_s = t.GetComponent<BlockData>();
            //                 t_s.parent = v;
            //                 //将地块1的水平位置设置为x/distance
            //                 t_s.h = (int) (t.transform.position.x / distance);
            //                 //竖直位置设置为y/distance
            //                 t_s.v = (int) (t.transform.position.z / distance);
            //                 //将新生成的地块加入进父节点的子列表中
            //                 v_m_c.Add(t);
            //                 //同时添加进地图列表中
            //                 Maps.Add(t);
            //                 //添加到临时列表中
            //                 _child.Add(t);
            //             }
            //         }
            //     }
            //

            //}
            return null;
        }

        //生成地块
        IEnumerator CreatMap(Vector3 vector, string direction)
        {
            // switch (direction)
            // {
            //     case "Up":
            //         Instantiate(mapPrefab, vector + new Vector3(0, distance, 0), new Quaternion(0, 0, 0, 0));
            //         break;
            //     case "Right":
            //         Instantiate(mapPrefab, vector + new Vector3(distance, 0, 0), new Quaternion(0, 0, 0, 0));
            //         break;
            //     case "Down":
            //         Instantiate(mapPrefab, vector + new Vector3(0, -distance, 0), new Quaternion(0, 0, 0, 0));
            //         break;
            //     case "Left":
            //         Instantiate(mapPrefab, vector + new Vector3(-distance, 0, 0), new Quaternion(0, 0, 0, 0));
            //         break;
            // }
            yield return new WaitForSeconds(0.1f);
        }
    }
}