using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRotation : MonoBehaviour
{
    public GameObject originalObject;
    public GameObject targetObject;
    private int speed = 1000;
    void Start()
    {
        
    }
  
    void OnGUI() {
        if (GUILayout.Button("沿x轴旋转", GUILayout.Height(50)))
        {
            originalObject.transform.Rotate(Vector3.right * Time.deltaTime * speed);
        }
        if (GUILayout.Button("沿y轴旋转", GUILayout.Height(50)))
        {
            originalObject.transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
        if (GUILayout.Button("沿z轴旋转", GUILayout.Height(50)))
        {
            originalObject.transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        }
        if (GUILayout.Button("围绕targetObject旋转", GUILayout.Height(50)))
        {
            originalObject.transform.RotateAround(targetObject.transform.position, Vector3.up, Time.deltaTime * speed);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }



    




}
