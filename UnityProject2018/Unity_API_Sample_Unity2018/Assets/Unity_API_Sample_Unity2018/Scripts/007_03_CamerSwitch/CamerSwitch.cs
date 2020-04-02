/*
 * 时间：2020年3月26日15:38:06
 * 题目：实现摄像机之间的切换
 * 实现目的：依据玩家按下的按键(键盘上的 1、2 和 3),决定启用对应摄像机的AudioListener 和 camera 组件,
 * 禁用其余两部摄像机的 AudioListener 和 camera 组件，玩家因此看到不同的游戏视图。 
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerSwitch : MonoBehaviour
{
	public GameObject[] cameras;//摄像机数组，如Camera1、Camera2、Camera3……
	public string[] CameraLens;//表示不同的摄像机镜头，如1、2、3……
	public bool changeAudioListener = true;//是否切换摄像机的AudioListener

	void Update() {
		int i = 0;
		for (i = 0; i < cameras.Length; i++)
		{
			if (Input.GetKeyUp(CameraLens[i]))
				SwitchCamera(i);
		}
	}

	/// <summary> 控制摄像机的显示和隐藏。</summary><param name="index">摄像机的编号。</param>
	void SwitchCamera(int index) {
		//每个摄像机都有一个编号，如果你按下的数字键的值不等于当前相机的编号，那么就隐藏该相机和AudioListener组件，
		//同时，显示与你输入的编号相对应的相机和AudioListener组件
		int i = 0;
		for (i = 0; i < cameras.Length; i++)
		{
			if (i != index)
			{
				if (changeAudioListener)
				{
					cameras[i].GetComponent<AudioListener>().enabled = false;
				}
				cameras[i].GetComponent<Camera>().enabled = false;
			}
			else
			{
				if (changeAudioListener)
				{
					cameras[i].GetComponent<AudioListener>().enabled = true;
				}
				cameras[i].GetComponent<Camera>().enabled = true;
				Debug.Log(cameras[i].name);
			}
		}
	}
}
