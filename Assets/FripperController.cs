using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{

    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //タッチされているかの判断
        if (Input.touchCount > 0)
        {
            //スクリーンの右半分をタップした際の処理
            if (Input.mousePosition.x >= Screen.width / 2)
            {
                //タップしたら右フリッパーを動かす
                if (Input.touches[0].phase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                //指を離したら右フリッパーを元に戻す
                if (Input.touches[0].phase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
           
            //右半分以外をタップした際の処理
            else 
            {
                //タップしたら左フリッパーを動かす
                if (Input.touches[0].phase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                //指を離したら左フリッパーを元に戻す
                if (Input.touches[0].phase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }
        //タッチされているかの判断
        if (Input.touchCount > 1)
        {
            if (Input.touches[1].phase == TouchPhase.Began && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            if (Input.touches[1].phase == TouchPhase.Ended && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (Input.touches[1].phase == TouchPhase.Began && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //指を離したら左フリッパーを元に戻す
            if (Input.touches[1].phase == TouchPhase.Ended && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
