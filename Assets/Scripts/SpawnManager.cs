using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int _spawnRangeX = 20;
    int _spawnRangeZ = 20;
    public GameObject[] animals = new GameObject[3];

    float _startDelay = 2.0f;
    float _spawnIntervel = 1.0f;
    void Start()
    {
        // Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
        InvokeRepeating("SpawnAnimal", _startDelay, _spawnIntervel);
    }

    void Update()
    {
        
    }

    void SpawnAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnRangeZ);
        int randomIndex = Random.Range(0,animals.Length);
        Instantiate(animals[randomIndex], spawnPos, animals[randomIndex].transform.rotation);
    }
}
