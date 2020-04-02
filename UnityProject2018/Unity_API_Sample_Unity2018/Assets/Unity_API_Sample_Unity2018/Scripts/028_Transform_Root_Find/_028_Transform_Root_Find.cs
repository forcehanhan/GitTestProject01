/*
 * 时间：2020年3月21日21:59:50
 * 题目：TransformRoot_Find
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _028_Transform_Root_Find : MonoBehaviour
{
    private Transform tran;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        //一、查找根级别root
        tran = GameObject.Find("Cube6").transform.root;
        Debug.Log("=====>一、找到的游戏对象是:" + tran.name);//=====>一、找到的游戏对象是:FindRoot

        //二、查找根级别root
        obj = GameObject.Find("Cube6").transform.root.gameObject;
        Debug.Log("=====>二、找到的游戏对象是:" + obj.name);//=====>二、找到的游戏对象是:FindRoot
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
