/*
 * 时间：2020年3月29日22:45:28
 * 题目：游戏控制器
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;//用来链接预制体
    private GameObject _enemy;//用来接收实例敌人
    void Start()
    {
        
    }
    
    void Update()
    {
        if (_enemy == null)
        {
            Vector3 angle = new Vector3(0, Random.Range(0, 360), 0);

            //用 _enemy来接收Instantiate()实例化的游戏对象，否则会每帧都生成一个。
            _enemy =  Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
            _enemy.transform.position = Vector3.up;
            _enemy.transform.rotation = Quaternion.Euler(angle);
            _enemy.transform.Rotate(angle);
        }
    }
}
