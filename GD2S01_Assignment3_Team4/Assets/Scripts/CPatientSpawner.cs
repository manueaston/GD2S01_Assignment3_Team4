using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPatientSpawner : MonoBehaviour
{
    private CPatient tempPatient;
    // Stores spawned patient until Need values are initialised

    public CHospitalFacade hospital;
    // Hospital facade, to add patients to queue;

    [SerializeField]
    public CPatientFactory m_factory;

    public float m_SpawnRate = 5.0f;
    private float m_currentTime = 0;
    // changes //
    public int m_iEmergencyQueue = 0;
    public int m_iMaxEmergencyQueue = 10;
    // changes //
    public bool m_bIsSpawning = false;   // associated to game state?

    // Update is called once per frame
    void Update()
    {
        // Only spawn patients if 
        if (m_bIsSpawning == true)
        {
            if ((m_currentTime + m_SpawnRate) < Time.time)
            {
                tempPatient = m_factory.GetSpawnedInstance();
                while(tempPatient.GetPriority() == 0)
                {
                    // Wait for patient Need values to be initialised
                }
                hospital.patientQueue.Enqueue(tempPatient);
                // Adds patient to queue in hospital

                m_iEmergencyQueue = hospital.patientQueue.Count;
                // Gets size of queue, to determine in gamemanager whether queue has grown too large

                Debug.Log("Queue size = " + m_iEmergencyQueue);

                m_currentTime = Time.time;
            }
        }
    }
}
