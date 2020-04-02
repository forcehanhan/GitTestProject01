/*
 * 时间：2020年3月21日21:15:01
 * 题目：查找游戏对象Find()
 * 实现目的：查找父级游戏对象
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _027_Transform_Parent_Find : MonoBehaviour
{
    private Transform tran;
    void Start()
    {
        //一、查找父级
        //
        tran = GameObject.Find("Cube5").transform.parent.parent.parent.parent;//父级Cube1
        Debug.Log("一、找到的游戏对象的父级是：====>" + tran.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
