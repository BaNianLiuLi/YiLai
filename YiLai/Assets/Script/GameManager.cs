using UnityEngine;

/*
��Ϸ������
*/

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public

    void Awake()
    {
        OneScripts();

    }

    /// <summary>
    /// �ű�������
    /// </summary>
    private void OneScripts()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// �����ʼ��
    /// </summary>
    private void InitRelic()
    {


    }
}



