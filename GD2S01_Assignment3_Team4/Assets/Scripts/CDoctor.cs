using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDoctor : CHealthWorker
{
    // TODO: NeedType m_Specialisation


    /***********************************************
    * name of the function: attendToPatient
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but calls 
    * releasPatient() function at end
    ************************************************/
    public override IEnumerator AttendToPatient()
    {
        Debug.Log("Doctor Attending to Patient");

        yield return new WaitForSeconds(m_ServiceTime);

        hospital.ReleasePatient(patient); // release after patient is attended to
        patient = null;
        patientBeingServiced = false;
    }
}
