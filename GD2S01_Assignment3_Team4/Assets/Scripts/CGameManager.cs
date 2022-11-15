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
    public string DebugGameState = "[Starting]";
    public int StateNum = 0;

    // Hospital Staff:

    //public CAdminNurse nurse;
    //public CRegisteredNurse nurseNeed1;
    //public CRegisteredNurse nurseNeed2;
    //public CRegisteredNurse nurseNeed3;
    //public CDoctor doctorNeed1;
    //public CDoctor doctorNeed2;
    //public CDoctor doctorNeed3;
    //Moved to HospitalFacade class

    // Uses Hospital as a facade to provide a simple interface
    public CHospitalFacade hospital;


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
            DebugGameState = "[Active]";
            StateNum = 1;



        }
        else if (state == gameState.gameOver)
        {
            StateNum = 2;
            DebugGameState = "[Game Over]";
            UnityEngine.Debug.Log("Game Over: ");
            PatientSpawnerScript.m_bIsSpawning = false;
        }

    }
}