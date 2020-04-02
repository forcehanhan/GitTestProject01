/*
 * 时间：2020年3月22日23:52:59
 * 题目：
 * 实现目的：时间间隔
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryOneSecond : MonoBehaviour
{
    void Start() {

    }

    void Update() {

    }

    //每个1秒,闪烁一次
    private void OnGUI() {
        GUILayout.Label("【Time.time % 2】= " + (Time.time % 2).ToString());
        if (Time.time % 2 < 1)
        {
            GUILayout.Button("我这个按钮每秒创建一次");
        }
    }
}
