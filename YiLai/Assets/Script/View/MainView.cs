using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
开始（主界面）配置脚本
*/

namespace YiLaiDemo
{
    public class MainView : MonoBehaviour
    {
        ViewBaseCtr viewBaseCtr = FindObjectOfType<ViewBaseCtr>();
        public GameObject btn_GameStart;
        public GameObject btn_LoadFile;
        public GameObject btn_ExitGame;
        public GameObject btn_GameSet;
        public GameObject btn_StoryEntry;
        //初始化主界面

        public void Awake()
        {
            InitMainView();
        }
        public void InitMainView()
        {
            Button gameStart = btn_GameStart.GetComponent<Button>();
            Button loadFile = btn_LoadFile.GetComponent<Button>();
            Button exitGame = btn_ExitGame.GetComponent<Button>();
            Button gameSet = btn_GameSet.GetComponent<Button>();
            Button stroyEntry = btn_StoryEntry.GetComponent<Button>();

            gameStart.onClick.AddListener(delegate { this.TP_GameStart(); });
        }

        public void TP_GameStart()
        {
            viewBaseCtr.LoadWaitView("GameView");
        }

        public void TP_LoadFile()
        {
            viewBaseCtr.LoadWaitView("LoadFileView");
        }

        public void ExitGame()
        {
            
        }

        public void GameSet()
        {
            viewBaseCtr.LoadWaitView("GameSetView");
        }

        public void TP_StoryEntry()
        {
            viewBaseCtr.LoadWaitView("StoryEntryView");
        }
    }
}

