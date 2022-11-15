using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CHealthWorker : MonoBehaviour
{
    public CPatient patient;
    public float m_ServiceTime;
    protected float m_ShiftLength;
    private float m_ShiftStartTime;

    public CHospitalFacade hospital;
    // Hospital facade

    public bool patientBeingServiced = false; // Used to check if healthworker is currently servicing a patient
    private bool healthWorkerSwitching = false;

    void Start()
    {
        m_ShiftStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!patientBeingServiced && !healthWorkerSwitching) // does not continue if health worker is attending to a patient or is finishing their shift
        {
            // check if shift is over
            if (Time.time - m_ShiftStartTime >= m_ShiftLength)
            {
                // health worker switch over
                StartCoroutine(SwitchStaff());
                healthWorkerSwitching = true;
            }
            else if (patient ?? false) // true if patient has CPatient object
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


    // deactivates health worker for 2 seconds, then reactivates, representing staff switch over
    private IEnumerator SwitchStaff()
    {
        Debug.Log(gameObject.name + " has finished their shift");
        yield return new WaitForSeconds(2);
        Debug.Log("New " + gameObject.name + " has started their shift");

        // reset shift start time
        m_ShiftStartTime = Time.time;
        healthWorkerSwitching = false;
    }
}
