using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int _spawnRangeX = 11;
    int _spawnRangeZ = 20;
    public GameObject[] animals = new GameObject[3];

    public GameObject[] SpawnedAnimalFromLeftSide = new GameObject[3];
    public GameObject[] SpawnedAnimalFromRightSide = new GameObject[3];

    float _startDelay = 2.0f;
    float _spawnIntervel = 1.5f;
    void Start()
    {
        // Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
        InvokeRepeating("SpawnAnimalToTop", _startDelay, _spawnIntervel);
        InvokeRepeating("SpawnAnimalToLeftSide", _startDelay, 2.0f);
        InvokeRepeating("SpawnAnimalToRightSide", _startDelay, 2.0f);
    }   

    // 画面の上部から animal を生み出すメソッド
    void SpawnAnimalToTop()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnRangeZ);
        int randomIndex = Random.Range(0,animals.Length);
        Instantiate(animals[randomIndex], spawnPos, animals[randomIndex].transform.rotation);
    }

    // 画面の左側から animal を生み出すメソッド
    void SpawnAnimalToLeftSide()
    {
        Vector3 spawnPos = new Vector3(_spawnRangeX + 5.0f , 0, Random.Range(-1, 18));
        int randomIndex = Random.Range(0,SpawnedAnimalFromLeftSide.Length);
        Instantiate(SpawnedAnimalFromLeftSide[randomIndex], spawnPos, SpawnedAnimalFromLeftSide[randomIndex].transform.rotation);
    }
    // 画面の右側から animal を生み出すメソッド
    void SpawnAnimalToRightSide()
    {
        Vector3 spawnPos = new Vector3(-_spawnRangeX - 7.0f , 0, Random.Range(-1, 18));
        int randomIndex = Random.Range(0,SpawnedAnimalFromRightSide.Length);
        Instantiate(SpawnedAnimalFromRightSide[randomIndex], spawnPos, SpawnedAnimalFromRightSide[randomIndex].transform.rotation);
    }
}
