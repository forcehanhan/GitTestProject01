/*Unity中场景会默认一个主相机(Main Camera),那么Unity是怎么识别主相机的呢?
 * 要满足条件:
 * 1、主相机(Main Camera)的标签（Tag）要被标记为"Main Camera".
 * unity会从该标签中搜索主相机,如果你的主相机没有被标记该标签,那么Unity会依次搜索其他被标记"Main Camera"标签的相机,
 * 不管你的相机名称是什么.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Camera MyCamera;
    void Start()
    {
        MyCamera.GetComponent<Camera>();
        //打印出该相机名称,你会发现,打印的名称并不一定是"Main Camera",而是标签为"Main Camera"的那个相机.
        Debug.Log(Camera.main.transform.name);
    }

    void Update()
    {
        
    }

    private void OnGUI() {
        GUI.Label(new Rect(10, 10, 500, 100), "Unity是怎么识别主相机Main Camera的？");
    }
}
