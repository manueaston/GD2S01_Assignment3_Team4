using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CNurse : CHealthWorker
{
    public INurseBehaviour nurseBehaviour;

    void Start()
    {
        nurseBehaviour = (INurseBehaviour)GetComponent(typeof(INurseBehaviour)); // Gets behaviour component
    }

    public override IEnumerator AttendToPatient()
    {
        StartCoroutine(nurseBehaviour.AttendToPatient(m_ServiceTime, patient, hospital, this));
        yield return null;
    }
}
