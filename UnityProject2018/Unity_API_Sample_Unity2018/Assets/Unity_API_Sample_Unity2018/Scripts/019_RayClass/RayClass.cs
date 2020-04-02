//目的:掌握射线ray的使用

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayClass : MonoBehaviour
{
    private Ray ray;

    private Camera camera;

    /// <summary>hitInfo：接收碰撞信息</summary>
    private RaycastHit hitInfo;//碰撞信息包含有collider、point、normal、distance等等

    /// <summary>hitPoint:碰撞点的位置</summary>
    private Vector3 hitPoint;

    /// <summary>isCollider：是否发生碰撞</summary>
    private bool isCollider = false;

    void Start() {
        camera = GetComponent<Camera>();
        
    }


    void Update() {

        //gameObject.name.Equals("Ground", System.StringComparison.CurrentCultureIgnoreCase);
        //Debug.DrawLine(camera.ScreenToViewportPoint(Vector3.up), Vector3.zero, Color.red);

        if (Input.GetMouseButton(0))
        {
            //发射射线，并接收碰撞点的信息
            ray = camera.ScreenPointToRay(Input.mousePosition);//由当前摄像机为起点发射条射线
            //ray = Camera.main.ScreenPointToRay(Input.mousePosition);//由主相机（Main Camera）为起点发射一条射线
            isCollider = Physics.Raycast(ray, out hitInfo, 1000.0f);
            hitPoint = hitInfo.point;

            //如果与地面发生了碰撞
            if (isCollider && (hitInfo.collider.tag == Tags.ground))
            {
                //不同的画射线的方式
                //Debug.DrawLine(camera.transform.position, hitPoint, Color.red, 1000.0f//发射射线后，不消失
                //Debug.DrawLine(camera.transform.position, hitPoint, Color.red, Mathf.Infinity);//发射射线后，不消失
                //Debug.DrawLine(camera.transform.position, hitPoint, Color.red);//发射射线后，消失
                Debug.DrawRay(camera.transform.position, hitPoint,Color.red,1000f);//发射射线后，消失
                

                Debug.Log("发射射线：" + isCollider);

                Debug.Log("=============");
                Debug.Log("camera.transform.position = " + camera.transform.position);
                Debug.Log("Camera.main.transform.position = " + Camera.main.transform.position);
                //Debug.Log("hitInfo.point = " + hitInfo.point);
                Debug.Log("ray.origin = " + ray.origin);
                Debug.LogFormat("ray = {0}", ray);

            }
           
            /*
             * 关于比较是否相等还可以使用Equals()函数。
            if (isCollider && (hitInfo.collider.tag.Equals("Ground", System.StringComparison.CurrentCultureIgnoreCase)))
            {
                //Debug.DrawLine(camera.transform.position, hitPoint);
                Debug.Log("发射射线：" + isCollider);
            }
            */
        }

    }//Update

    private void OnDrawGizmos() {
        if (isCollider && (hitInfo.collider.tag == Tags.ground))
        {
            //画出射线
            Debug.Log("画出射线");
        Gizmos.DrawLine(camera.transform.position, hitPoint);
            Gizmos.DrawWireSphere(hitPoint, 5f);

        }
    }
}

