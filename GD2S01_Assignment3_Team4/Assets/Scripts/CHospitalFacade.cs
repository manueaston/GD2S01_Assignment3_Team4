using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Serves as a facade to simplify the complex interactions between doctors, nurses and patients
public class CHospitalFacade : MonoBehaviour
{
    public CAdminNurse nurseAdmin;
    public CRegisteredNurse nurseNeed1;
    public CRegisteredNurse nurseNeed2;
    public CRegisteredNurse nurseNeed3;
    public CDoctor doctorNeed1;
    public CDoctor doctorNeed2;
    public CDoctor doctorNeed3;

    public Queue<CPatient> patientQueue;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (nurseAdmin.patient??false && patientQueue.Count != 0) // ??false used because == null does not work in unity
        {
            AdmitPatient(patientQueue.Dequeue());
        }
    }

    void AdmitPatient(CPatient _newPatient) // takes in a new patient from the queue
    {
        nurseAdmin.patient = _newPatient;
        nurseAdmin.triagePatient();
    }

    public void ReferPatientToDoctor(NeedType _type)
    {
        switch (_type)
        {
            case NeedType.Type1:
                {
                    AssignPatient(doctorNeed1, nurseAdmin.patient);
                    Debug.Log("Patient assigned to doctor 1");
                    break;
                }
            case NeedType.Type2:
                {
                    AssignPatient(doctorNeed2, nurseAdmin.patient);
                    Debug.Log("Patient assigned to doctor 2");
                    break;
                }
            case NeedType.Type3:
                {
                    AssignPatient(doctorNeed3, nurseAdmin.patient);
                    Debug.Log("Patient assigned to doctor 3");
                    break;
                }
        }
        nurseAdmin.patient = null;
    }

    public void ReferPatientToNurse(NeedType _type)
    {
        switch (_type)
        {
            case NeedType.Type1:
                {
                    AssignPatient(nurseNeed1, nurseAdmin.patient);
                    Debug.Log("Patient assigned to nurse 1");
                    break;
                }
            case NeedType.Type2:
                {
                    AssignPatient(nurseNeed2, nurseAdmin.patient);
                    Debug.Log("Patient assigned to nurse 2");
                    break;
                }
            case NeedType.Type3:
                {
                    AssignPatient(nurseNeed3, nurseAdmin.patient);
                    Debug.Log("Patient assigned to nurse 3");
                    break;
                }
        }
        nurseAdmin.patient = null;
    }

    void AssignPatient(CHealthWorker _healthWorker, CPatient _patient)
    {
        while (_healthWorker.patient??true)
        {
            // wait for healthWorker to be free
        }
        _healthWorker.patient = _patient;
    }


    public void ReleasePatient(CPatient _patient)
    {
        _patient.SetPriority(0);
        Destroy(_patient);
        // destroys patient from game
        Debug.Log("Patient released from hospital");
    }

}
