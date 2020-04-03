//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-11-19 23:28:35
//备    注：
//===================================================
using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class SceneMgr 
{
    private static SceneMgr _Instance;

    /// <summary>
    /// 单例
    /// </summary>
    public static SceneMgr Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new SceneMgr();
                Debug.Log("SceneMgr实例化了");
            }
            return _Instance;
        }
    }

    public void TestLog()
    {
        Debug.Log("执行单例方法");
    }
}