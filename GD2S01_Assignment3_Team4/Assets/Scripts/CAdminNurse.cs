using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CAdminNurse : CHealthWorker
{

    /***********************************************
    * name of the function: TriagePatient
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but checks
    * priority of patient to determine whether nurse
    * or doctor must attend patient
    ************************************************/
    //public void triagePatient()
    //{
    //    UnityEngine.Debug.Log("Nurse Triaging Patient");
    //    if (patient.GetPriority() == 1)
    //    {
    //        hospital.ReferPatientToNurse(patient.GetNeedType());
    //    }
    //    else
    //    {
    //        hospital.ReferPatientToDoctor(patient.GetNeedType());
    //    }
    //}
    // Swapped to AttendToPatient function for admin nurse


    /***********************************************
    * name of the function: attendToPatient
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but calls 
    * releasPatient() function at end
    ************************************************/
    public override IEnumerator AttendToPatient()
    {
        UnityEngine.Debug.Log("Nurse Triaging Patient");

        yield return new WaitForSeconds(m_ServiceTime);

        if (patient.GetPriority() == 1)
        {
            StartCoroutine(hospital.ReferPatientToNurse(patient.GetNeedType()));
        }
        else
        {
            StartCoroutine(hospital.ReferPatientToDoctor(patient.GetNeedType()));
        }
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
    //    UnityEngine.Debug.Log("Nurse Refering Patient To Doctor");

    //    // TODO: choose specific doctor based on patient needs

    //    while (doctor.patient != null)
    //    {
    //        // wait for doctor to be free
    //    }
    //    doctor.patient = patient;
    //    patient = null;
    //    // pass on patient to doctor
    //}
    
    // Now done in hospital interface
}
