/*
 * 时间：
 * 题目：
 * 实现目的：熟悉OnGUI、GUILayout
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _009_GUILayout : MonoBehaviour
{
    public GameObject cube;
    private Renderer renderer;
    private Color newColor;
    void Start()
    {
        //设定确定的颜色
        //newColor = new Color(1, 0, 0);

        //设定不确定的颜色:随机颜色
        newColor = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        cube.GetComponent<Renderer>().material.color =newColor;
    }

    
    void Update()
    {
        
    }

    private void OnGUI() {
        //1,设置GUILayout,不带长宽参数
        if (GUILayout.Button("Red"))
        {
            cube.GetComponent<Renderer>().material.color = Color.red;
        }

        //2,设置GUILayout,带长宽参数
        if (GUILayout.Button("Green", GUILayout.Width(150f), GUILayout.Height(30f)))
        {
            cube.GetComponent<Renderer>().material.color = Color.green;
        }

        //3,设置GUILayout,分步设置
        GUILayout.BeginArea(new Rect(0/*距离左边屏幕的宽度*/, 70/*距离上边屏幕的宽度*/, 150/*自身长度*/, 100/*自身高度*/));
        bool isClik = GUILayout.Button("Black");
        GUILayout.EndArea();//这一步不能少
        if (isClik)
        {
            cube.GetComponent<Renderer>().material.color = Color.black;
        }

    }
}
