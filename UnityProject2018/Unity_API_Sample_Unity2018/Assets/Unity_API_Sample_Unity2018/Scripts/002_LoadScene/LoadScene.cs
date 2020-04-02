using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //实现场景加载,首先需要确保"Build settings"中已经对场景进行了构建:
    //步骤:
    //
    void Start()
    {
        //SceneManager.LoadScene("DemoScene", LoadSceneMode.Additive);
        
    }

    private void OnGUI() {
        if (GUI.Button(new Rect(10, 10, 200, 50), "加载场景DemoScene"))
        {
            SceneManager.LoadScene("DemoScene");
        }
        if (GUI.Button(new Rect(10, 80, 200, 50), "加载场景SampleScene"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void Update()
    {
        
    }
}
