using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CRegisteredNurse : CHealthWorker
{
    /***********************************************
    * name of the function: TriagePatient
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but checks
    * priority of patient to determine whether nurse
    * or doctor must attend patient
    ************************************************//*
    public void triagePatient()
    {
        Debug.Log("Nurse Triaging Patient");
        if (patient.GetNeed().m_Priority == 1)
        {
            attendToPatient();
        }
        else
        {
            referPatientToDoctor();
        }
    }*/


    /***********************************************
    * name of the function: attendToPatient
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but calls 
    * releasPatient() function at end
    ************************************************/
    public override IEnumerator AttendToPatient()
    {
        UnityEngine.Debug.Log("Nurse Attending to Patient");

        yield return new WaitForSeconds(m_ServiceTime);

        hospital.ReleasePatient(patient); // release after patient is attended to
        patient = null;
        patientBeingServiced = false;
    }


    /***********************************************
    * name of the function: referPatientToDoctor
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but sets doctor
    * patient to current patient when doctor has no
    * current patient
    ************************************************//*
    public void referPatientToDoctor()
    {
        Debug.Log("Nurse Refering Patient To Doctor");

        // TODO: choose specific doctor based on patient needs

        while (doctor.patient != null)
        {
            // wait for doctor to be free
        }
        doctor.patient = patient;
        patient = null;
        // pass on patient to doctor
    }*/
}
