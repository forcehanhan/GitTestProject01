/*
 * 时间：2020年3月14日13:55:39
 * 题目：不使用异步函数Invoke实现异步
 * 实现目的：异步函数
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _013_01_Invoke : MonoBehaviour
{
    private float timer = 3.0f;//初始化时间间隔
    private int i = 0;//计数器
    private GameObject obj;
    void Start() {
        Debug.Log("每过3秒创建一个Capsule");
    }

    void Update() {
        //每过3秒,就创建一个游戏对象
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            timer = 3.0f;
            i++;
            Debug.Log("timer= " + timer + " , 第" + i + "次");
        }

    }
}
