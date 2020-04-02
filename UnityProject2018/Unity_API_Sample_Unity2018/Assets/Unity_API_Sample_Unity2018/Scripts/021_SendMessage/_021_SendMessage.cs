/*
 * 时间：2020年3月16日22:39:19
 * 题目：使用SendMessage()调用"某个游戏对象:A"上的方法method(),被调用的该方法method(),必须被"某个游戏对象A:"持有.
 * 实现目的：掌握SendMessage()的使用
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _021_SendMessage : MonoBehaviour
{
    //声明一个数组,来存储游戏对象
    public GameObject[] cubes;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnGUI() {
   
        if (GUI.Button(new Rect(2, 40, 100, 30), "点击我,变绿色"))
        {
            //遍历所有游戏对象,查找并调用每个游戏对象的方法ChangeColor()
            foreach (GameObject cube in cubes)
            {
            //SendMessageOptions.DontRequireReceiver:是指如果没有找到方法ChangeColor(),则也不会不报错.
            cube.SendMessage("ChangeColor", SendMessageOptions.DontRequireReceiver);
            }
        }

        //遍历所有游戏对象,查找并调用每个游戏对象的方法ToBlue()
        if (GUILayout.Button("点击我,变蓝色"))
        {
            foreach (GameObject cube in cubes)
            {
                //SendMessag()函数还能传递参数: Color.blue
                cube.SendMessage("ToBlue", Color.blue, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
