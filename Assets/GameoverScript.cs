using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverScript : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //得点を表示するテキスト
    private GameObject gameoverText;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合の処理
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextに合計値を表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
}
