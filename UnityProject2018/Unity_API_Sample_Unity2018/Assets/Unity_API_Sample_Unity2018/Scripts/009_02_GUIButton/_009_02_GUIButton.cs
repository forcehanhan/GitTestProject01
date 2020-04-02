/*
 * 时间：
 * 题目：
 * 实现目的：会使用GUI.Button
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _009_02_GUIButton : MonoBehaviour
{
    public GameObject cube;
    public Texture2D tex2D;// 给Label字体加一张背景
    private GUIStyle guiStyle;  // 声明GUIStyle变量，为了设置字体风格
    private Color color = Color.red;// 字体颜色
    private float len = 5.0f;   // 接收摄像机的orthographic和fieldOfView的值
    void Start() {
        Debug.Log("时间");
        Debug.Log(Time.deltaTime * 10.0f);

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
        }
        if (GUI.Button(new Rect(10.0f, 120.0f, 150.0f, 40.0f), "透视视图"))
        {
        }

        // 调节滑条

            len = GUI.HorizontalSlider(new Rect(300.0f, 20.0f, 150.0f, 40.0f), len, 1.0f, 179.0f);

        // 输出调节滑条的数值
        GUI.Label(new Rect(455.0f, 15.0f, 150.0f, 40.0f), len.ToString());
    }
    void Update() {

    }
}

