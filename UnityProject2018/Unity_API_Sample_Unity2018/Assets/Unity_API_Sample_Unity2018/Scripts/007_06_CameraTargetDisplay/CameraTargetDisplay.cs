/*
 * 时间：
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //触发器
    //进入--触发
    private void OnTriggerEnter(Collider other) {
    }
    //停留--触发
    private void OnTriggerStay(Collider other) {
    }
    //退出--触发
    private void OnTriggerExit(Collider other) {
    }

    //碰撞器
    //进入--碰撞
    private void OnCollisionEnter(Collision collision) {
        Collider co = transform.GetComponent<Collider>();
        co = collision.collider;
    }
    //停留--碰撞
    private void OnCollisionStay(Collision collision) {
    }
    //退出--碰撞
    private void OnCollisionExit(Collision collision) {
    }


    private void OnControllerColliderHit(ControllerColliderHit hit) {
        
    }
    private void OnParticleCollision(GameObject other) {
        
    }
}
