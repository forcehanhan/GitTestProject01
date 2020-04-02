using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCullLayer : MonoBehaviour
{
    public Transform CullingObject;
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        //声明数组来存放Layer的消隐距离，一共有32个layer。
        float[] distances = new float[32];

        // 获取摄像机与游戏对象之间的距离
        distances[10] = Vector3.Distance(transform.position, CullingObject.position);
      
        //将消隐距离赋值给Camera的具有消隐功能的属性layerCullDistances
        camera.layerCullDistances = distances;
    }
    void Update()
    {
        //摄像机远离物体，当游戏对象和摄像机之间的距离大于distances[10]时，则被消隐。
        transform.Translate(-transform.forward * Time.deltaTime);
    }
}
