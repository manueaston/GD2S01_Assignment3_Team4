using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPatientSpawner : MonoBehaviour
{
    public CPatient tempPatientHolder;
    // Holds spawned patient temporarily to be compied into HospitalFacade Patient queue

    public CHospitalFacade hospital;

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

                //UnityEngine.Debug.Log(Patients.GetLength());

                m_iEmergencyQueue++;
                m_currentTime = Time.time;
            }
        }
    }
}
