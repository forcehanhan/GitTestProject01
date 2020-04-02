/*
 * 时间：2020年3月26日02:07:35
 * 题目：Quaternion.lookRotation ()：注视旋转
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quaternion_lookRotation : MonoBehaviour
{
    public GameObject sphere;//获取被注视的游戏对象
    private Quaternion q_Rotation;//接收注视的信息：四元数
    private Vector3 direction;//接收（目标 指向 起点）的方向向量——就是向量减法
    private Ray ray;
    GameObject eye;
    void Start()
    {
        eye = GameObject.Find("EyeOfPlayer");//获取Player 的眼睛（用来注视的）
    }

    // Update is called once per frame
    void Update()
    {
        direction = sphere.transform.position - transform.position;
        direction = direction.normalized;
        ray = new Ray(eye.transform.position, direction);
        Debug.DrawLine(eye.transform.position, sphere.transform.position, Color.green);
        direction = direction * Time.deltaTime * 10f;
        q_Rotation = Quaternion.LookRotation(direction);
        transform.rotation = q_Rotation;//实时更新Player的旋转信息
    }
}
