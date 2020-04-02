/*
 * 时间：2020年3月30日01:09:30
 * 题目：控制火球（子弹）
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 10f;//子弹速度倍数
    public int damage = 1;//伤害


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //检测other游戏对象是否为PlayerCharacter
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
            Debug.Log("Player hit");
        }

        Destroy(this.gameObject);
    }
}
