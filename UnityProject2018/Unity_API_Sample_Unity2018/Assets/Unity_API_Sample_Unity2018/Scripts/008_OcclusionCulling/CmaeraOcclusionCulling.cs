/*
 * 时间：
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmaeraOcclusionCulling : MonoBehaviour
{
    Camera cam;
    void Start() {
        cam = GetComponent<Camera>();
        float[] distances = new float[32];

        //这里定义的数组下标“8”表明第8层

        distances[13] = 2;

        //Camera.main.layerCullDistances = distances;
        cam.layerCullDistances = distances;

        Debug.Log(distances[13].ToString());
            Debug.Log("asa");
    }

    // Update is called once per frame
    void Update() {

    }
}
