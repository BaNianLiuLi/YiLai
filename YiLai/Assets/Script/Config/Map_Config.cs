using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
地图配置
*/

public class Map_Config : MonoBehaviour
{
    public string mapParent;//地块的父节点(用于寻路算法)
    public bool canMove;//该地块是否可以移动
}
