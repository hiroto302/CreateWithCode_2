using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    float _lowBound = -10.0f;


    void Update()
    {
        MoveForward();
        DestroyOutOfBounds();
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        other.gameObject.SetActive(false);
        // Playerのスコアをあげる
        PlayerController.UpdateScore();
        // Destroy(other.gameObject);
    }
    void MoveForward()
    {
        transform.Translate( Vector3.forward * Time.deltaTime * _speed);
    }
    void DestroyOutOfBounds()
    {
        // 範囲外に達した時の処理
        if(transform.position.z < _lowBound)
        {
            Destroy(this.gameObject);
            // PlayerのLives を減少させる
            PlayerController.DecreaseLives();

            // Debug.Log("game over");
        }
    }
}
