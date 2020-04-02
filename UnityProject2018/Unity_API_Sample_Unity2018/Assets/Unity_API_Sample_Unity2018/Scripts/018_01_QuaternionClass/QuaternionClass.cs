using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionClass : MonoBehaviour
{

    Quaternion rotations = Quaternion.identity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.up * 30);
    }
}
