using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Serves as a facade to simplify the complex interactions between doctors, nurses and patients
public class CHospitalFacade : MonoBehaviour
{
    public CAdminNurse nurseAdmin;
    public CCheckUpNurse nurseNeed1;
    public CCheckUpNurse nurseNeed2;
    public CCheckUpNurse nurseNeed3;
    public CDoctor doctorNeed1;
    public CDoctor doctorNeed2;
    public CDoctor doctorNeed3;
    
    public Queue<CPatient> patientQueue = new Queue<CPatient>();
    // Queue of patients at hospital

    public int ReleasedCount = 0;
    public int DoctorSeen1, DoctorSeen2, DoctorSeen3;
    public int NurseSeen1, NurseSeen2, NurseSeen3;

    void Update()
    {
        if (patientQueue.Count > 0)
        {
            if (nurseAdmin.patient is null)
            {
                AdmitPatient(patientQueue.Dequeue());
            }
        }
    }

    /***********************************************
    * name of the function: AdmitPatient
    * @author: Manu Easton
    * @parameter: CPatient
    * @return: Sets nurseAdmin to new patient at 
    *          front of queue
    ************************************************/
    void AdmitPatient(CPatient _newPatient) // takes in a new patient from the queue
    {
        nurseAdmin.patient = _newPatient;
        //nurseAdmin.triagePatient();
    }

    /***********************************************
    * name of the function: ReferPatientToDoctor
    * @author: Manu Easton
    * @parameter: NeedType
    * @return: Assigns patient to relevant doctor
    *          depending on patient NeedType, when
    *          doctor is free
    ************************************************/
    public IEnumerator ReferPatientToDoctor(NeedType _type)
    {
        switch (_type)
        {
            case NeedType.Type1:
                {
                    yield return new WaitUntil(() => doctorNeed1.patient is null);

                    DoctorSeen1++;
                    Debug.Log("Patient assigned to doctor 1");
                    AssignPatient(doctorNeed1, nurseAdmin.patient);                   
                    break;
                }
            case NeedType.Type2:
                {
                    yield return new WaitUntil(() => doctorNeed2.patient is null);

                    DoctorSeen2++;
                    Debug.Log("Patient assigned to doctor 2");
                    AssignPatient(doctorNeed2, nurseAdmin.patient);                    
                    break;
                }
            case NeedType.Type3:
                {
                    yield return new WaitUntil(() => doctorNeed3.patient is null);


                    DoctorSeen3++;
                    Debug.Log("Patient assigned to doctor 3");
                    AssignPatient(doctorNeed3, nurseAdmin.patient);                    
                    break;
                }
        }
    }

    /***********************************************
    * name of the function: ReferPatientToNurse
    * @author: Manu Easton
    * @parameter: NeedType
    * @return: Assigns patient to relevant nurse
    *          depending on patient NeedType, when
    *          nurse is free
    ************************************************/
    public IEnumerator ReferPatientToNurse(NeedType _type)
    {
        switch (_type)
        {
            case NeedType.Type1:
                {
                    yield return new WaitUntil(() => nurseNeed1.patient is null);

                    Debug.Log("Patient assigned to nurse 1");
                    AssignPatient(nurseNeed1, nurseAdmin.patient);                 
                    break;
                }
            case NeedType.Type2:
                {
                    yield return new WaitUntil(() => nurseNeed2.patient is null);

                    Debug.Log("Patient assigned to nurse 2");
                    AssignPatient(nurseNeed2, nurseAdmin.patient);
                    break;
                }
            case NeedType.Type3:
                {
                    yield return new WaitUntil(() => nurseNeed3.patient is null);

                    Debug.Log("Patient assigned to nurse 3");
                    AssignPatient(nurseNeed3, nurseAdmin.patient);                   
                    break;
                }
        }
    }

    /***********************************************
    * name of the function: AssignPatient
    * @author: Manu Easton
    * @parameter: CHealthWorker, CPatient
    * @return: loops until _healthworker has no 
    *          assigned patient, then assigns 
    *          _patient to _healthWorker
    ************************************************/
    void AssignPatient(CHealthWorker _healthWorker, CPatient _patient)
    {
        nurseAdmin.patient = null;
        nurseAdmin.patientBeingServiced = false;
        _healthWorker.patient = _patient;
    }
   
    /***********************************************
    * name of the function: ReleasePatient
    * @author: Manu Easton
    * @parameter: CPatient
    * @return: Sets priority of patient to 0, causing
    *          it to be destroyed from the scene
    ************************************************/
    public void ReleasePatient(CHealthWorker _healthWorker, CPatient _patient)
    {
        _patient.SetPriority(0);
        // destroys patient from game when priority is 0
        _healthWorker.patient = null;
        _healthWorker.patientBeingServiced = false;
        Debug.Log("Patient released from hospital");

        // Adds A Point For The Canvas Debug Screen
        ReleasedCount++;
    }

}
