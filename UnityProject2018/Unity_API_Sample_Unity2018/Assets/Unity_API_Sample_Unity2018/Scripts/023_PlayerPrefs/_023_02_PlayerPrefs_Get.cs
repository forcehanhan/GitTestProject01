/*
 * 时间：2020年3月17日22:26:13
 * 题目：PlayerPrefs
 * 实现目的：从另外一个场景中取玩家的信息
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _023_02_PlayerPrefs_Get : MonoBehaviour
{
    private int playerLevel;//玩家级别
    private string playerName;//玩家姓名
    void Start() {
        //初始化,取键(Key)对应的值(Value),Value的值保存在场景"023_01_PlayerPrefs_Set"中,要被取出来
        playerLevel = PlayerPrefs.GetInt("Level");
        playerName = PlayerPrefs.GetString("Name");
    }

    private void OnGUI() {
        if (GUILayout.Button("加载场景",GUILayout.Width(100),GUILayout.Height(40)))
        {
            //加载场景
            SceneManager.LoadScene("023_01_PlayerPrefs_Set");
            Debug.Log("姓名:" + playerName);
            Debug.Log("级别:" + playerLevel);
        }
    }
}
