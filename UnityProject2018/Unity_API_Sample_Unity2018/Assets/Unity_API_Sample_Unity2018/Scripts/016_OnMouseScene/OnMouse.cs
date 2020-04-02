/*
 * 时间：2020年3月24日23:47:35
 * 题目：
 * 实现目的：
 * 操作步骤：
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMouse : MonoBehaviour
{
    public Scene newScene;
    Ray ray;//射线
    Vector3 hitPoint;//检测点
    RaycastHit hitInfo;//接收检测点信息
    void Start() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        
    }
    //鼠标触发事件
    //当按下鼠标的左键,则发射射线
    void OnMouseDown() {
        if (Input.GetMouseButtonDown(0))
        {

            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && gameObject.tag.Equals(Tags.ground, System.StringComparison.OrdinalIgnoreCase))
            {
                hitPoint = hitInfo.point;
            }
            //Debug.DrawLine(Camera.main.transform.position, hitPoint, Color.red, 10000.0f);
            Debug.DrawLine(ray.origin, hitPoint, Color.red, 10000.0f);
            //Debug.DrawLine(ray.origin, hitPoint, Color.red);
            Debug.Log("发射了射线！");
            string str = "Assets/Unity_API_Sample_Unity2018/Scenes/DemoScene.unity";
            str = newScene.path ;
            int i = newScene.buildIndex;
            Debug.Log(i);
        }
        Debug.Log("鼠标左键按下了！");

    }



    
    void Update() {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    bool isCollider = Physics.Raycast(ray, out hitInfo);
        //    if (isCollider && gameObject.tag.Equals(Tags.ground,System.StringComparison.OrdinalIgnoreCase))
        //    {
        //        //hitPoint = hitInfo.transform.position;
        //        hitPoint = hitInfo.point;
        //    }
        //    //Debug.DrawLine(Camera.main.transform.position, hitPoint, Color.red, 10000.0f);
        //    Debug.DrawLine(ray.origin, hitPoint, Color.red, 10000.0f);
        //}
    }


}
