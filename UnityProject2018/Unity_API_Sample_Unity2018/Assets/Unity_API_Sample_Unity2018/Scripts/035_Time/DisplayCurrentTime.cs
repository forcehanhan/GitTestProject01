/*
 * 时间：
 * 题目：Unity 获取系统当前时间，并格式化显示。
 * 通过“System.DateTime”获取系统当前的时间，然后通过格式化把获得的时间格式化显示出来
 * 实现目的：
 * 操作步骤：
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrentTime : MonoBehaviour
{
    private Text CurrrentTimeText;
    private int hour;//小时
    private int minute;//分钟
    private int second;//秒
    private int year;//年
    private int month;//月
    private int day;//天

    // Use this for initialization
    void Start() {
        CurrrentTimeText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update() {
        //获取当前时间
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;
        year = DateTime.Now.Year;
        month = DateTime.Now.Month;
        day = DateTime.Now.Day;

        //格式化显示当前时间
        CurrrentTimeText.text = string.Format("{0:D2}:{1:D2}:{2:D2} " + "{3:D4}/{4:D2}/{5:D2}", hour, minute, second, year, month, day);

#if UNITY_EDITOR
        Debug.Log("W now " + System.DateTime.Now);     //当前时间（年月日时分秒）
        Debug.Log("W utc " + System.DateTime.UtcNow);  //当前时间（年月日时分秒）
#endif
    }
}

