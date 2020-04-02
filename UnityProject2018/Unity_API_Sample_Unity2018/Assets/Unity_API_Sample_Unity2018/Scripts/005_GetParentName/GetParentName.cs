using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetParentName : MonoBehaviour
{
    void Start()
    {
        //获取当前物体的父级的名称
        Debug.Log("名称：" + transform.parent.name);
        //获取当前物体的父级的、父级的名称
        Debug.Log("名称：" + transform.parent.parent.name);
        //获取当前物体的 根父级（第一级） 的名称
        Debug.Log("名称：" + transform.root.name);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
