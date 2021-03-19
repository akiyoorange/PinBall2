using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //得点を表示するテキスト
    private GameObject scoreText;

    //各得点の初期化
    int scoreA = 0;
    int scoreB = 0;
    int scoreC = 0;
    int scoreD = 0;

    void Start() 
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

    }
       
　　//衝突時の判定
　　void OnCollisionEnter(Collision collision) 
    {
　　　　 //衝突時に各Tagの得点を加算
        if (collision.gameObject.tag == "SmallStarTag")
        {
            scoreA += 5;
            Debug.Log("小さい星に当った");
        }
        else if (collision.gameObject.tag == "LargrStarTag")
        {
            scoreB += 15;
            Debug.Log("大きい星に当った");
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
            {
            scoreC += 10;
            Debug.Log("小さい雲に当った");
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
                scoreD += 20;
            Debug.Log("大きい雲に当った");
        }       
    }

    void Update()
    {
        //ボールが画面外に出た場合の処理
        if (this.transform.position.z < this.visiblePosZ)
        {
            //各得点の合計値を出す
            int totalscore = scoreA + scoreB + scoreC + scoreD;

            //GameoverTextに合計値を表示
            this.scoreText.GetComponent<Text>().text = "Your Score is "+ totalscore;
        }
    }

    //衝突時に呼び出される関数
    void OnCollisionEnter() { }
}

