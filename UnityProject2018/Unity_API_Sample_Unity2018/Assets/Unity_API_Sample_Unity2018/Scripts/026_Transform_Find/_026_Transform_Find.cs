/*
 * 时间：2020年3月21日21:13:29
 * 题目：查找游戏对象Find()
 * 实现目的：掌握Find()的查找方法
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _026_Transform_Find : MonoBehaviour
{
    private Transform trans;
    private GameObject obj;

    void Start()
    {
        trans = transform.GetComponent<Transform>();

        //一、transform.Find(string name)：支持查找子层级的游戏对象
        trans = transform.Find("Cube1");//正确,可以查找到
        Debug.Log("一、找到的游戏对象名称是：====>" + trans.name);

        //二、transform.Find(string name)：支持查找子层级的游戏对象
        trans  = transform.Find("Cube1/Cube2");//正确,可以查找到
        Debug.Log("二、找到的游戏对象名称是：====>" + trans.name);

        //三、transform.Find(string name)：支持查找子层级的游戏对象
        trans = transform.Find("Cube1/Cube2/Cube3/Cube4/Cube5");//正确,可以查找到
        Debug.Log("三、找到的游戏对象名称是：====>" + trans.name);

        //四、transform.Find(string name)：支持查找子层级的游戏对象
        // 注意:FindChild()已被弃用了!!!
        trans = transform.FindChild("Cube1/Cube2");//正确,可以查找到
        Debug.Log("四、找到的游戏对象名称是：====>" + trans.name);//UnityEngine.Transform
        Debug.Log("四、找到的游戏对象类型是：====>" + trans);

        //五、
        obj = transform.Find("Cube6").gameObject;
        Debug.Log("五、找到的游戏对象名称是：====>" + obj.name);
        Debug.Log("五、找到的游戏对象类型是：====>" + obj);//UnityEngine.GameObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
