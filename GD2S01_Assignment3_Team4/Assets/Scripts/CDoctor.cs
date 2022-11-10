using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDoctor : CHealthWorker
{
    public override IEnumerator AttendToPatient()
    {
        Debug.Log("Doctor Attending to Patient");

        yield return new WaitForSeconds(m_ServiceTime);

        hospital.ReleasePatient(this, patient); // release after patient is attended to
    }
}
