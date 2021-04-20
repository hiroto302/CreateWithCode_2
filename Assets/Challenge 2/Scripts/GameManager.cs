using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("The GameManager NULL");
            }
            return _instance;
        }
    }
    // ボールが落ちていい回数
    [SerializeField]
    private int _dropCount = 10;
    public int DropCount
    {
        get
        {
            return _dropCount;
        }
        set
        {
            _dropCount = value;
            if(_dropCount <= 0)
            {
                Debug.Log("GameOver");
            }
        }
    }
    void Awake()
    {
        _instance = this;
    }
}
