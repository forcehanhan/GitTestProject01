/*
 * 时间：2020年3月27日23:05:09
 * 题目：加载资源：Resources.Load()
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _036_Resources : MonoBehaviour
{
    private GameObject box01_Prefab;//
    private GameObject[] box_PrefabsArr;
    private object[] objPrefabs;
    

    void Start()
    {
        //查找Resources文件下的一个资源
        box01_Prefab = Resources.Load("Prefabs/Props/Box01") as GameObject;
        Debug.Log("找到了：" + box01_Prefab.name);


        //查找Resources文件下的所有资源
        objPrefabs = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject item in objPrefabs)
        {
            Debug.Log("----------------------->找到了:" + item.name);
        }

        //查找Resources文件下的所有资源
        objPrefabs = Resources.LoadAll("Prefabs/Props");
        //遍历打印出所有被找到的资源
        foreach (GameObject item in objPrefabs)
        {
            Debug.Log("=================>找到了:" + item.name);
        }

    }

   
    void Update()
    {
      
    }
}
