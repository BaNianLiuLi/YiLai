using UnityEngine;
using UnityEngine.SceneManagement;

/*
��ʼ����
*/

public class StartMenu : MonoBehaviour
{

    private bool levels;
    [SerializeField] private GameObject gLevels;
    //��������Ϸ
    public void OnClicNewGame()
    {
        SceneManager.LoadScene(1);
    }

    //����浵
    public void OnclicLoadGame()
    {
        levels = !levels;
        gLevels.SetActive(levels);
    }

    //�浵ѡ�������
    //public void OnclicLoadGameTwo()
    //{ 

    //}


    //�˳���Ϸ
    public void OnclicQuite()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                 Application.Quit();
#endif
    }
}
