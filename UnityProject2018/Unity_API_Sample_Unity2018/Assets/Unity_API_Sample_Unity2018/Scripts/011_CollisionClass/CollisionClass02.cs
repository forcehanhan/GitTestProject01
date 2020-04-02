/*
 时间：2020年2月25日12:04:37
 目的：掌握OnCollisionStay
 实现目的：了解OnCollisionEnter、OnCollisionStay、OnCollisionExit三个函数的功能。
 操作步骤：
  * 1、将脚本挂在CubeA上。
  * 2、触发检测,需要将CubeA和CubeB的触发检测先关闭： Is Trigger，在Inspector面板中的Collider组件中操作。
  * 3、运行unity，在Scene视口中，拖动CubeA去碰撞CubeB。
  * 4、在Console面板中查看运行结果。
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionClass02 : MonoBehaviour
{
    public GameObject otherObj;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    //使我们接触的全部刚体向上飞
    void OnCollisionStay(Collision otherCollider) {
        //Debug.Log(collisionInfo.rigidbody.name);
        //检查如果游戏对象A接触的另一个游戏对象B的碰撞器是一个刚体，然后对B应用“力”。
        if (otherCollider.rigidbody != null)
        {
            otherCollider.rigidbody.AddForce(Vector3.up * 100);
            //这两行代码的作用是等价的
            //otherCollider.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
            Debug.Log(otherCollider.rigidbody.name + "说 ：我飞了！！！");
        }
            
    }
}
