/*
 * 时间：2020年3月24日22:17:11
 * 题目：四元数 和 欧拉角
 * 实现目的：欧拉角 和 四元数 之间的相互转换
 * 操作步骤：
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerAndQuaternion : MonoBehaviour
{
    void Start()
    {
        //一、改变游戏对象的角度
        //欧拉角eulerAngles 是用三维向量Vector3(x,y,z)来表示的。
        GameObject cube1 = GameObject.Find("Cube1");
        cube1.transform.eulerAngles = new Vector3(30, 0, 0); ;
        Debug.Log("====>一、把x轴旋转30°后，则x轴旋转角度  =  " + cube1.transform.eulerAngles);
        DrawRay(cube1);

        //二、把欧拉角 转为 四元数
        GameObject cube2 = GameObject.Find("Cube2");
        cube2.transform.eulerAngles = new Vector3(-30, 0, 0);
        Vector3 eularAngle = cube2.transform.eulerAngles;
        Quaternion quaternionAngle = Quaternion.Euler(eularAngle);
        cube2.transform.rotation = quaternionAngle;
        Debug.Log("====>二、把欧拉角(-30, 0, 0) ，转为四元数 = " + cube2.transform.rotation);
        DrawRay(cube2);

        //三、把四元数 转为 欧拉角
        GameObject cube3 = GameObject.Find("Cube3");
        cube3.transform.rotation = new Quaternion(0f, 0.1f, 0f, 1);
        Vector3 euarAngleVector3 = cube3.transform.rotation.eulerAngles;
        //euarAngleVector3 = cube3.transform.eulerAngles;
        Debug.Log("====>三、把四元数((0f, 0.1f, 0f, 1) ，转为欧拉角 = " + euarAngleVector3);
        DrawRay(cube3);


        //四、给游戏对象以“欧拉角”的形式赋值，Unity自动转化为四元数
        GameObject cube4 = GameObject.Find("Cube4");
        cube4.transform.rotation = Quaternion.Euler(0, 0, 30);//Euler()可以将欧拉角转化为四元数，返回四元数
        Debug.Log("====>四、Cube4的欧拉角(0, 0, 30)被自动转为四元数 = " + cube4.transform.rotation);

    }


    void Update()
    {
        
    }

    /// <summary>画出有颜色的射线,作为游戏对象的轴</summary><param name="obj">游戏对象:GameObject</param>
    private void DrawRay(GameObject obj) {
        
        //Debug.DrawLine(transform.position, transform.up, Color.green, 200);
        // +x
        Debug.DrawRay(obj.transform.position, obj.transform.right, Color.red, Mathf.Infinity);
        // +y
        Debug.DrawRay(obj.transform.position, obj.transform.up, Color.green, Mathf.Infinity);
        // +z
        Debug.DrawRay(obj.transform.position, obj.transform.forward, Color.blue, Mathf.Infinity);
    }
}
