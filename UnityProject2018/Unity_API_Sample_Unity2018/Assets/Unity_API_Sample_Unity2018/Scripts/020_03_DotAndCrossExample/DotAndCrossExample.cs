/*
 * 时间：2020年3月28日19:40:27
 * 题目：向量的点乘和叉乘
 * 实现目的：点乘和叉乘的实际应用
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotAndCrossExample : MonoBehaviour
{
    // 蓝色方块CubeA为自身
    // 红色方块CubeB为敌人
    public Transform cubeA_Origin;
    public Transform cubeB_Target;

    private void Update() {

           
    }
    private void OnGUI() {
        if (GUI.Button(new Rect(10, 10, 200, 50), "点乘和叉乘"))
        {
            CalculateDot();
        }
    }
    private void CalculateDot() {
        // 先计算出敌人想对自身的位置信息
        Vector3 b = cubeB_Target.position - transform.position;//计算出方向向量 = 目标点 - 起点
        b = b.normalized;//归一化
        Vector3 a = cubeA_Origin.forward;
        a = a.normalized;//归一化


        // 计算两个向量的点乘
        float resultOfDot = Vector3.Dot(a, b);
        Debug.Log("=====>点积的结果：" + resultOfDot);
   

        // 得到两个向量后，可以直接计算其夹角
        float angle = Vector3.Angle(a, b);
        Debug.Log("=====>夹角∠(a, b) = " + angle + "°");

        // 这是前面说到的当两个向量的长度都为1时，点乘的结果就是夹角的余弦值
        float cos = Vector3.Dot(a, b);
        Debug.Log("=====>余弦值cos<a, b> = " + cos);

        // 通过反余弦函数得到两个向量的角度
        // 不过这里得到是弧度值，并不是角度值
        float radians = Mathf.Acos(cos);
        Debug.Log("=====>通过余弦值求弧度  ⌒(a,b)= " + radians);

        // 弧度值通过数据库转换成角度值
        angle = radians * Mathf.Rad2Deg;
        Debug.Log("=====>把弧度转换成角度∠(a, b) = " + angle + "°");

        //使用叉积，判断左右
        float yValue = Vector3.Cross(a, b).y;
        Debug.Log(yValue);

        // 如果大于0说明敌人在自身前面
        // 如果小于0说明敌人在自身后面
        // 如果等于0说明敌人在自身左右
        if (resultOfDot > 0)
        {
            Debug.Log("=====>Cube B在 CubeA 前面。");
        }
        else if (resultOfDot < 0 && yValue > 0)
        {
            Debug.Log("=====>CubeB 在 CubeA 右后面。");
        }
        else if (resultOfDot < 0 && yValue < 0)
        {
            Debug.Log("=====>CubeB 在 CubeA 左后面。");
        }
        else if(resultOfDot == 0 && yValue > 0)
        {
            Debug.Log("=====>CubeB 在 CubeA 右面。");
        }
        else if(resultOfDot == 0 && yValue < 0)
        {
            Debug.Log("=====>CubeB 在 CubeA 左面。");
        }
    }//CalculateDot()
}
