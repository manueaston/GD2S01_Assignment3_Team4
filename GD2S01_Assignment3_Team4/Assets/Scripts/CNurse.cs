using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CNurse : CHealthWorker
{
    public INurseBehaviour nurseBehaviour;

    void Start()
    {
        nurseBehaviour = (INurseBehaviour)GetComponent(typeof(INurseBehaviour)); // Gets behaviour component

        // shift time in random range from 30 - 40 seconds
        m_ShiftLength = Random.Range(30, 40);
    }

    public override IEnumerator AttendToPatient()
    {
        StartCoroutine(nurseBehaviour.AttendToPatient(m_ServiceTime, patient, hospital, this));
        yield return null;
    }
}
