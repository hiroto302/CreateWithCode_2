using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    float _horizontalInput;
    float _verticalInput;

    public float speed = 10.0f;
    public float xRange = 10.0f;

    public float zRangeTop = 12.0f;
    public float zRangeBottom = -2.0f;

    // Playerの体力
    public static int  lives = 3;
    // Player が保持してる Score
    public static int score = 0;

    // public GameObject food;

    // 体力とスコアが変化した時発生する event
    public static event Action OnLivesChange;
    public static event Action OnScoreChange;
    public static event Action GameOver;

    void Update()
    {
        ResetPosition();
        MoveHorizontal();
        MoveVertical();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            LaunchFood();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // animal と 衝突した時の処理
        if(other.CompareTag("Animal"))
        {
            DecreaseLives();
        }
    }

    // 横移動
    void MoveHorizontal()
    {
        /*
        The Translate method essentially drags the object through the scene at a particular speed
        regardless of any laws of physics or how heavy it is.
        */
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * _horizontalInput);
    }

    // 縦移動
    void MoveVertical()
    {
        _verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * _verticalInput);
    }

    void ResetPosition()
    {
        if(transform.position.x < -xRange)
        {
            /*
            toransform.positionは、「実体返し」なので下記のような記述はできない
            transform.position.x = 10.0f;
            下記のように、複製した値を他の変数に代入することはできる
            var a = transform.position.x;
            一次変数を扱い、tranform.position を更新する記述
            ゲームオブジェクトのtransform.positionを複製し、posという名前を授ける
            Vector3 pos = transform.position;
            複製したものの、xの値を更新する
            pos.x = -xRange;
            複製したものを実体に返す
            transform.position = pos;
            */
            // 一次変数を介さないで、更新する記述
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Z 方向の行動範囲制限
        if(transform.position.z > zRangeTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeTop);
        }
        if(transform.position.z < zRangeBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeBottom);
        }
    }

    // 体力を減らすメソッド
    public static void DecreaseLives()
    {
        lives --;
        OnLivesChange();
        if(lives <= 0)
        {
            GameOver();
        }
    }

    // スコアーを更新するメソッド
    public static void UpdateScore()
    {
        score ++;
        OnScoreChange();
    }

    // Launch a projectile from the player
    void LaunchFood()
    {
        // Instantiate(food, transform.position, Quaternion.identity);
        GameObject requestFood =  FoodManager.Instance.RequestFood();
        requestFood.transform.position = transform.position;
    }
}
