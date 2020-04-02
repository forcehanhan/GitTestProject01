/*
 * 时间：
 * 题目：协程Coroutine
 * 实现目的：掌握Coroutine
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _013_03_Coroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input .GetMouseButtonDown(0))
        {
            Debug.Log("开始协程");
        StartCoroutine(Move());
        }
    }//Update()

    IEnumerator  Move() {
        for (int i = 0; i < 50; i++)
        {
            transform.Translate(0, 0, 0.1f);
            yield return null;
        }
            this.transform.position = Vector3.zero;
    }

}
