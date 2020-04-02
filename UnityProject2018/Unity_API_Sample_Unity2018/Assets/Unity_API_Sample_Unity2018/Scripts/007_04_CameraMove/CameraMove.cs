
/*
 * 时间：
 * 题目：
 * 实现目的：实现摄像机漫游
 * 操作步骤：
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float camSpeed = 10f;
    private float endZ = -8.4f;
    private Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
    }

    void Update() {
        //如果相机的z轴坐标值小于endZ,那么相机将向前(+z)移动,直到position.z ≮ endZ
        if (transform.position.z <= endZ)
        {
            transform.Translate(Vector3.forward * camSpeed * Time.deltaTime, Space.World);
        }
    }
}
