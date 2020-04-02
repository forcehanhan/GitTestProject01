using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Boundary：游戏视图的边界，也是Player的活动范围。</summary>
[System.Serializable]
public class Boundary
{
    /// <summary> xMin：边界的x轴最小值。</summary>
    public float xMin = -5.9f;

    /// <summary> xMax：边界的x轴最大值。</summary>
    public float xMax = 5.9f;

    /// <summary>zMin：边界的z轴最小值。</summary>
    public float zMin = -4.0f;

    /// <summary>zMax：边界的z轴最大值。</summary>
    public float zMax = 14.0f;

}//Boundary

public class PlayerController : MonoBehaviour
{
    public Boundary boundary;

    /// <summary>移动速度(标量)</summary>
    float speed = 10.0f;

    ///<summary>水平移动</summary>
    float h;
    ///<summary>垂直移动</summary>
    float v;

    /// <summary>tilt：飞船左右移动时的倾斜度。</summary>
    float tilt = 5.0f;

    /// <summary>fireRate：子弹发射频率</summary>
    float fireRate = 0.15f;

    /// <summary>nextFire：下一次发射子弹的时间间隔</summary>
    float nextFire;

    /// <summary> movement：接收移动的向量</summary>
    Vector3 movement;

    /// <summary>bulletRigidbody：获取子弹的刚体</summary>
    Rigidbody bulletRigidbody;

    /// <summary> bullet：子弹。</summary>
    public GameObject bullet;

    /// <summary>shotPoint：子弹的射击点。</summary>
    public Transform shotPoint;

    void Start() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }


    void Update() {
        //按下空格键发射子弹,发射子弹的间隔为nextFire
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotPoint.position, transform.rotation);
            //GameObject cloneGameObject = Instantiate(bullet, shotPoint.position, transform.rotation);
            //Destroy(cloneGameObject, 1.5f);
        }
    }
    private void FixedUpdate() {
        //获取虚拟轴
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //接收虚拟轴移动的向量
        movement = new Vector3(h, 0, v);

        //限定移动边界
        bulletRigidbody.position = new Vector3(Mathf.Clamp(bulletRigidbody.position.x, boundary.xMin, boundary.xMax), 0, Mathf.Clamp(bulletRigidbody.position.z, boundary.zMin, boundary.zMax));

        //判断何时移动
        if (bulletRigidbody != null)
        {
            //移动速度 = 移动向量 * 倍数(标量)
            bulletRigidbody.velocity = movement * speed;

            //模拟飞船左右移动时的倾斜度
            bulletRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, bulletRigidbody.velocity.x * (-tilt));
        }
    }
}
