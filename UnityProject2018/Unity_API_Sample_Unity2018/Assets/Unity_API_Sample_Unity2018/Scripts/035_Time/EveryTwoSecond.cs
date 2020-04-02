/*
 * 时间：2020年3月22日23:52:54
 * 题目：
 * Time.time:
 * 表示从游戏开发到现在的时间，会随着游戏的暂停而停止计算。
 * 
 * Time.timeScale:
 * 1：timeScale不会影响Update和LateUpdate的执行速度
 * 2：FixedUpdate是根据时间来的，所以timeScale只会影响FixedUpdate的速度
 * 
 * 实现目的：时间间隔
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryTwoSecond : MonoBehaviour
{
    public float rateTime = 2f;//频率
    private float nextTime = 0f;//下一次时间
    private int count = 10;//计数

    void Start() {

    }

    //当timeScale==0时,FixedUpdate不再执行
    private void FixedUpdate() {
        if (Time.timeScale == 0)
        {
            Debug.Log("timeScale = " + Time.timeScale);
            Debug.Log("FixedUpdate函数还会执行吗?");
            Debug.Log("当然不会!");
        }
    }

    //当timeScale==0时,Update不受影响
    void Update() {
        if (Time.timeScale == 0)
        {
            Debug.Log("timeScale= " + Time.timeScale);
            Debug.Log("Update函数还会执行吗?");
            Debug.Log("当然会!");
        }
    }

    //每隔2秒
    private void OnGUI() {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + rateTime;
            count -= 2;
            Debug.Log(count);
        }
        GUILayout.Button("每隔2秒：" + count.ToString());

        //如果倒计时<=0,则停止计时
        if (count <= 0)
        {
            count = 0;
/*            nextTime = 0f;
            rateTime = 0f;*/
            Time.timeScale = 0;
        }
    }
}
