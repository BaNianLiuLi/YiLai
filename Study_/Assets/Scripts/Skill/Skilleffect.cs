using UnityEngine;

/*
技能效果
*/

public class Skilleffect 
{
    /// <summary>
    /// 击退
    /// </summary>
    /// <param name="_mainPiece">发动击退的单位</param>
    /// <param name="_secondlyPiece">被击退的单位</param>
    /// <param name="_distance">击退的距离</param>
    public void Repel(GameObject _mainPiece, GameObject _secondlyPiece, int _distance)
    {
        //Vector3 difference;  可以用作冲锋算法
        //difference = _secondlyPiece.transform.position - _mainPiece.transform.position;
        //_secondlyPiece.transform.position = new Vector2(_secondlyPiece.transform.position.x + difference.x,
        //                                                                                   _secondlyPiece.transform.position.y + difference.y);
        //Debug.Log(_secondlyPiece.transform.position);

        Vector2 point01, difference;
        GameObject objectTile = GameManager.instance.Tiles[0];
        float gap;

        difference = (_secondlyPiece.transform.position - _mainPiece.transform.position);
        difference.Normalize();

        difference *= _distance;

        point01 = new Vector2(_secondlyPiece.transform.position.x + difference.x,
                                          _secondlyPiece.transform.position.y + difference.y);

        gap = Mathf.Abs((point01.x - GameManager.instance.Tiles[0].transform.position.x) +
                   Mathf.Abs(point01.y - GameManager.instance.Tiles[0].transform.position.y));

        for (int i = 1; i < GameManager.instance.Tiles.Length; i++)
        {
            if ((Mathf.Abs(point01.x - GameManager.instance.Tiles[i].transform.position.x) +
                 Mathf.Abs(point01.y - GameManager.instance.Tiles[i].transform.position.y)) < gap)
            {
                gap = (Mathf.Abs(point01.x - GameManager.instance.Tiles[i].transform.position.x) +
                            Mathf.Abs(point01.y - GameManager.instance.Tiles[i].transform.position.y));
                objectTile = GameManager.instance.Tiles[i];
            }
        }

        difference = new Vector2(objectTile.transform.position.x, objectTile.transform.position.y);

        _secondlyPiece.transform.position = difference;
    }


    /// <summary>
    /// 伤害（生命值减少）
    /// </summary>
    /// <param name="_mainPiece">造成伤害的目标</param>
    /// <param name="_secondlyPiece">被伤害的目标</param>
    public void Demage(GameObject _mainPiece, GameObject _secondlyPiece)
    {
        float demage = _mainPiece.GetComponent<PieceDate>().attack;
        _secondlyPiece.GetComponent<PieceDate>().hp -= demage;
    }


}

