using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> DestroyByBoundary：按照边界范围销毁游戏对象自身</summary>
public class DestroyByBoundary : MonoBehaviour
{
    /// <summary>如果游戏对象离开边界之外，则销毁自身。</summary>
    /// <param name="other">其他游戏对象的Collider。</param>
    private void OnTriggerExit(Collider other) {
        Destroy(other.gameObject);//需要配合刚体（Rigidbody）使用：给Boundary的Collinder加一个刚体。
    }
    void Start()
    {
        
    }

}
