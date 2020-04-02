/*
 * 时间：
 * 题目：
 * 实现目的：
 * 操作步骤：
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Class : MonoBehaviour
{

    Camera camera;
    Vector3 transformPos = Vector3.zero;
    public Transform objTrans;
    void Start() {


        transformPos = new Vector3(objTrans.position.x, objTrans.position.y, objTrans.position.z);
        transform.position = transformPos;
        Debug.Log("transformPos.normalized = " + transformPos.normalized);
        //Vector3 tmp1 = Vector3.Normalize(Vector3.up);
        //Debug.Log("tmp1 = " + tmp1);
        //Vector3 tmp2 = transformPos.normalized;

        Vector3 tmp2 = Vector3.Normalize(Vector3.up);
        Debug.Log("transformPos.normalized = " + tmp2);
    }


}
