/*
 * 时间：2020年3月23日11:20:27
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

/// <summary>MouseLook:(类) 控制鼠标旋转.</summary>
public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,//水平和垂直
        MouseX = 1,//水平旋转
        MouseY = 2//垂直旋转
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;//声明旋转轴,并初始化

    public float sensitivityHor = 9.0f;//水平旋转的灵敏度
    public float sensitivityVer = 9.0f;//垂直旋转的灵敏度
    public float minAngleVer = -45.0f;//最小角度值
    public float maxAngleVer = 45.0f;//最大角度值
    /// <summary> 垂直(y轴)角度旋转的变量</summary>
    private float _rotationX = 0f;
    void Start() {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (axes == RotationAxes.MouseX)
        {
            //Horizontal rotation
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            //垂直旋转的角度(想一想:为什么使用-=?"给角度增加5°" 和 "给角度设置为5°的区别",
            //我们需要的是不断变化的角度,所以-=更加合适.)
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            //Vertical rotation
            //transform.Rotate(0, Input.GetAxis("Mouse Y") * sensitivityVer, 0);//取消此行代码


            //限制垂直旋转的角度
            _rotationX = Mathf.Clamp(_rotationX, minAngleVer, maxAngleVer);

            //保持水平角度
            float rotationY = transform.localEulerAngles.y;

            //实时更新玩家的自身角度信息
            transform.localEulerAngles = new Vector3( _rotationX, rotationY, 0);
        }
        else
        {
            //Horizontal and Vertical
            //transform.Rotate(0, Input.GetAxis("Mouse Y") * sensitivityHor, 0);//取消此行代码
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;//水平旋转

            _rotationX = Mathf.Clamp(_rotationX, minAngleVer, maxAngleVer);
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }

}
