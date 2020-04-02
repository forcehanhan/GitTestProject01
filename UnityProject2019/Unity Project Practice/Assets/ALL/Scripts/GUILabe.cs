using UnityEngine;




public class GUILabe : MonoBehaviour
{
    //定义旋转速度
    private float speed = 1000.0f;
    //标记状态
    bool isRotate = false;

    //void OnGUI() {
    //     GUI.Label(new Rect(10.0f, 10.0f, 300.0f, 40.0f), "我是GUI.Label_01");
    //     GUI.Label(new Rect(10.0f, 40.0f, 300.0f, 40.0f), "我是GUI.Label_02");
    //     GUI.Button(new Rect(10.0f, 70.0f, 150.0f, 40.0f), "我是GUI.Button_01");
    // }
    //当鼠标进入游戏物体时，标记为：是
    void OnMouseEnter() {
        Debug.Log("鼠标进入");
        isRotate = true;
    }
    //当鼠标离开游戏物体时，标记为：否
    void OnMouseExit() {
        Debug.Log("鼠标退出");
        isRotate = false;
    }

    void Start() {

    }
    void Update() {
        if (isRotate == true)
        {
            this.transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
        else
        {
            this.transform.Rotate(Vector3.up * 0);
        }
    }
}
