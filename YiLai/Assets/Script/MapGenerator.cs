using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using UnityEngine;
using Object = UnityEngine.Object;


/*
 * ��ͼ������
*/

namespace YiLaiDemo.Map
{
    public class MapGenerator : MonoBehaviour
    {
        string prefabPath = "Prefabs/Map/Cube"; //Ԥ�����·��
        float distance = 1.0f; //�ؿ�֮��ľ���
        string mapCreateMode = "wave"; //��ͼ�����ɷ�ʽ
        GameObject parent; //��ͼ���ؽű����ڵ�����Ϊ������
        Vector3 startVector = new Vector3(0, 0, 0); //��ͼ���ɵ����ĵ�
        int mapH = 15; //��ͼ�Ŀ��
        int mapV = 9; //��ͼ�ĸ߶�
        public GameObject mapStart;


        public List<GameObject> Maps;
        GameObject mapPrefab;
        private Dictionary<int, Transform> mapCreateOrder;
        public void Awake()
        {
            InitMapDate();
        }

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
            mapPrefab = Resources.Load<GameObject>(prefabPath);
            CreateMap();
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
        private Dictionary<int, Transform> CreatMap_Wave()
        {
            //������ʱ��
            List<Point> coordinates = new List<Point>();
            //1.����ʼ�ص��λ��ת��Ϊ���겢���뵽����
            Point point = new Point((int) (startVector.x / distance), (int) (startVector.z / distance));
            coordinates.Add(point);
            //������
            foreach (var c in coordinates)
            {
                if (c.X<14)
                {//��������
                    
                }
            }
            
            
            // //����һ����ʱ�������Դ�������
            // GameObject t;
            // //���ɳ�ʼ�ؿ�
            // var v = Instantiate(mapPrefab, vector, new Quaternion(0, 0, 0, 0));
            // //��ȡ��ʼ�ؿ�����
            // BlockData v_m = v.GetComponent<BlockData>();
            // //����ʼ�ؿ�������ͼ�б�
            // Maps.Add(v);
            // //���ó�ʼ�ؿ������
            // v_m.h = (int) (v.transform.position.x / distance);
            // v_m.v = (int) (v.transform.position.z / distance);
            //
            // List<GameObject> _child = new List<GameObject>();
            // //���ؿ�����������ʱ��ֹͣ����
            // while (Maps.Count < 135)
            // {
            //     //�ж��Ƿ��������Ϸ��ؿ�
            //     if (v_m.h < 14 && v_m.v > 0 && v_m.v < 9)
            //     {
            //         //�Ƿ񳬳��߽�
            //         var v_m_c = v_m.GetComponent<BlockData>().child;
            //         foreach (var c in v_m_c)
            //         {
            //             //��ȡ���б��еĵؿ�����
            //             var c_m = c.GetComponent<BlockData>();
            //             if (c_m.h == v_m.h + 1 && c_m.v == v_m.v)
            //             {
            //                 //�Ƿ��Ѿ����ɹ���
            //                 //���ɳ�ʼ�ؿ��Ϸ��ĵؿ�1
            //                 t = Instantiate(mapPrefab, vector + new Vector3(distance, 0, 0), new Quaternion(0, 0, 0, 0));
            //                 //���ؿ�1�ĸ��ڵ���Ϊ��ʼ�ؿ�
            //                 var t_s = t.GetComponent<BlockData>();
            //                 t_s.parent = v;
            //                 //���ؿ�1��ˮƽλ������Ϊx/distance
            //                 t_s.h = (int) (t.transform.position.x / distance);
            //                 //��ֱλ������Ϊy/distance
            //                 t_s.v = (int) (t.transform.position.z / distance);
            //                 //�������ɵĵؿ��������ڵ�����б���
            //                 v_m_c.Add(t);
            //                 //ͬʱ��ӽ���ͼ�б���
            //                 Maps.Add(t);
            //                 //��ӵ���ʱ�б���
            //                 _child.Add(t);
            //             }
            //         }
            //     }
            //

            //}
            return null;
        }

        //���ɵؿ�
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