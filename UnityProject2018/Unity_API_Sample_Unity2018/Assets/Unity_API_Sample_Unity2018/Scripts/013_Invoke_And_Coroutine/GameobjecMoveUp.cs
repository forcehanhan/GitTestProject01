/*
 * 时间：
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjecMoveUp : MonoBehaviour
{
    float speed = 2.0f;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    void MoveUp() {
        transform.Translate(Vector3.up * Time .deltaTime *  speed);
    }
}
