using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CHealthWorker : MonoBehaviour
{
    public CPatient patient;
    public float m_ServiceTime;

    public CHospitalFacade hospital;
    // Hospital facade

    public bool patientBeingServiced = false; // Used to check if healthworker is currently servicing a patient


    // Update is called once per frame
    void Update()
    {
        if (!patientBeingServiced)
        {
            if (patient ?? false) // true if patient has CPatient object
            {
                patientBeingServiced = true;
                StartCoroutine(AttendToPatient());
            }
        }
    }

    private void Awake()
    {
        patient = null;
        // starts with no patient referenced
    }

    public abstract IEnumerator AttendToPatient();
    // to be overridden in derived classes, depending on how they attend to patient

}
