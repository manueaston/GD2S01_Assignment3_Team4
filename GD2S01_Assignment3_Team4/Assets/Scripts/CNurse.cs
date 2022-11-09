using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNurse : CHealthWorker
{
    public INurseBehaviour nurseBehaviour;

    public override IEnumerator AttendToPatient()
    {
        StartCoroutine(nurseBehaviour.AttendToPatient(m_ServiceTime, patient, hospital, this));
        yield return null;
    }

    public SetBehaviour(INurseBehaviour _newNurseBehaviour)
    {
        nurseBehaviour = _newNurseBehaviour;
    }
}
