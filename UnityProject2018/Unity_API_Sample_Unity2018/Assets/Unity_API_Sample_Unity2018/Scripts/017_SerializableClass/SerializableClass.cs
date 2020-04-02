using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Serializable:序列化类的字段
[System.Serializable]
public class People
{
    public enum faceType
    {
        eyes,
        ears,
        nose,
        mouth
    }
    public faceType face;
    public string body;
    public string hands;
    public string legs;
    public string foot;
}
public class SerializableClass : MonoBehaviour
{
    public People people;
    float speed = 10.0f;
    float moveHorizontal;
    float moveVertical;
    Vector3 movement;
    Rigidbody rb;
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
