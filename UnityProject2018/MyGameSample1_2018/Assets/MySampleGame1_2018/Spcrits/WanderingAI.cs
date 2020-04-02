/*
 * 时间：2020年3月27日23:24:05
 * 题目：
 * 实现目的：实现Enemy的简单AI
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;//移动速度常量
    public float obstacleRange = 5.0f;//距离的障碍物的距离
    private bool isAlive;//是否存活

    [SerializeField]
    private GameObject fireBallPrefab;//链接子弹预制体
    private GameObject _fireBall;//接收子弹实例
    void Start()
    {
        isAlive = true;
        Debug.Log("=========》存活：" + isAlive);
    }


    void Update()
    {
        /*实现敌人简单的AI*/
        if (isAlive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);//每帧向前移动
        }
        Debug.Log("=========》死亡：" + isAlive);

        Ray ray = new Ray(transform.position, transform.forward);//从角色位置发射射线，且方向一致
        RaycastHit hitInfo;

        bool isCollider = Physics.SphereCast(ray, 0.75f, out hitInfo);//以球形体积为范围发射射线，半径为0.75

        if (isCollider)//如果检测到障碍物
        {
            GameObject hitObject = hitInfo.transform.gameObject;//找到检测到的游戏对象
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (_fireBall == null)
                {
                    _fireBall = Instantiate(fireBallPrefab) as GameObject;
                    _fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireBall.transform.rotation = transform.rotation;
                }
            }
            else if (hitInfo.distance < obstacleRange)//如果角色的距离 小于 设定的距离
            {
                float angle = Random.Range(-110, 110);//随机产生角度，并转向
                transform.Rotate(0, angle, 0);
            }
        }
    }//Update

    public void SetIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
        Debug.Log("调用了SetIsAlive()");
    }

}
