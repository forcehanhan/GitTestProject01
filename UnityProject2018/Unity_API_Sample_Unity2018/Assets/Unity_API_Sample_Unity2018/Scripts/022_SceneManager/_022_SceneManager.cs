using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _022_SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //按 Ctrl + P 播放场景

    //播放场景之前是暂停的,首先调用该函数
    private void OnApplicationPause(bool pause) {
        Debug.Log("暂停场景");
    }
    //当播放场景后,即是进入当前场景,调用该函数
    private void OnApplicationFocus(bool focus) {
        Debug.Log("聚焦场景");
    }

    //停止播放场景,调用该函数
    private void OnApplicationQuit() {
        Debug.Log("退出场景");
    }

}
