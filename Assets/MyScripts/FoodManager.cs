using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    private static FoodManager _instance;
    public static FoodManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Food Manager is NULL");
            }
            return _instance;
        }
    }

    [SerializeField]
    GameObject _foodContainer;
    [SerializeField]
    GameObject _foodPrefab;
    [SerializeField]
    List<GameObject> _foodPool;
    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        // _foodPool = GenerateFoods(5);
        GenerateFoods_2(5);
    }

    List<GameObject> GenerateFoods(int amountOfFoods)
    {
        for(int i = 0; i < amountOfFoods; i++)
        {
            GameObject food = Instantiate(_foodPrefab) as GameObject;
            food.transform.parent = _foodContainer.transform;
            food.SetActive(false);
            // ここの箇所があるのに, なぜわざわざ２度手間のような記述にしたのか分からない
            _foodPool.Add(food);
        }
        return _foodPool;
    }

    void GenerateFoods_2(int amountOfFoods)
    {
        for(int i = 0; i < amountOfFoods; i++)
        {
            GameObject food = Instantiate(_foodPrefab) as GameObject;
            food.transform.parent = _foodContainer.transform;
            food.SetActive(false);
            _foodPool.Add(food);
        }
    }

    public GameObject RequestFood()
    {
        foreach(var food in _foodPool)
        {
            if(food.activeInHierarchy == false)
            {
                food.SetActive(true);
                return food;
            }
        }

        GameObject newFood = Instantiate(_foodPrefab) as GameObject;
        newFood.transform.parent = _foodContainer.transform;
        _foodPool.Add(newFood);
        return newFood;
    }
}
