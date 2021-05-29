using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    void Start()
    {
        PlayerController.OnLivesChange += HandleLivesChange;
        PlayerController.OnScoreChange += HandleScoreChange;
        PlayerController.GameOver += HandleGameOver;

        Debug.Log("Lives : " + PlayerController.lives);
        Debug.Log("Score : " + PlayerController.score);
    }

    void HandleLivesChange()
    {
        Debug.Log("Lives : " + PlayerController.lives);
    }

    void HandleScoreChange()
    {
        Debug.Log("Score : " + PlayerController.score);
    }

    void HandleGameOver()
    {
        Debug.Log("GAME OVER");
    }

    void Update()
    {
        // Debug.Log(PlayerController.score);
        // Debug.Log(PlayerController.lives);
        // if(PlayerController.lives <=0)
        // {
        //     Debug.Log("GameOver");
        // }
    }
}
