using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{
    //public GameObject Patient;

    // Queue
    // public int m_iEmergencyQueue = 0;
    // public int m_iMaxEmergencyQueue = 10;

    public enum gameState { gameStart, gameOver };    
    // Intialise game state
    private gameState state = gameState.gameStart;

    // Start is called before the first frame update
    void Start()
    {
        if (state == gameState.gameStart)
        {
            UnityEngine.Debug.Log("Game State = gameStart: ");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}