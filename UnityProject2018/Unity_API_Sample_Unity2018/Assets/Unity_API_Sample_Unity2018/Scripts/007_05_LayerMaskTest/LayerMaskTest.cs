/*
 * 时间：
 * 题目：
 * 实现目的：开启和关闭Layer
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMaskTest : MonoBehaviour
{
    Camera theCamera;
    //LayerMask mask = ~(1 << 9 | 1 << 11);


    void Start() {
        theCamera = GetComponent<Camera>();


        //int layerName = LayerMask.NameToLayer("Other");
        //theCamera.cullingMask &= ~(1 << 12);//渲染除Layer 12之外的的所有层
        // camera.cullingMask |= ~(1 << layerName);
        //int layer = LayerMask.NameToLayer("Ground");
        // LayerMask.GetMask("Ground");
    }


    void Update() {

        /*if (Physics.Raycast(transform.position, transform.forward, 100, mask.value))
            Debug.Log("Hit something");*/
    }

    private void OnGUI() {

        if (GUILayout.Button("HideAllLayer")) { HideAllLayer(); }
        if (GUILayout.Button("ShowAllLayer")) { ShowAllLayer(); }

        if (GUILayout.Button("HideLayer11")) { HideLayer11(); }
        if (GUILayout.Button("ShowLayer11")) { ShowLayer11(); }

        if (GUILayout.Button("HideGround")) { HideGround(); }
        if (GUILayout.Button("ShowGround")) { ShowGround(); }
    }
    //隐藏全部游戏对象
    void HideAllLayer() {
        int layer = 0;
        //LayerMask maskMask = layer; //表示关闭所有层。
        theCamera.cullingMask = 0 << layer;
    }
    //显示全部游戏对象
    void ShowAllLayer() {
        LayerMask maskMask = 0; //表示开启所有层。
        theCamera.cullingMask = ~maskMask;
    }
    //显示层11
    void ShowLayer11() {
        LayerMask maskMask = 1 << 11; //表示只开启Layer11,其他Layer都被关闭。
        theCamera.cullingMask = maskMask;
        //以上可以写成下面:
        //theCamera.cullingMask = 11;//只显示Layer 11上的游戏对象.
    }
    //隐藏层11
    void HideLayer11() {
/*
        LayerMask maskMask = 0 << 11;
        theCamera.cullingMask = maskMask; //表示关闭Layer11。
*/
        theCamera.cullingMask = ~(1 << 11);//关闭Layer11,但是其他Layer都开启
    }

    //显示层"Ground"
    void ShowGround() {
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Ground"); //表示开启层"Ground"。等价于1 <<  LayerMask.GetMask(("Ground");
        theCamera.cullingMask = layerMask;
    }
    //隐藏层"Ground"
    void HideGround() {
        LayerMask layerMask = ~(1 << LayerMask.NameToLayer("Ground")); //表示只关闭层"Ground"。
        theCamera.cullingMask = layerMask;
    }
}
