/*
 * 时间：
 * 题目：
 * 实现目的：改变颜色,等待SendMassage()函数的调用.
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _021_ChangeColor : MonoBehaviour
{
    Color color;
    private void Start() {
        {
            color = GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
    void ChangeColor() {
        color = GetComponent<Renderer>().material.color = Color.green;
    }

    void ToBlue(Color myColor) {
        color = GetComponent<Renderer>().material.color = myColor;
    }
}
