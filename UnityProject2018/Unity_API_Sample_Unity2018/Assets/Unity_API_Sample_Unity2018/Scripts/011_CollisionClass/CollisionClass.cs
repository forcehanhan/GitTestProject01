/*
 * 2020年2月25日12:04:37
 * 实现目的：了解OnCollisionEnter、OnCollisionStay、OnCollisionExit三个函数的功能。
  * 操作步骤：
  * 1、将脚本挂在CubeA上。
  * 2、触发检测,需要将CubeA和CubeB的触发检测先关闭： Is Trigger，在Inspector面板中的Collider组件中操作。
  * 3、运行unity，在Scene视口中，拖动CubeA去碰撞CubeB。
  * 4、在Console面板中查看运行结果。
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionClass : MonoBehaviour
{
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    #region Collider相互接触，触发检测
    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.collider.name == "CubeB")
        {
            Debug.Log("OnCollisionEnter：进入");
        }
    }

    void OnCollisionStay(Collision collisionInfo) {
        if (collisionInfo.collider.name == "CubeB")
        {
            Debug.Log("OnCollisionStay：停留");
        }
    }

    void OnCollisionExit(Collision collisionInfo) {
        if (collisionInfo.collider.name == "CubeB")
        {
            Debug.Log("OnCollisionExit：退出");
        }
    }
    #endregion
}
