using UnityEngine;

/*
游戏管理器
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
    /// 脚本单例化
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
    /// 遗物初始化
    /// </summary>
    private void InitRelic()
    {


    }
}



