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

    public Queue<CPatient> patientQueue = new Queue<CPatient>();
    // Queue of patients at hospital

    void Update()
    {
        if (nurseAdmin.patient??true && patientQueue.Count > 0) // nurseAdmin??true returns true if nurseAdmin evaluates to null
        {
            AdmitPatient(patientQueue.Dequeue());
        }
    }

    /***********************************************
    * name of the function: AdmitPatient
    * @author: Manu Easton
    * @parameter: CPatient
    * @return: Sets nurseAdmin to new patient at 
    *          front of queue, and calls 
    *          triagePatient()
    ************************************************/
    void AdmitPatient(CPatient _newPatient) // takes in a new patient from the queue
    {
        nurseAdmin.patient = _newPatient;
        nurseAdmin.triagePatient();
    }

    /***********************************************
    * name of the function: ReferPatientToNurse
    * @author: Manu Easton
    * @parameter: NeedType
    * @return: Assigns patient to relevant nurse
    *          depending on patient NeedType. Sets
    *          nurseAdmin patient to null, to take
    *          new patient
    ************************************************/
    public void ReferPatientToDoctor(NeedType _type)
    {
        switch (_type)
        {
            case NeedType.Type1:
                {
                    Debug.Log("Patient assigned to doctor 1");
                    StartCoroutine(AssignPatient(doctorNeed1, nurseAdmin.patient));                   
                    break;
                }
            case NeedType.Type2:
                {
                    Debug.Log("Patient assigned to doctor 2");
                    StartCoroutine(AssignPatient(doctorNeed2, nurseAdmin.patient));                    
                    break;
                }
            case NeedType.Type3:
                {
                    Debug.Log("Patient assigned to doctor 3");
                    StartCoroutine(AssignPatient(doctorNeed3, nurseAdmin.patient));                    
                    break;
                }
        }
        nurseAdmin.patient = null;
    }

    /***********************************************
    * name of the function: ReferPatientToNurse
    * @author: Manu Easton
    * @parameter: NeedType
    * @return: Assigns patient to relevant doctor
    *          depending on patient NeedType. Sets
    *          nurseAdmin patient to null, to take
    *          new patient
    ************************************************/
    public void ReferPatientToNurse(NeedType _type)
    {
        switch (_type)
        {
            case NeedType.Type1:
                {
                    Debug.Log("Patient assigned to nurse 1");
                    StartCoroutine(AssignPatient(nurseNeed1, nurseAdmin.patient));                 
                    break;
                }
            case NeedType.Type2:
                {
                    Debug.Log("Patient assigned to nurse 2");
                    StartCoroutine(AssignPatient(nurseNeed2, nurseAdmin.patient));
                    break;
                }
            case NeedType.Type3:
                {
                    Debug.Log("Patient assigned to nurse 3");
                    StartCoroutine(AssignPatient(nurseNeed3, nurseAdmin.patient));                   
                    break;
                }
        }
        nurseAdmin.patient = null;
    }

    /***********************************************
    * name of the function: AssignPatient
    * @author: Manu Easton
    * @parameter: CHealthWorker, CPatient
    * @return: loops until _healthworker has no 
    *          assigned patient, then assigns 
    *          _patient to _healthWorker
    ************************************************/
    IEnumerator AssignPatient(CHealthWorker _healthWorker, CPatient _patient)
    {
        yield return new WaitUntil(() =>_healthWorker ?? true);
        _healthWorker.patient = _patient;
    }
   
    /***********************************************
    * name of the function: ReleasePatient
    * @author: Manu Easton
    * @parameter: CPatient
    * @return: Sets priority of patient to 0, causing
    *          it to be destroyed from the scene
    ************************************************/
    public void ReleasePatient(CPatient _patient)
    {
        _patient.SetPriority(0);
        // destroys patient from game when priority is 0
        Debug.Log("Patient released from hospital");
    }

}
