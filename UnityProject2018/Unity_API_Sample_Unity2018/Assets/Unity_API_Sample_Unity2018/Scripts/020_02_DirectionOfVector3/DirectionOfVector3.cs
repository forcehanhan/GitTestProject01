/*
 * 时间：2020年3月28日12:10:55
 * 题目：1、方向向量：Direction(方向向量) = Target(目标向量) - origin(起点向量);
 *          2、向量的归一化
 * 实现目的：使起点的游戏对象移动到目标点
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionOfVector3 : MonoBehaviour
{
    private Vector3 p1 = new Vector3(2, 2, 2);//起点
    private Vector3 p2 = new Vector3(5, 5, 5);//目标点

    private Transform origin;//起点
    private Transform target;//目标点
    private Vector3 direction;//方向向量
    private float speed = 5.0f;
    void Start() {

        #region 距离和方向向量
        //求取距离，是P1-P2，还是P2-P1，长度是不变的
        float d1 = Vector3.Distance(p1, p2);
        Debug.Log("d1 = " + d1);
        float d2 = (p2 - p1).magnitude;
        Debug.Log("d2 = " + d2);

        //方向向量
        //P1 指向 P2 和 p2 指向 P1，他们的方向是不同的
        Vector3 direction1 = p2 - p1;
        Debug.Log("p2 - p1 = " + direction1);

        Vector3 direction2 = p1 - p2;
        Debug.Log("p1 - p2 = " + direction2);
        #endregion

        origin = this.transform;//起点
        target = GameObject.Find("P2").transform;//目标点
      
    }

    
    void Update() {
        //使起点的游戏对象移动到目标点
        //一、方式一：
        //不对direction进行归一化，则会发现，起点游戏对象 移动到 目标点时，速度越来越慢，并不是匀速的。
        /*direction = target.position - origin.position;//获取方向向量
        if (direction.magnitude > 0.1)
        {
            transform.Translate(direction * Time.deltaTime);
        }*/

        //二、方式二：
        direction = target.position - origin.position;//获取方向向量
        direction = direction.normalized;//归一化
        if (direction.magnitude > 0.1)
        {
            //transform.LookAt(target);
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }
}
