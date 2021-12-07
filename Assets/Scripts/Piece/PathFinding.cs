using System.Collections.Generic;
using UnityEngine;

/*
Ѱ·�ű�
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

    //����Ѱ·�㷨
    private void ResetPathFinding(GameObject end_point)
    {
        startPoint = GameManager.instance.selectPiecePoint;
        //����ʼ�ص�����ӿ���Ȩ����
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

    //�����������ӽڵ�
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

    //��ʼ�����е���Ƭ���Ҵ洢���ֵ���
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
            //�����ֵ����Ƿ������������
            if (Tiles.ContainsKey(tempTile))
            {

            }
            else
            {
                Tiles.Add(tempTile, Tile);
            }
        }
    }

    //BFSѰ·����
    private void BFS()
    {
        quequ.Enqueue(startPoint.GetComponent<Tile>());
        while (quequ.Count > 0 && isRunning)
        {
            //�������еĵ�һ��Ԫ���Ƴ�����
            searchcenter = quequ.Dequeue();
            StopIfsearchEnd();

            ExploreAround();

            searchcenter.isExplored = true;
        }
    }

    //����Ƿ�Ӧ��ֹͣѰ·
    private void StopIfsearchEnd()
    {
        if (searchcenter.gameObject == endPoint)
        {
            isRunning = false;
        }
    }

    //���·��
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
