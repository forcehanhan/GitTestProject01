using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>GameController:控制生成批量的小行星</summary>
public class GameController : MonoBehaviour
{
    public Text scoreText;//打印得分
    private int totalScore;//得分
    public Text gameOverText;
    static bool isGameOver = false;
    public Text restartGameText;


    public GameObject hazardObj;//潜在地危险的游戏对象:小行星
    public Vector3 spawnPositonValues;//产生游戏对象的坐标点的范围
    private Vector3 spawnPositon = Vector3.zero;//产生游戏对象的坐标点
    private Quaternion spawnRotation;//产生的游戏对象的旋转角度

    private int spawnCount = 10;//每次循环数
    private float spawnWaitting = 1.0f;//等待几秒钟


    void Start() {
        //isGameOver = false;
        gameOverText.text = "";
        restartGameText.text = "";
        gameOverText.GetComponent<Text>().enabled = false;
        restartGameText.GetComponent<Text>().enabled = false;

        totalScore = 0;//初始化
        UpdateScore();


        //使用异步函数控制小行星的批量生成
        //InvokeRepeating("SpawnWaves", 1, 1);

        //使用协程控制小行星的批量生成
        StartCoroutine(SpawnWaves());
    }//Start()

    private void Update() {
        if (isGameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
                isGameOver = true;
            }
        }
    }


    /// <summary>SpawnWaves():控制涌现批量的小行星，限制小行星产生的范围 </summary>
    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(spawnWaitting);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                spawnPositon.x = Random.Range(-spawnPositonValues.x, spawnPositonValues.x);
                //spawnPositon.y = 0.0f;
                spawnPositon.z = spawnPositonValues.z;
                spawnRotation = Quaternion.identity;

                //实例化小行星
                Instantiate(hazardObj, spawnPositon, spawnRotation);
                yield return new WaitForSeconds(spawnWaitting);
            }
        }
    }//SpawnWaves()

    /// <summary>AddSorce()：累加得分 </summary> <param name="scoreValue">参数：得分值</param>
    public void AddSorce(int newScoreValue) {
        totalScore += newScoreValue;
        UpdateScore();
    }
    /// <summary>UpdateScore()：更新显示得分到Text</summary>
    private void UpdateScore() {
        scoreText.text = "得  分：" + totalScore;
    }

    public void GameOver() {
        isGameOver = true;
        gameOverText.GetComponent<Text>().enabled = true;
        gameOverText.text = "游戏结束!";
        restartGameText.GetComponent<Text>().enabled = true;
        if (isGameOver)
        {
            restartGameText.text = "按[R]重新开始游戏";
            isGameOver = false;
        }


    }
}

