/*
 * 时间：2020年3月23日15:50:23
 * 题目：
 * 实现目的：实现射击
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    void Start() {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //做出准星
    private void OnGUI() {
        int size = 20;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
     
        //画出准星
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
    
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 cameraPoint = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(cameraPoint);
            RaycastHit hitInfo;

            bool isCollinder = Physics.Raycast(ray, out hitInfo);

            if (isCollinder)
            {
                GameObject hitObject = hitInfo.transform.gameObject;//找到被射击的游戏对象

                ReactiveTarget targetComponent = hitObject.GetComponent<ReactiveTarget>();//找到被射击游戏对象的ReactiveTarget组件
               //如果检测到该组件存在，则调用销毁游戏对象
                if (targetComponent != null)
                {
                    targetComponent.ReactToHit();//调用协程（Die()）
                    //Debug.Log("HitInfo " + hitInfo.point);
                }
               /* else//否则创建一个sphere
                {
                    StartCoroutine(SphereIndicator(hitInfo.point));
                }*/
            }
        }
    }//Update

    /// <summary>创建射击点。</summary><param name="pos">接收射击点：Vector3。</param><returns></returns>
    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
