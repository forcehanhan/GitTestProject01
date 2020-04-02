using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation01 : MonoBehaviour
{
    public Transform rotatePoint;
    void Start()
    {
        //transform.rotation = Quaternion.Euler(30, 0, 0);//将游戏对象的世界坐标系的角度初始化为:x轴旋转30度
        //transform.localRotation = Quaternion.Euler(30, 0, 0);//将游戏对象的局部坐标系(自身)的角度初始化为:x轴旋转30度
        Debug.Log(transform.rotation);
    }

    void Update()
    {
        //transform.RotateAround(Vector3.up, 10);//围绕 ...旋转，已弃用
        //transform.Rotate(transform.position, 10);//围绕自身的坐标点旋转
        //transform.Rotate(Vector3.up, 15, Space.World);//围绕世界坐标系的y轴旋转
        transform.Rotate(Vector3.up, 1, Space.Self);//围绕局部坐标系的y轴旋转
        //transform.SetPositionAndRotation(Vector3.up, Quaternion.Euler(30, 0, 0));
        Debug.Log(transform.rotation);
    
           




    }
}
