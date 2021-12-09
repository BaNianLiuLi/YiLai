using System.Collections.Generic;
using UnityEngine;

/*
寻路脚本
*/

public class PathFinding : MonoBehaviour
{
    [SerializeField] private GameObject startPoint, endPoint;

    [SerializeField] private Tile searchcenter;

    public Dictionary<Vector2, Tile> Tiles = new Dictionary<Vector2, Tile>();

    public List<Tile> path;

    readonly private Vector2[] direction =
     {
        Vector2.up, Vector2.right,Vector2.down,Vector2.left
    };
    public Queue<Tile> quequ = new Queue<Tile>();

    [SerializeField] private bool isRunning = true;


    public List<Tile> GetPath(GameObject end_point)
    {
        ResetPathFinding(end_point);
        LoadTiles();
        BFS();
        CreatPath();
        return path;
    }

    //重置寻路算法
    private void ResetPathFinding(GameObject end_point)
    {
        startPoint = GameManager.instance.selectPiecePoint;
        //将初始地点的棋子控制权重置
        startPoint.GetComponent<Tile>().tilePlayerNumber = 999;
        endPoint = end_point;
        searchcenter = null;
        path = new List<Tile>();
        Tile[] ti = FindObjectsOfType<Tile>();
        foreach (var t in ti)
        {
            t.isExplored = false;
            t.exploreForm = null;
        }
        quequ = new Queue<Tile>();
        isRunning = true;
    }

    //搜索附近的子节点
    private void ExploreAround()
    {
        if (isRunning == false)
        {
            return;
        }
        foreach (Vector2 d in direction)
        {
            try
            {
                Vector2 start = new Vector2(searchcenter.gameObject.transform.position.x, searchcenter.gameObject.transform.position.y);
                Vector2 exploreArounds = start + d;
                Tile neighbour = Tiles[exploreArounds];
                if (neighbour.isExplored || quequ.Contains(neighbour) && neighbour.tag != "Tile")
                {

                }
                else
                {
                    neighbour.exploreForm = searchcenter;
                    quequ.Enqueue(neighbour);
                }
            }
            catch
            {


            }
        }
    }

    //初始化所有的瓦片并且存储在字典中
    private void LoadTiles()
    {
        List<Tile> AllTile = new List<Tile>();
        foreach (GameObject T in GameManager.instance.Tiles)
        {
            if (T.gameObject.GetComponent<Tile>().tilePlayerNumber == 999)
            {
                AllTile.Add(T.gameObject.GetComponent<Tile>());
            }
        }
        foreach (var Tile in AllTile)
        {
            Vector2 tempTile = new Vector2(Tile.gameObject.transform.position.x, Tile.gameObject.transform.position.y);
            //查找字典中是否有这个“键”
            if (Tiles.ContainsKey(tempTile))
            {

            }
            else
            {
                Tiles.Add(tempTile, Tile);
            }
        }
    }

    //BFS寻路方法
    private void BFS()
    {
        quequ.Enqueue(startPoint.GetComponent<Tile>());
        while (quequ.Count > 0 && isRunning)
        {
            //将队列中的第一个元素移出队列
            searchcenter = quequ.Dequeue();
            StopIfsearchEnd();

            ExploreAround();

            searchcenter.isExplored = true;
        }
    }

    //检测是否应该停止寻路
    private void StopIfsearchEnd()
    {
        if (searchcenter.gameObject == endPoint)
        {
            isRunning = false;
        }
    }

    //输出路径
    public void CreatPath()
    {
        path.Add(endPoint.GetComponent<Tile>());
        Tile prePoint = endPoint.GetComponent<Tile>().exploreForm;
        while (prePoint != startPoint.GetComponent<Tile>())
        {
            path.Add(prePoint);
            prePoint = prePoint.exploreForm;
        }
        path.Add(startPoint.GetComponent<Tile>());
        path[0].GetComponent<Tile>().tilePlayerNumber = GameManager.instance.selectPiece.GetComponent<PieceAction>().playerNumber;
        path.Reverse();
    }

}
