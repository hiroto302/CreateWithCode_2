using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    float _lowBound = -10.0f;

    // Animal の腹の空き具合を表すバー
    [SerializeField]
    Slider _hungerBar = null;
    // 餌が与えらた時の満たされる値
    [SerializeField]
    float satisfiedValue = 0.5f;

    void Reset()
    {
        _hungerBar = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        MoveForward();
        DestroyOutOfBounds();
    }

    void OnTriggerEnter(Collider other)
    {
        // Destroy(this.gameObject);
        other.gameObject.SetActive(false);
        // Playerのスコアをあげる
        PlayerController.UpdateScore();
        // 食べた分腹を満たす
        _hungerBar.value += satisfiedValue;
        if(_hungerBar.value >= 1)
        {
            StartCoroutine(DestroyRoutine());
        }

        // Destroy(other.gameObject);
    }

    //
    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
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
