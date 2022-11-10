using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCheckUpNurseBehaviour : MonoBehaviour, INurseBehaviour
{
    // must be a class to use coroutines
    public IEnumerator AttendToPatient(float _ServiceTime, CPatient _Patient, CHospitalFacade _Hospital, CHealthWorker _ThisNurse)
    {
        UnityEngine.Debug.Log(gameObject.name + " Attending to Patient");

        yield return new WaitForSeconds(_ServiceTime);

        _Hospital.ReleasePatient(_ThisNurse, _Patient); // release after patient is attended to
    }
}
