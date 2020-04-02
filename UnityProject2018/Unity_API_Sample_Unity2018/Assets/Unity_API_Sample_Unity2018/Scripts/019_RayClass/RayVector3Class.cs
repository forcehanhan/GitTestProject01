using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayVector3Class : MonoBehaviour
{
    Ray ray;
    Camera myCamera;
    Vector3 pos;
    void Start()
    {
        myCamera = GetComponent<Camera>();
        pos = new Vector3(100,30,5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //每点击一次鼠标左键,就发射一条射线,并且每一次射线的目标点都会变化
                pos.x+=100;
                pos.y+=100;
                pos.z+=100;
                ray = myCamera.ScreenPointToRay(pos);
                Debug.DrawLine(myCamera.transform.position, pos,Color.red);
            
            //发射射线
            
        }
        
    }
}
