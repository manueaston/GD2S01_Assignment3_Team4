using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNurse : CHealthWorker
{

    /***********************************************
    * name of the function: TriagePatient
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but checks
    * priority of patient to determine whether nurse
    * or doctor must attend patient
    ************************************************/
    public void triagePatient()
    {
        Debug.Log("Nurse Triaging Patient");
        if (patient.GetNeed().m_Priority == 1)
        {
            hospital.ReferPatientToNurse(patient.GetNeedType());
        }
        else
        {
            hospital.ReferPatientToDoctor(patient.GetNeedType());
        }
    }


    /***********************************************
    * name of the function: attendToPatient
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but calls 
    * releasPatient() function at end
    ************************************************/
    public override IEnumerator attendToPatient(float _serviceTime)
    {
        Debug.Log("Nurse Attending to Patient");

        // Service Time
        yield return new WaitForSeconds(_serviceTime);

        hospital.ReleasePatient(patient); // release after patient is attended to
        patient = null;
    }


    /***********************************************
    * name of the function: referPatientToDoctor
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but sets doctor
    * patient to current patient when doctor has no
    * current patient
    ************************************************/
    //public void referPatientToDoctor()
    //{
    //    Debug.Log("Nurse Refering Patient To Doctor");

    //    // TODO: choose specific doctor based on patient needs

    //    while(doctor.patient != null)
    //    {
    //        // wait for doctor to be free
    //    }
    //    doctor.patient = patient;
    //    patient = null;
    //    // pass on patient to doctor
    //}

    // Refactor using interface strategy
}
