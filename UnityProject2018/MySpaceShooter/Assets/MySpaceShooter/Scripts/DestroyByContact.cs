using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>DestroyByContact：按照彼此接触后销毁游戏对象自身</summary>
public class DestroyByContact : MonoBehaviour
{
    #region 字段声明
    private float countdownTime;

    /// <summary>explosion_asteroid：小行星的爆炸特效 </summary>
    public GameObject explosion_asteroid;

    /// <summary>explosion_player：角色的爆炸特效</summary>
    public GameObject explosion_player;

    /// <summary> scoreValue:得分值 </summary>
    public int scoreValue = 10;

    /// <summary>gc：GameController；游戏控制器的实例对象</summary>
    private GameController gc;

     /*static bool isPlayer = true;//玩家是否被销毁*/
    #endregion
    void Start() {

        countdownTime = 10f;//倒计时
        /*isPlayer = true;//玩家是否被销毁*/

        //查找游戏对象GameController上的脚本GameController.cs。
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        if (go != null)
        {
            gc = go.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("找不到tag为GameController的对象。");
        }
        if (gc == null)
        {
            Debug.Log("找不到脚本GameController.cs");
        }

        //player = GameObject.Find("Player");

    }//Start()
    void Update() {
        /*Debug.Log("1111 = " + isPlayer);
        if (gc.isGameOver == false)
        {
            Debug.Log("玩家死亡");
            countdownTime -= Time.deltaTime * 10f;
            //Debug.Log(countdownTime);
            Debug.Log("2222 = " + isPlayer);
            if (countdownTime < 0)
            {
                //玩家死亡,游戏结束
                gc.GameOver();
                countdownTime = 0.0f;
            }
        }*/
    }//Update()


    /// <summary>OnTriggerEnter()：游戏对象进入彼此的Collider，然后销毁对方。</summary><param name="other">其他游戏对象的Collider。</param>
    private void OnTriggerEnter(Collider other) {
        //排除边界Boundary。
        if (other.tag == "Boundary")
        { return; }

        //销毁自身，然后产生特效 
        Destroy(this.gameObject);//销毁小行星asteroid
        Destroy(other.gameObject);//销毁子弹bullet
        Instantiate(explosion_asteroid, transform.position, transform.rotation);//实例化小行星的爆炸特效

        //判断玩家Player是否满足被销毁的条件
        if (other.tag == "Player")
        {
            Instantiate(explosion_player, other.transform.position, other.transform.rotation);//实例化玩家飞船的爆炸特效
            Destroy(other.gameObject);//销毁小行星
            Destroy(gameObject);//销毁玩家飞船
            /*isPlayer = false;*/
        gc.GameOver();
        }
        gc.AddSorce(scoreValue);//如果小行星被玩家击中,则奖励10分


    }//OnTriggerEnter()
}
