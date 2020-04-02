//在Inspector的面板中,将Main Camera的Target Display设定为"Display 1"
//在Inspector的面板中,将Other Camera的Target Display设定为"Display 2"
//实现两个相机之间的视角切换
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMatrix : MonoBehaviour
{
    private Camera _camera;
    public Camera otherCamera;
    private Matrix4x4 _cameraMatri4x4;
    private Matrix4x4 otherCameraMatri4x4;
    void Start()
    {
        _camera = transform.GetComponent<Camera>();
        _cameraMatri4x4 = _camera.worldToCameraMatrix;

        GameObject go = GameObject.FindGameObjectWithTag("OtherCamera");
        otherCamera = go.GetComponent<Camera>();
        otherCameraMatri4x4 = otherCamera.worldToCameraMatrix;

        Debug.Log("摄像机this = " + this.GetComponent<Camera>().name);
        Debug.Log("摄像机otherCamera = " + otherCamera.GetComponent<Camera>().name);
    }

    void Update()
    {
        
    }

    private void OnGUI() {
        if (GUI.Button(new Rect(10, 60, 100, 40), "Display2"))
        {
            //由主相机Main Camera的视角 转变为 另一个相机otherCamera的视角

            transform.GetComponent<Camera>().worldToCameraMatrix = otherCameraMatri4x4;
            Debug.Log("Dispaly2");
      
        }

        if (GUI.Button(new Rect(10, 10, 100, 40), "Display1"))
        {

            //由另一个相机otherCamera的视角 转变为 主相机Main Camera的视角
            otherCamera.worldToCameraMatrix = _cameraMatri4x4;
            transform.GetComponent<Camera>().worldToCameraMatrix = otherCamera.worldToCameraMatrix;
            Debug.Log("Dispaly1");
        }
    }
}
