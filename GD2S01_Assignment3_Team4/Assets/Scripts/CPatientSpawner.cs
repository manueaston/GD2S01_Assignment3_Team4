using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPatientSpawner : MonoBehaviour
{
    public CPatient tempPatientHolder;
    // Holds spawned patient temporarily to be compied into HospitalFacade Patient queue

    public CHospitalFacade hospital;
    // Hospital facade, to add patients to queue;

    [SerializeField]
    private CPatientFactory m_factory;

    private float m_SpawnRate = 5.0f;
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
                tempPatientHolder = m_factory.GetSpawnedInstance();
                hospital.patientQueue.Enqueue(tempPatientHolder);
                // Adds patient to queue in hospital

                m_iEmergencyQueue = hospital.patientQueue.Count;
                // Gets size of queue, to determine in gamemanager whether queue has grown too large
                Debug.Log("Queue size = " + m_iEmergencyQueue);

                m_currentTime = Time.time;
            }
        }
    }
}
