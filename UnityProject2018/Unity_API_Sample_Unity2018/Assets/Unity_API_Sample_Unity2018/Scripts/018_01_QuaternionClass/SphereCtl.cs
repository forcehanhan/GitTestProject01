/*
 * 时间：2020年3月28日16:56:46
 * 题目：控制球体运动:乒乓运动、绕圈运动
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCtl : MonoBehaviour
{
    /// <summary>乒乓速度</summary>
    private float pingPongSpeed = 0f;
    /// <summary>绕圈速度</summary>
    private float aroundPointSpeed = 50f;
    /// <summary>绕圈中心点</summary>
    public Transform aroundPoint; 
    void Start() {
        //初始化Sphere的的坐标点
        transform.position = new Vector3(4, 5f, 0);
        //使Sphere看向Player
        transform.LookAt(aroundPoint.position);
    }

    // Update is called once per frame
    void Update() {
        pingPongSpeed += 5f * Time.deltaTime;//乒乓速度

        //做乒乓运动
        transform.position = new Vector3(4, Mathf.PingPong(pingPongSpeed, 5f), 0);

        //因为乒乓运动时，sphere的自身坐标系会实时变化，所以将其转为世界坐标系
        transform.position = transform.TransformVector(transform.position);

        //在说乒乓运动的同时，也作绕圈运动
        transform.RotateAround(aroundPoint.position, Vector3.up, aroundPointSpeed * Time.deltaTime);
    }
}
