/*
 实现：摄像机视图——透视和正交视图的切换
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    new Camera camera;      // 声明摄像机变量
    GUIStyle guiStyle;  // 声明GUIStyle变量，为了设置字体风格
    public Texture2D tex2D;// 给Label字体加一张背景
    Color color = Color.red;// 字体颜色
    float len = 5.0f;   // 接收摄像机的orthographic和fieldOfView的值
    void Start() {
        Debug.Log("时间");
        Debug.Log(Time.deltaTime * 10.0f);
        //初始化数据
        camera = this.GetComponent<Camera>();
        camera.orthographic = true;
        // 设置GUIStyle风格
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 18;
        guiStyle.normal.textColor = color;
        //也可以这样给颜色赋值：
        //guiStyle.normal.textColor = new Color(1,0,0);
        guiStyle.normal.background = tex2D;
    }
    //使用GUI进行响应事件，需要使用GUI行为函数OnGUI()
    public void OnGUI() {
        //
        GUI.Label(new Rect(10.0f, 20.0f, 300.0f, 40.0f), "实现正交视图和透视视图的切换：", guiStyle);

        // 实现 正交 和 透视 的切换
        if (GUI.Button(new Rect(10.0f, 70.0f, 150.0f, 40.0f), "正交视图"))
        {
            camera.orthographic = true;
            len = 5.0f;
        }
        if (GUI.Button(new Rect(10.0f, 120.0f, 150.0f, 40.0f), "透视视图"))
        {
            camera.orthographic = false;
            len = 60.0f;
        }

        // 调节滑条
        if (camera.orthographic)
        {
            len = GUI.HorizontalSlider(new Rect(300.0f, 20.0f, 150.0f, 40.0f), len, 1.0f, 20.0f);
            camera.orthographicSize = len;
        }
        else
        {
            len = GUI.HorizontalSlider(new Rect(300.0f, 20.0f, 150.0f, 40.0f), len, 1.0f, 179.0f);
            camera.fieldOfView = len;
        }

        // 输出调节滑条的数值
        GUI.Label(new Rect(455.0f, 15.0f, 150.0f, 40.0f), len.ToString());
    }

    void Update() {

    }
}
