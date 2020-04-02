using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>BulletMover：控制子弹的移动。</summary>
public class BulletMover : MonoBehaviour
{
   /// <summary>bulletSpeed：速度。</summary>
    float bulletSpeed = 15.0f;
    void Start()
    {

    }

    void Update()
    {
        //子弹bullet相对玩家Player移动。
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime, Space.World);
    }
}
