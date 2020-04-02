using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>RandomRotator：小行星角度随机旋转 </summary>
public class RandomRotator : MonoBehaviour
{
    /// <summary>bulletSpeed:角度旋转速度</summary>
    float speed = -5.0f;

    /// <summary> planetPoint：在此坐标点产生小行星时。</summary>
    public Transform planetPoint;

    /// <summary>rb：获取小行星的刚体。</summary>
    Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
       /* //产生小行星时，角度要随机旋转
        //rb.angularVelocity = new Vector3(
        //    Random.Range(1, 10) * Time.deltaTime * bulletSpeed,
        //    Random.Range(1, 10) * Time.deltaTime * bulletSpeed,
        //    Random.Range(1, 10) * Time.deltaTime * bulletSpeed);
        //rb.angularVelocity = Random.insideUnitCircle * bulletSpeed;
        //rb.angularVelocity = Random.onUnitSphere * bulletSpeed;
*/
        //产生小行星时，角度要随机旋转
        rb.angularVelocity = Random.insideUnitSphere * speed;
        //产生小行星时，速度要随机
        rb.velocity = new Vector3 (0,0,-Random.Range(2,3));
    }
}
