using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>DestroyByTime：按照一段时间之后销毁游戏对象自身</summary>
public class DestroyByTime : MonoBehaviour
{
    public float lifeTime = 2f;
    void Start() {
        Destroy(gameObject, lifeTime);
    }
}
