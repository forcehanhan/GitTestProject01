/*
 * 时间：2020年3月21日22:46:44
 * 题目：BroadcastMessage():向下发送消息,在某个节点以下的所有子层级的游戏对象,都会接收BroadcastMessage()发送的消息.
 * 实现目的：掌握BroadcastMessage()
 * 操作步骤：
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _030_BroadcastMessage : MonoBehaviour
{
    private GameObject obj1;
    private GameObject obj2;
    private Transform tran;

    private float totalTime = 5f;//倒计时5s
    public  Text timeText;//Text文本,用来显示倒计时

    void Start() {
        //查找到Text文本,并加载其组件
        timeText = GameObject.Find("Text").GetComponent<Text>();

        //一、向下发送消息，调用"Fun1()方法
        //查找节点:BroadcastMessage1,是为了向该节点以下(子层级)发送消息.
        obj1 = GameObject.Find("BroadcastMessage1");
        obj1.BroadcastMessage("Fun1");

        //一、向下发送消息，调用"Fun1()方法
        //查找节点:Cube2,是为了向该节点以下(子层级)发送消息.
        obj2 = GameObject.Find("Cube2   ");
        obj2.BroadcastMessage("Fun3");
    }

    
    void Update() {
        //二、向下发送消息，调用"Fun2()方法,在这里我使用了倒计时,是为了区分Fun1和Fun2的差别.
        //如果倒计时totalTime > 0,则对其做-=的操作
        if (totalTime > 0.0f)
        {
        totalTime -= Time.deltaTime;
        Debug.Log(totalTime);
        }

        //将倒计时显示在Text文本上.
        timeText.text = string.Format("{0:F2}秒钟后,将游戏对象颜色改变.", totalTime);

        //如果倒计时totalTime < 0,则调用Fun2()方法
        if (totalTime < 0.0f)
        {
            tran = GameObject.Find("BroadcastMessage1").transform;
            tran.BroadcastMessage("Fun2");
            totalTime = 0.0f;//重置倒计时
        }
    }
}
