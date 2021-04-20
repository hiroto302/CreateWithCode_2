using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;

    public GameObject food;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetPosition();
        MoveHorizontal();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            LaunchFood();
        }
    }


    void MoveHorizontal()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * _horizontalInput);
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
    }

    // Launch a projectile from the player
    void LaunchFood()
    {
        Instantiate(food, transform.position, Quaternion.identity);
    }
}
