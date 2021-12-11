using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
界面主控脚本
*/

namespace YiLaiDemo.View
{
    public class ViewBaseCtr : MonoBehaviour
    {
        public GameObject loadScreen;
        public Slider loadSceneSlider;
        public Text loadSceneText;

        public void LoadWaitView(string viewName)
        {
            StartCoroutine("LoadLevle",viewName);
        }

        IEnumerable LoadLevle(string viewName)
        {
            //异步加载场景
            AsyncOperation operation = SceneManager.LoadSceneAsync(viewName);

            //允许在场景准备就绪后立即激活场景。
            operation.allowSceneActivation = true;

            //变更进度条
            while (!operation.isDone)
            {
                loadSceneSlider.value = operation.progress;

                loadSceneText.text = loadSceneSlider.value * 100 + "%";

                //当不允许场景加载完成后立刻跳转，可以取消以下代码注释，让场景加载完成以后需要按下任意按键，跳转场景
                //if (loadSceneSlider.value >= 0.9f)
                //{
                //    loadSceneSlider.value = 1.0f;
                //    loadSceneText.text = "请按下任意按键";
                //    if (Input.anyKeyDown)
                //    {
                //        operation.allowSceneActivation = true;
                //    }
                //}
                yield return null;
            }
        }
    }
}

