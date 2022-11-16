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
    public InfomationBoard InfoBoard;


    public bool patientBeingServiced = false; // Used to check if healthworker is currently servicing a patient
    public bool healthWorkerSwitching = false;

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
    public IEnumerator SwitchStaff()
    {
        if (this == hospital.doctorNeed1)
        {
            InfoBoard.Doc1 = true;
        }
        if (this == hospital.doctorNeed2)
        {
            InfoBoard.Doc2 = true;
        }
        if (this == hospital.doctorNeed3)
        {
            InfoBoard.Doc3 = true;
        }

        if (this == hospital.nurseNeed1)
        {
            InfoBoard.Nur1 = true;
        }
        if (this == hospital.nurseNeed2)
        {
            InfoBoard.Nur2 = true;
        }
        if (this == hospital.nurseNeed3)
        {
            InfoBoard.Nur3 = true;
        }
        Debug.Log(gameObject.name + " has finished their shift");
        yield return new WaitForSeconds(2);
        Debug.Log("New " + gameObject.name + " has started their shift");

        if (this == hospital.doctorNeed1)
        {
            InfoBoard.Doc1 = false;
        }
        if (this == hospital.doctorNeed2)
        {
            InfoBoard.Doc2 = false;
        }
        if (this == hospital.doctorNeed3)
        {
            InfoBoard.Doc3 = false;
        }

        if (this == hospital.nurseNeed1)
        {
            InfoBoard.Nur1 = false;
        }
        if (this == hospital.nurseNeed2)
        {
            InfoBoard.Nur2 = false;
        }
        if (this == hospital.nurseNeed3)
        {
            InfoBoard.Nur3 = false;
        }

        // reset shift start time
        m_ShiftStartTime = Time.time;
        healthWorkerSwitching = false;
       
       
    }
}
