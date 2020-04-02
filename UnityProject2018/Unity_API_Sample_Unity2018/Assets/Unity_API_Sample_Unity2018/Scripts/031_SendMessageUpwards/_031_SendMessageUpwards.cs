/*
 * 时间：2020年3月22日00:31:13
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _031_SendMessageUpwards : MonoBehaviour
{
    private GameObject obj;
    private Transform tran;

    private float totalTime = 5f;//倒计时5s
    public Text timeText;//Text文本,用来显示倒计时

    void Start() {
        //查找到Text文本,并加载其组件
        timeText = GameObject.Find("Text").GetComponent<Text>();

        //一、向上(所有父级)发送消息，调用"Fun1()方法
        //查找节点:SendMessageUpwards,是为了向该节点以上(所有父级)发送消息.
        obj = GameObject.Find("Cube5");//一定要查找到脚本挂载点的游戏对象的名称
        obj.SendMessageUpwards("Fun1");
    }


    void Update() {
        //二、向上(所有父级)发送消息，调用"Fun2()方法,在这里我使用了倒计时,是为了区分Fun1和Fun2的差别.
        //如果倒计时totalTime > 0,则对其做-=的操作
        if (totalTime > 0.0f)
        {
            totalTime -= Time.deltaTime;
            Debug.Log(totalTime);
        }

        //将倒计时显示在Text文本上.
        timeText.text = string.Format("{0:F2}秒钟后,游戏对象颜色变为绿色.", totalTime);

        //如果倒计时totalTime < 0,则调用Fun2()方法
        if (totalTime < 0.0f)
        {
            tran = GameObject.Find("Cube5").transform;
            tran.SendMessageUpwards("Fun2");
            totalTime = 0.0f;//重置倒计时
        }
    }
}
