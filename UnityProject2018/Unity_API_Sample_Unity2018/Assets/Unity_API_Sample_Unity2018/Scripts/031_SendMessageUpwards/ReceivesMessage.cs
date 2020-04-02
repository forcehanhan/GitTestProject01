/*
 * 时间：
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivesMessage : MonoBehaviour
{
    public void Fun1() {
        Debug.Log("====>我是方法Fun1()");
        transform.GetComponent<Renderer>().material.color = Color.clear;//清除材质颜色
    }

    public void Fun2() {
        Debug.Log("====>我是方法Fun2()");
        transform.GetComponent<Renderer>().material.color = Color.green;//改变材质颜色
    }
}
