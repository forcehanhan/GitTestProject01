/*
 * 时间：2020年3月23日20:47:48
 * 题目：敌人,检测是否击中目标对象
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    /// <summary>ReactToHit()：如果游戏对象被射中，则调用死亡函数Die()</summary>
    public void ReactToHit() {
        WanderingAI waBehaviour = GetComponent<WanderingAI>();
       
        if (waBehaviour != null)
        {
            waBehaviour.SetIsAlive(false);
            Debug.Log(waBehaviour);
        }
        StartCoroutine(Die());
    }

    /// <summary>Die()：死亡函数</summary><returns></returns>
    private IEnumerator Die() {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
