using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameObjectActive : MonoBehaviour
{
    public Camera camera;
    void Start() {

        //外观比
        Debug.Log("外观比= "+camera.aspect);
        //相机像素宽度
        Debug.Log("像素宽度= "+camera.pixelWidth);
        //相机像素高度
        Debug.Log("像素高度= " + camera.pixelHeight);
        //宽高比 = 外观比
        Debug.Log("宽高比= "+(float)camera.pixelWidth / camera.pixelHeight);
    }
}
