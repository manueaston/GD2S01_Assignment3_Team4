using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPatientSpawner : MonoBehaviour
{
    public GameObject[] Patients;

    [SerializeField]
    private CPatientFactory m_factory;

    private float m_SpawnRate = 5.0f;
    private float m_currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        if ((m_currentTime + m_SpawnRate) < Time.time)
        {
            m_factory.GetSpawnedInstance();
            m_currentTime = Time.time;
        }

    }
}
