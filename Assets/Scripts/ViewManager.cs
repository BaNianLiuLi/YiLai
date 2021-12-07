using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
视野控制脚本
*/

public class ViewManager : MonoBehaviour
{
    Camera camera;
    readonly private float maxView = 70;
    readonly private float minView = 30;
    public void Start()
    {
        camera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        //鼠标滚轮往后滑动
        if  (Input.GetAxis("Mouse ScrollWheel")<0)
        {
            if (camera.fieldOfView <= maxView)
            {
                camera.fieldOfView += 10 * 50 * Time.deltaTime;
            }
            if (camera.fieldOfView >= maxView)
            {
                camera.fieldOfView = maxView;
            }
        }

        //鼠标滚轮往前滑动
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (camera.fieldOfView >= minView)
            {
                camera.fieldOfView -= 10 * 50 * Time.deltaTime;
            }
            if (camera.fieldOfView <= minView)
            {
                camera.fieldOfView = minView;
            }
        }
    }
}
