/*
 * 时间：2020年3月25日16:55:48
 * 题目：发射射线检测，完成角色移动、平滑转身
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAndMove : MonoBehaviour
{
    private Camera _camera;
    /// <summary>接收碰撞点的信息(RaycastHit)</summary>
    private RaycastHit hitInfo;

    /// <summary>鼠标点击点(Vector3)</summary>
    private Vector3 hitPointTarget = Vector3.zero;

    /// <summary>角色的移动速度(float)</summary>
    private float playerMoveSpeed= 10f;

    /// <summary>cc：角色控制器（CharacterController）。</summary>
    private CharacterController cc;

    /// <summary>角色转身的角速度</summary>
    private float playerRotateSpeed = 0f;

    /// <summary> 重力加速度</summary>
    private float gravity = 9.8f;

    /// <summary>转身后的角度</summary>
    private Quaternion targetQuaternion;






    void Start() {
        GameObject go = GameObject.FindGameObjectWithTag("MainCamera");
        _camera = go.GetComponent<Camera>();
        cc = transform.GetComponent<CharacterController>();

    }


    void Update() {
        //一、发射射线，检测地面
        if (Input.GetMouseButtonDown(0))
        {
            bool isCollider = false;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            isCollider = Physics.Raycast(ray, out hitInfo, 1000.0f);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                hitPointTarget = hitInfo.point;
                playerRotateSpeed = 0;//当点击地面时，将转身角速度设置为0

                //Debug.DrawLine(_camera.transform.position, hitPointTarget);//画出所发射射线
            }
        }//if

        //二、判断Player是否接地
        if (cc.isGrounded == false)
        {
            //如果角色不接地，利用重力加速度使其向下移动与地面接触
            cc.Move(Vector3.down * gravity);
        }


        if (hitPointTarget != Vector3.zero)
        {
            //计算方向向量（目标点 指向 Player）
            if (Vector3.Distance(hitPointTarget, transform.position) > 0.1f)//计算Player与目标点的距离是否重合
            {
                Vector3 direction = hitPointTarget - transform.position;//向量的减法，
                direction = direction.normalized;//归一化
                direction = direction * Time.deltaTime * playerMoveSpeed;//得到Player平滑的变化向量
                direction.y = 0;

                //实现Player平滑转身
                if (playerRotateSpeed <= 1f)
                {
                    playerRotateSpeed += 5.0f * Time.deltaTime;//每次更新Update就给角速度增加5，而不采用直接设置的方式： playerRotateSpeed = 5f;
                    targetQuaternion = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, playerRotateSpeed );
                }//3、if
                cc.Move(direction);
            }//2、if
        }//1、if

    }//Update

}
