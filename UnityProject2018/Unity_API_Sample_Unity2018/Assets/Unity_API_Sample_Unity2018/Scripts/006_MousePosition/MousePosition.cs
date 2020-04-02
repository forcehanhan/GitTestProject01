//目的： 实时打印鼠标的坐标位置
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MousePosition : MonoBehaviour
{
    new public Camera camera;
    /// <summary>
    /// <param name="guiText">将文本显示到GUI</param>
    /// </summary>
    GUIText guiText;

    GUILayer guiLayer;
    /// <summary>
    /// <param name="mousePos">鼠标的坐标<param>
    /// </summary>
    Vector2 mousePos;

    void Start() {
        guiLayer = camera.gameObject.AddComponent<GUILayer>();
        guiText = camera.gameObject.AddComponent<GUIText>();
        guiText.fontSize = 30;
        guiText.color = Color.red;
    }

    void Update() {
        // 实时获取鼠标的坐标
        mousePos = Input.mousePosition;
        guiText.text = "鼠标坐标： " + mousePos;


    }
}
