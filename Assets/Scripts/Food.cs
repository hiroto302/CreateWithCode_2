using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed = 40.0f;

    float _topBound = 30.0f;

    void Update()
    {
        MoveForward();
        DestroyOutOfBounds();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void DestroyOutOfBounds()
    {
        if(transform.position.z > _topBound)
        {
            Destroy(this.gameObject);
        }
    }
}
