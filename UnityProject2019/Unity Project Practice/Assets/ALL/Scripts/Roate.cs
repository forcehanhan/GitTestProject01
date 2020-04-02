using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Roate : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    private Vector3 vec;
    Matrix4x4 matri;
    void Start()
    {
        Debug.Log(camera.transform.position);
        matri = camera.cameraToWorldMatrix;
        Vector3 v1 = matri.MultiplyPoint(Vector3.forward * 5);
        
        Debug.Log("V1= "+v1);
        
        camera.transform.Rotate(Vector3.up * 90);
        Vector4 v2 = matri.MultiplyPoint(Vector3.forward * 5);
        Debug.Log("V2= " + v2);
        Debug.Log(camera.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
