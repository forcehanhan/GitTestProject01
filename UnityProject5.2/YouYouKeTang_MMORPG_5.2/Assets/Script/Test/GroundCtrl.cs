//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-11-07 17:32:55
//备    注：
//===================================================
using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class GroundCtrl : MonoBehaviour 
{
    void Start()
    {

    }

    void Update()
    {

    }

    #region 碰撞检测
    /// <summary>
    /// 进入碰撞
    /// </summary>
    /// <param name="info"></param>
    void OnCollisionEnter(Collision info)
    {
        Debug.Log("主角碰撞到了" + info.collider.gameObject.name);
    }

    /// <summary>
    /// 碰撞中
    /// </summary>
    /// <param name="info"></param>
    void OnCollisionStay(Collision info)
    {
        //Debug.Log("碰撞中" + info.collider.gameObject.name);
        gameObject.transform.localPosition = gameObject.transform.localPosition + new Vector3(0, 5, 0);
    }

    /// <summary>
    /// 碰撞离开
    /// </summary>
    /// <param name="info"></param>
    void OnCollisionExit(Collision info)
    {
        //Debug.Log("碰撞离开" + info.collider.gameObject.name);
    }
    #endregion
}