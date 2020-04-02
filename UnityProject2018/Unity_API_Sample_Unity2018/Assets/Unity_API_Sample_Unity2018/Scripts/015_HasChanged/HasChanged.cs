/*
 * 时间：2020年3月24日22:51:15
 * 题目：hasChanged:用来检测游戏对象的变换信息是否发生了改变
 * 变换信息包括：位置、旋转、缩放。
 * 如果游戏对象的位置改变，则transform.hasChanged = true
 * 实现目的：
 * 操作步骤：
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasChanged : MonoBehaviour
{
    void Start() {
        //初始化坐标
        transform.position = Vector3.zero;

    }

    void Update() {
        transform.hasChanged = false;//标记。初始化=false
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);//缩放2倍
        if (transform.hasChanged)
        {
            Debug.Log("一、游戏对象的变换信息——缩放，改变了吗：" + transform.hasChanged);
        }


        transform.hasChanged = false;//重置
        //改变游戏对象的位置
        transform.position = new Vector3(1, 1, -2);
        if (transform.hasChanged)
        {
            Debug.Log("二、游戏对象的变换信息——位置，改变了吗：" + transform.hasChanged);
        }

        transform.hasChanged = false;//重置
        transform.Rotate(Vector3.up, Space.Self);
        if (transform.hasChanged)
        {
            Debug.Log("三、游戏对象的变换信息——旋转，改变了吗：" + transform.hasChanged);
        }

    }
}
