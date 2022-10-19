using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CGameManager : MonoBehaviour
{
    // Access to Spawner script to start/ stop spawning patients
    public CPatientSpawner PatientSpawnerScript;

    // ED Queue
    //public int m_iEmergencyQueue = 0;
    //public int m_iMaxEmergencyQueue = 10;

    public enum gameState { gameStart, gameOver };
    // Intialise game state
    private gameState state = gameState.gameStart;


    // Hospital Staff:
    //public CNurse nurse;
    //public CDoctor doctorNeed1;
    //public CDoctor doctorNeed2;
    //public CDoctor doctorNeed3;



    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Game Starting: ");
    }

    // Update is called once per frame
    void Update()
    {

        if (PatientSpawnerScript.m_iEmergencyQueue == PatientSpawnerScript.m_iMaxEmergencyQueue)
        {
            // Lose condition
            state = gameState.gameOver;
        }

        if (state == gameState.gameStart)
        {
            // spawn patients
            PatientSpawnerScript.m_bIsSpawning = true;


            // Nurse gets patient at top of list
            /*if (nurse.patient == null)
            {
                //nurse.patient = Patients[0]
            }*/
        }
        else if (state == gameState.gameOver)
        {
            UnityEngine.Debug.Log("Game Over: ");
            PatientSpawnerScript.m_bIsSpawning = false;
        }

    }
}