/*
 * 时间：2020年2月25日13:27:51
 * 题目：
 * 实现目的：了解Rigidbody的用法,特别是Rigidbody组件的速度属性：velocity
 * 操作步骤：
 * 1、创建游戏对象Cube，命名为Cube1。
 * 2、Cube1添加上Rigidbody组件，将重力Use Gravity取消掉。
 * 3、将脚本挂在Cube1上。
 * 4、运行unity，按方向键移动游戏对象Cube1，使它移动。
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyComponent : MonoBehaviour
{
    private Rigidbody rb;
    private float tilt = 10.0f;//倾斜度值
    void Start() {
        //获取游戏对象身上的Rigidbody组件，只有获取了该组件，才能使用该组件的各种变量，属性，函数。
        rb = GetComponent<Rigidbody>();
    }

    void Update() {

    }
    private void FixedUpdate() {
        //1、获取虚拟轴。
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //打印出来看看h和v的值是不是在区间[-1，1]里。
        Debug.Log("h = " + h);
        Debug.Log("v = " + v);

        //2、调用velocity使游戏对象实现移动的功能。
        rb.velocity = new Vector3(h * 10, 0, v * 10);

        //3、实现游戏对象移动时，由于惯性而角度倾斜的效果。
        rb.rotation = Quaternion.Euler(v * tilt, 0, h * tilt);

        //4、提示：用Translate也能实现移动
        //transform.Translate(h, 0, v);

    }

    private void OnGUI() {
        GUI.Label(new Rect(10, 10, 300, 100), "利用Rigidbody组件的速度属性velocity实现移动，利用虚拟轴和欧拉角实现移动惯性倾斜");
        GUI.Label(new Rect(10, 150, 300, 100), "按W、A、S、D进行移动");
    }
}
