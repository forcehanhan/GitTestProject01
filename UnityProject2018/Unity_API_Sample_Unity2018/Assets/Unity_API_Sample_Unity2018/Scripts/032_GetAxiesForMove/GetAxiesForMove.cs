/*
 * 时间：2020年3月23日10:28:16
 * 题目：获取虚拟轴
 * 实现目的：获取虚拟轴,实现简单的移动
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAxiesForMove : MonoBehaviour
{
    private float h;//用来接收水平虚拟轴的变化量
    private float v;//用来接收垂直虚拟轴的变化量
    private Vector3 movingVector3;//用来接收移动的、变化的向量
    private float speed;//移动的倍数

    private Transform trans;
    void Start() {
        h = 0f;
        v = 0f;
        trans = transform.GetComponent<Transform>();
        //trans.position = new Vector3(0, 2, 0);
        speed = 5.0f;
    }

    void Update() {
        h = Input.GetAxis("Horizontal");//获取水平的虚拟轴
        v = Input.GetAxis("Vertical");//获取垂直的虚拟轴
        //Debug.Log("h = " + h);
        //Debug.Log("v = " + v);
        //获取新的向量坐标
        movingVector3 = new Vector3(h * Time.deltaTime * speed, 0, v * Time.deltaTime * speed);
        //将新的向量坐标传递给Translate(),实现移动
        trans.Translate(movingVector3, Space.World);
        //角色的角度
        trans.rotation = Quaternion.Euler(trans.rotation.x, trans.rotation.y, trans.rotation.z);
    }
}
