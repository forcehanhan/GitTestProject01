/*
 * 时间：2020年3月23日13:27:17
 * 题目：
 * 实现目的：实现鼠标控制运动
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Cotrol Script/FPS Input")]*/
public class FPSInput : MonoBehaviour
{
    public float moveSpeed = 6.0f;//移动速度
    private CharacterController cc;//玩家控制器
    private float gravity = -9.8f;//重力
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal") * moveSpeed;//获取水平虚拟轴
        float v = Input.GetAxis("Vertical") * moveSpeed;//获取垂直虚拟轴
        Vector3 movement = new Vector3(h, 0, v);//构建一个三维向量来接收玩家的坐标
        movement = Vector3.ClampMagnitude(movement, moveSpeed);//将玩家的最大移动速度限制在speed以下
        movement.y = gravity;//给玩家一个向下的重力,使其不至于飞上天
        movement *= Time.deltaTime;//缩放时间我两帧之间的时间
        movement = transform.TransformDirection(movement);//将玩家的向量转换为世界坐标系的向量
        cc.Move(movement);//调用控制器的Move()函数
        //transform.Translate(h * Time.deltaTime, 0, v * Time.deltaTime);
    }
}
