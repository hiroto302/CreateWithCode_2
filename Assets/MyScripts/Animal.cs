﻿using System.Collections;
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
        // Destroy(other.gameObject);
    }
    void MoveForward()
    {
        transform.Translate( Vector3.forward * Time.deltaTime * _speed);
    }
    void DestroyOutOfBounds()
    {
        if(transform.position.z < _lowBound)
        {
            Destroy(this.gameObject);
            // Debug.Log("game over");
        }
    }
}
