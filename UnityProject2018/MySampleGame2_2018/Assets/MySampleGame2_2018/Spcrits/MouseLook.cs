/*
 * 时间：2020年3月30日22:07:58
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float rotationSpeed = 10f;//旋转速度
    private Quaternion quaternionAngle;
    /// <summary>鼠标水平旋转</summary>
    private float _rotationX = 0f;

    /// <summary>鼠标垂直旋转</summary>
    private float _rotationY = 0f;

    /// <summary>X轴角度旋转范围：最大角</summary>
    private float maxAngle = 45f;

    /// <summary>X轴角度旋转范围：最小角</summary>
    private float minAngle = -45f;

    [SerializeField]
    private MouseAxies rotationAxies = MouseAxies.MouseXAndY;//鼠标旋转轴

    /// <summary>鼠标旋转轴：水平轴和垂直轴</summary>
    public enum MouseAxies
    {
        MouseX = 0,
        MouseY = 1,
        MouseXAndY = 2
    }
    void Start() {
        quaternionAngle = transform.rotation;
    }


    void Update() {
        //水平移动，即X轴
        float h = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        //前后移动，即Z轴
        float v = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;

        //Mouse X：为鼠标水平旋转，即Y轴旋转
        float yAxies = Input.GetAxis("Mouse X") * rotationSpeed;
        //Mouse Y：为鼠标垂直旋转，即X轴旋转
        float xAxies = Input.GetAxis("Mouse Y") * rotationSpeed;

        if (rotationAxies == MouseAxies.MouseX)
        {
            _rotationY = yAxies;//Y轴旋转——鼠标水平旋转
            transform.Rotate(0, _rotationY, 0);
        }
        else if (rotationAxies == MouseAxies.MouseY)
        {
            _rotationX -= xAxies;//x轴旋转变换量——鼠标垂直旋转
            _rotationX = Mathf.Clamp(_rotationX, minAngle, maxAngle);//限制X轴旋转范围
            float rotation_y = transform.localEulerAngles.y;//保持Y轴旋转不变
            transform.localRotation = Quaternion.Euler(_rotationX, rotation_y, 0);//更新当前角色旋转信息

        }
        else if (rotationAxies == MouseAxies.MouseXAndY)
        {
            /*方法一：*/
            /*   _rotationX -= xAxies;//Y轴旋转——鼠标水平旋转
               _rotationX = Mathf.Clamp(_rotationX, minAngle, maxAngle);//限制X轴旋转范围
               float delta = Input.GetAxis("Mouse X") * rotationSpeed;
               float rotation_y = transform.localEulerAngles.y + delta;
               transform.localRotation = Quaternion.Euler(_rotationX, rotation_y, 0);//更新当前角色旋转信息*/


            /*方法二：*/
            //Y轴：鼠标水平旋转
            _rotationX = yAxies;//获取Y轴旋转变化量
            transform.Rotate(0, _rotationX, 0);
            float rotation_y = transform.localEulerAngles.y;

            //X轴：鼠标垂直旋转
            _rotationY -= xAxies;//Y轴旋转——鼠标水平旋转
            _rotationY = Mathf.Clamp(_rotationY, minAngle, maxAngle);//限制X轴旋转范围
            transform.localRotation = Quaternion.Euler(_rotationY, rotation_y, 0);//更新当前角色旋转信息
        }
    }
}
