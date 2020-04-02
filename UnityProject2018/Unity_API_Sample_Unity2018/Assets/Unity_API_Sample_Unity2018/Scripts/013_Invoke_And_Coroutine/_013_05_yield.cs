/*
 * 时间：2020年3月16日10:13:17
 * 题目：yield语句的含义
 * 实现目的：掌握协程
 * 操作步骤：
 */

using UnityEngine;
using System.Collections;
public class _013_05_yield : MonoBehaviour
{
    int i = 0;
    IEnumerator Start() //任何事件处理程序都可以是协同程序,Start()也不例外
    {
        yield return null;//等待1帧
        Debug.Log(++i);

        yield return 5;// 等待5帧
        Debug.Log(++i);

        yield return new WaitForSeconds(2f);//等待2秒
        Debug.Log(++i);

        //协程嵌套
        yield return StartCoroutine("Fun1");
        StartCoroutine("Fun2");
    }
    IEnumerator Fun1() {
        yield return null;
        Debug.Log("Fun1");
    }
    IEnumerator Fun2() {
        yield return null;
        Debug.Log("Fun2");
    }
}
