using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INurseBehaviour
{
    public IEnumerator AttendToPatient(float _ServiceTime, CPatient _Patient, CHospitalFacade _Hospital, CHealthWorker _ThisNurse);
}
