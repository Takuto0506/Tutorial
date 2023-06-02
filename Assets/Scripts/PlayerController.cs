using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//追加を使えるようにする

public class PlayerController : MonoBehaviour
{
    public int score = 0;//スコア。本当はよくないけどpublicにします。
    [SerializeField] Text scoreText;//スコア表示用Text
    private float horizontalInput;
    [SerializeField] private float speed;
    [SerializeField] private float xRange;
    [SerializeField] private GameObject projectilePrefab;//食べ物プレハブ（あとで複製）

    private void Start()
    {
        SetCountText(0);//初期化
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput 
                * Time.deltaTime * speed);
        if(transform.position.x < -xRange) {
            transform.position = new Vector3(   -xRange, 
                                                transform.position.y,
                                                transform.position.z);
        }
        if(xRange < transform.position.x ) {
            transform.position = new Vector3(   xRange,
                                                transform.position.y,
                                                transform.position.z);
        }
        //スペースキーが押されたら
        if(Input.GetKeyDown(KeyCode.Space)) {
            //ここで食べ物を複製する（この使い方、というかメソッド名覚えて！）
            Instantiate(    projectilePrefab, 
                            transform.position,
                            projectilePrefab.transform.rotation);
        }

    }

    //SetCountTextをここら辺に書く
    public void SetCountText(int point)
    {
        score += point;//動物からもらったpointを自分のスコアに加算
        scoreText.text = "Score;" + score.ToString();//【重要】UI更新
    }
}
