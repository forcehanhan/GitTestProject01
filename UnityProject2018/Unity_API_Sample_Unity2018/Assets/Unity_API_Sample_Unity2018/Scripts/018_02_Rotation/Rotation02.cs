/*
 * 时间：
 * 题目：本文实例为大家分享了Unity向量按照某一点进行旋转的具体代码，供大家参考，具体内容如下

一、unity的旋转

首先要知道一点就是在Unity的旋转中使用过四元数进行旋转的，如果对一个物体的rotation直接赋值你会发现结果不是你最终想要的结果，这个时候我们需要去借助Quaternion来进行旋转。

二、向量按照原点进行旋转

用到的Unity内置方法Quaternion.AngleAxis（float angle,Vector3 axis）
 第一个参数就是我们需要旋转的角度 angle大于0时是按照顺时针的方向进行旋转，angle小于0是按照逆时针的方向旋转，这里的旋转时按照坐标原点进行的旋转。
 第二个参数是旋转轴，围绕哪一个坐标轴进行旋转。

注意：使用这个方法时获得的也是四元数，我们将其转换成向量Vector3是需要乘以自身的坐标（四元数 * 自身向量，如果反过来 自身向量 * 四元数 在Unity会发生编译错误，这里需要注意一下）

案例：将Vector3（1,0,1）按照原点旋转45°，90°，180°，270°测试分别用黑、黄、蓝、绿颜色表示

 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Rotation02 : MonoBehaviour
{




    // Update is called once per frame
    void Update() {
        Debug.DrawLine(Vector3.left * 5f, Vector3.right * 5f, Color.red);
        Debug.DrawLine(Vector3.up * 5f, Vector3.down * 5f, Color.green);
        Debug.DrawLine(Vector3.forward * 5f, Vector3.back * 5f, Color.blue);

        Vector3 dir = new Vector3(1, 0, 1);
        Vector3 point = new Vector3(2, 0, 2);

        Debug.DrawLine(Vector3.zero, RotateRound(dir, point, Vector3.up, 45), Color.red);
        Debug.DrawLine(Vector3.zero, RotateRound(dir, point, Vector3.up, 90), Color.yellow);
        Debug.DrawLine(Vector3.zero, RotateRound(dir, point, Vector3.up, 180), Color.blue);
        Debug.DrawLine(Vector3.zero, RotateRound(dir, point, Vector3.up, 270), Color.green);
        Debug.DrawLine(Vector3.zero, dir, Color.black);


    }



    /// <summary>
    /// 围绕某点旋转指定角度
    /// </summary>
    /// <param name="position">自身坐标</param>
    /// <param name="center">旋转中心</param>
    /// <param name="axis">围绕旋转轴</param>
    /// <param name="angle">旋转角度</param>
    /// <returns></returns>
    public Vector3 RotateRound(Vector3 position, Vector3 center, Vector3 axis, float angle) {
        return Quaternion.AngleAxis(angle, axis) * (position - center) + center;
    }
}

