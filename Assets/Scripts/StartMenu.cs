using UnityEngine;
using UnityEngine.SceneManagement;

/*
开始界面
*/

public class StartMenu : MonoBehaviour
{

    private bool levels;
    [SerializeField] private GameObject gLevels;
    //加载新游戏
    public void OnClicNewGame()
    {
        SceneManager.LoadScene(1);
    }

    //载入存档
    public void OnclicLoadGame()
    {
        levels = !levels;
        gLevels.SetActive(levels);
    }

    //存档选择后，载入
    //public void OnclicLoadGameTwo()
    //{ 

    //}


    //退出游戏
    public void OnclicQuite()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                 Application.Quit();
#endif
    }
}
