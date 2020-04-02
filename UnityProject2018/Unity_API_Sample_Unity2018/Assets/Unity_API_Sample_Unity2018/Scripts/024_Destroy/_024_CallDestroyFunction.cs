/*
 * 时间：
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _024_CallDestroyFunction : MonoBehaviour
{
    private GameObject obj;
    void Start() {
        obj = GameObject.Find("Cube1");
        Debug.Log(obj.name);
        obj.GetComponent<_024_Destroy>().Print();
    }

    // Update is called once per frame
    void Update() {

    }


    /* private void OnGUI() {
         if (GUILayout.Button("销毁物体"))
         {
         _024_Destroy des = new _024_Destroy();
             GameObject cube1 = GameObject.Find("cube1");
             Debug.Log(cube1.GetComponent<GameObject>().gameObject.name);
         }
     }*/

}
