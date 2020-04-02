/*
 * 时间：
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _013_06_CoroutineSample : MonoBehaviour
{
    public GameObject[] cubes;
    void Start() {
        StartCoroutine(SendMsg());
    }

    void Update() {

    }

    IEnumerator SendMsg() {
        foreach (GameObject go in cubes)
        {
            Debug.Log("===>>>  " + go.name);
            while (go.transform.position.y < 5f)
            {
                go.SendMessage("MoveUp", SendMessageOptions.DontRequireReceiver);
                yield return null;
            }
        }
    }
}
