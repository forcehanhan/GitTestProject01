using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDirection2 : MonoBehaviour
{
    void Start() {
      
        Debug.Log(this.name+" 经过【transform.TransformPoint(transform.position)】转化后的坐标是：" 
            + transform.TransformPoint(transform.position));
    }
    void Update() {

    }
}
