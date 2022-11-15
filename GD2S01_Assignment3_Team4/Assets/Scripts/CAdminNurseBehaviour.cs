using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAdminNurseBehaviour : MonoBehaviour, INurseBehaviour
{
    // must be a class to use coroutines
    public IEnumerator AttendToPatient(float _ServiceTime, CPatient _Patient, CHospitalFacade _Hospital, CHealthWorker _ThisNurse)
    {
        UnityEngine.Debug.Log(gameObject.name + " Triaging Patient");

        yield return new WaitForSeconds(_ServiceTime);

        if (_Patient.GetPriority() == 1)
        {
            StartCoroutine(_Hospital.ReferPatientToNurse(_Patient.GetNeedType()));
        }
        else
        {
            StartCoroutine(_Hospital.ReferPatientToDoctor(_Patient.GetNeedType()));
        }
    }
}
