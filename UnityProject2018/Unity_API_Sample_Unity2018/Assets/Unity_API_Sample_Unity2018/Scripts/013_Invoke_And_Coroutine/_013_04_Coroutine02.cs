/*
 * 时间：2020年3月14日21:57:38
 * 题目：协程Coroutine
 * 实现目的：掌握Coroutine
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _013_04_Coroutine02 : MonoBehaviour
{
    void Start() {
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("开始协程");
            StartCoroutine(Move());
            StartCoroutine(OtherTask());
            //Debug.Log("开始OtherTask");
            //OtherTask();
        }
    }//Update()

    IEnumerator Move() {
        for (int i = 0; i < 50; i++)
        {
            transform.Translate(0, 0, 0.1f);
            yield return null;
        }
        this.transform.position = new Vector3(2, 0, 0);
    }

    //该函数是大量的数学运算,用来造成Cube1的"卡顿"现象
    IEnumerator OtherTask() {
        double a;
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < int.MaxValue / 1000; j++)
            {
                a = Mathf.Sqrt(j);
            }
        }
        yield return null;
    }

    /*    void OtherTask() {
            double a;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < int.MaxValue / 1000; j++)
                {
                    a = Mathf.Sqrt(j);
                }
            }
        }//OtherTask()*/


}
