using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDoctor : CHealthWorker
{
    void Start()
    {
        // shift in random range from 20 - 30 seconds
        m_ShiftLength = Random.Range(20, 30);
    }

    public override IEnumerator AttendToPatient()
    {
        Debug.Log(gameObject.name + " Attending to Patient");

        yield return new WaitForSeconds(m_ServiceTime);

        hospital.ReleasePatient(this, patient); // release after patient is attended to
    }
}
