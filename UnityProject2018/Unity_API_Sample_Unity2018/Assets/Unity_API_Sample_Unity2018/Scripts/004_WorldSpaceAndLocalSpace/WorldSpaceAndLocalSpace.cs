using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceAndLocalSpace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.name + "的局部坐标：" + transform.localPosition);
        //Debug.Log("局部坐标转世界矩阵：" + transform.localToWorldMatrix);
        //Vector3 vec1 =  transform.TransformPoint(transform.position);
        Vector3 vec1 =  transform.TransformVector(transform.position);
        Debug.Log(transform.name+"从局部坐标："+ transform.localPosition+"转为世界坐标:" + vec1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
