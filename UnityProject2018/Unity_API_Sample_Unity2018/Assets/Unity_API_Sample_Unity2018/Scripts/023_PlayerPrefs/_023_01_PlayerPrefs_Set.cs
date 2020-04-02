/*
 * 时间：2020年3月17日22:26:17
 * 题目：PlayerPrefs:存储玩家信息
 * 实现目的：在另外一个场景中取出该玩家的值
 * 操作步骤：别忘了在"Build Setting"中加载场景
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _023_01_PlayerPrefs_Set : MonoBehaviour
{
    private int playerLevel;//玩家级别
    private string playerName;//玩家姓名
    void Start()
    {
        //玩家信息
        PlayerPrefs.SetString("Name", "张无忌");//姓名
        PlayerPrefs.SetInt("Level", 999);//级别
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnGUI() {
        if (GUILayout.Button("加载场景", GUILayout.Width(100), GUILayout.Height(40)))
        {
            //加载场景
            SceneManager.LoadScene("023_02_PlayerPrefs_Get");
            Debug.Log("姓名:" + playerName);
            Debug.Log("级别:" + playerLevel);
        }
    }
}
