/*
 * 时间：2020年3月21日21:13:23
 * 题目：SendMessage()发送消息
 * 实现目的：掌握SendMessage()
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _029_SendMessage : MonoBehaviour
{
    public GameObject cube1;//先要找到cube,在Inspector面板上给变量cube1赋值
    private GameObject cube2;//先要使用Find()方法找到cube2

    void Start() {
        //一、SendMessage(string methodName, SendMessageOptions options);
        // 1、该函数主要是用法调用其他游戏对象身上持有的方法.
        // 2、SendMessageOptions.DontRequireReceiver：如果消息没有被任何一个组件处理，则不会打印一个错误。
        // 3、SendMessageOptions.RequireReceiver：如果消息没有被任何一个组件处理，则不会打印一个错误。
        cube1.SendMessage("Fun1",SendMessageOptions.RequireReceiver);
        cube1.SendMessage("Fun2", SendMessageOptions.RequireReceiver);//因为没有该方法,所以会报错:SendMessage Fun2 has no receiver!

        //二、先查找,再发送消息
        cube2 = GameObject.Find("Cube2");
        Debug.Log("=====>二、找到的游戏对象是:" + cube2.name);
        cube2.SendMessage("Fun2", SendMessageOptions.RequireReceiver);
    }

    // Update is called once per frame
    void Update() {

    }
}
