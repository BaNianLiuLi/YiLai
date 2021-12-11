using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
�������ؽű�
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
            //�첽���س���
            AsyncOperation operation = SceneManager.LoadSceneAsync(viewName);

            //�����ڳ���׼�������������������
            operation.allowSceneActivation = true;

            //���������
            while (!operation.isDone)
            {
                loadSceneSlider.value = operation.progress;

                loadSceneText.text = loadSceneSlider.value * 100 + "%";

                //����������������ɺ�������ת������ȡ�����´���ע�ͣ��ó�����������Ժ���Ҫ�������ⰴ������ת����
                //if (loadSceneSlider.value >= 0.9f)
                //{
                //    loadSceneSlider.value = 1.0f;
                //    loadSceneText.text = "�밴�����ⰴ��";
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

