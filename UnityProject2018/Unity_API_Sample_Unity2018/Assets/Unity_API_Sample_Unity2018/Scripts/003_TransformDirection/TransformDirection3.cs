using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDirection3 : MonoBehaviour
{
    
    void Start() {
        //transform.position = transform.localPosition;
        //Debug.Log(transform.localPosition);
        Debug.Log(this.name + "的【transform.position】： " + transform.position);
        //Debug.Log(this.name+ " 经过【transform.TransformPoint(transform.localPosition)】转化后的坐标是："
        //+ transform.TransformPoint(transform.localPosition));
        //Debug.Log(this.name + " 经过【transform.TransformDirection(transform.localPosition)】转化后的坐标是："
        //    + transform.TransformDirection(transform.position));
        Debug.Log(this.name + " 经过【TransformDirection(transform.position)】转化后的坐标是："
            + transform.TransformDirection(transform.position));
        Debug.Log(this.name + " 经过【InverseTransformDirection(transform.position)】转化后的坐标是："
            + transform.InverseTransformDirection(transform.position)); 
    }
}
