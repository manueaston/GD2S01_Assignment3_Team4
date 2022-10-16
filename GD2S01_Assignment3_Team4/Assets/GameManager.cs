using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Array of Patients
    public GameObject Patient;
    //public Patient[] Patients;

    // ED Queue
    public int m_iEmergencyQueue = 0;
    public int m_iMaxEmergencyQueue = 10;
    // Rate that CPatients spawn into the game
    public float m_fSpawnRate = 30.0f;
    public enum gameState { gameStart, gameOver };          // bool?
    // Intialise game state
    private gameState state = gameState.gameStart;

    // Hospital Staff:
    public Nurse nurse;
    public Doctor doctorNeed1;
    public Doctor doctorNeed2;
    public Doctor doctorNeed3;


    // Start is called before the first frame update
    void Start()
    {
        // Intialise game state
        state = gameState.gameStart;
        Debug.Log("Game Starting: ");
    }

    // Update is called once per frame
    void Update()
    {
        if (state == gameState.gameStart)
        {
            Debug.Log("Game State = gameStart: ");
            //spawn patients
            StartCoroutine(spawnWave());

            // Nurse gets patient at top of list
            if (nurse.patient == null)
            {
                //nurse.patient = Patients[0]
            }
        }
        else if (state == gameState.gameOver)
        {
            //Debug.Log("Game Over: ");
            StopCoroutine(spawnWave());
        }

        if (m_iEmergencyQueue == m_iMaxEmergencyQueue)
        {
            // Lose condition
            state = gameState.gameOver;
            Debug.Log("Game Over: ");
        }


    }

    //BUGGED:: Need to work out how to utilise IEnumerator to use
    // m_fSpawnRate as spawning is instant as per framerate?


    IEnumerator spawnWave()
    {
        //Debug.Log("Spawning a patient: ");

        for (int i = 0; i < m_iMaxEmergencyQueue; i++)
        {
            // called spawnPatient function
            spawnPatient();
            yield return new WaitForSeconds(m_fSpawnRate);
        }

        yield break;
    }

    /***********************************************
    * name of the function: spawnPatient
    * @author: Will Fowlds
    * @parameter: N/A
    * @return: Function has no return but instantiates
    * a patient, increases the ED queue by one if 
    * the ED queue is not at capacity
    ************************************************/

    void spawnPatient()
    {
        while (m_iEmergencyQueue < m_iMaxEmergencyQueue)
        {
            for (int i = 0; i < m_iMaxEmergencyQueue; i++)
            {
                // Debug.Log("Spawning a patient: ");
                // Instantiate a Patient
                Instantiate(Patient);
                m_iEmergencyQueue++;
                Debug.Log(m_iEmergencyQueue);

            }
        }
    }
}