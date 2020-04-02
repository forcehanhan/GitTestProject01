/*
 * 时间：2020年3月14日21:57:38
 * 题目：协程Coroutine
 * 实现目的：掌握Coroutine
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _013_04_Coroutine : MonoBehaviour
{
    void Start() {
    }

    void Update() {
        //是游戏对象做"乒乓运动"
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            Mathf.PingPong(Time.time, 5f)
            );

   
    }//Update()
}
