using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedAnimalFromRightSide : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    float _lowBound = 25.0f;

    void Update()
    {
        MoveForward();
        DestroyOutOfBounds();
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        other.gameObject.SetActive(false);
    }
    void MoveForward()
    {
        transform.Translate( Vector3.forward * Time.deltaTime * _speed);
    }
    void DestroyOutOfBounds()
    {
        if(transform.position.x > _lowBound)
        {
            Destroy(this.gameObject);
        }
    }
}
