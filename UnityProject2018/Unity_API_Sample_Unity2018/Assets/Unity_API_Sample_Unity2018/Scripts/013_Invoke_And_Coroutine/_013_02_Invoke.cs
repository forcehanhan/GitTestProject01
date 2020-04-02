/*
 * 时间：2020年3月14日15:30:16
 * 题目：异步函数
 * 实现目的：使用异步函数
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _013_02_Invoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("CreateObj", 1, 3);
       
    }

    
    void Update()
    {
        Invoke("CreateObj", 1);
    }

    void CreateObj() {

        GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}
