using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDirection : MonoBehaviour
{

    //Camera cam;
    void Start() {
        //本地坐标
        Debug.Log("【transform.localPosition】 :" + transform.localPosition);
        //世界坐标
        Debug.Log("【transform.position】：" + transform.position);
        //将本地坐标转为世界坐标
        Debug.Log("【transform.TransformPoint(transform.position)】：" + transform.TransformPoint(transform.position));
        Debug.Log("【transform.InverseTransformPoint(transform.position)】：" + transform.InverseTransformPoint(transform.position));
    }
    void Update() {

    }
}
