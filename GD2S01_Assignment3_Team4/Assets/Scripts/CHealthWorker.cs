using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CHealthWorker : MonoBehaviour
{
    public CPatient patient;

    private void Awake()
    {
        patient = null;
        // starts with no patient referenced
    }

    public abstract void attendToPatient();
    // to be overridden in derived classes, depending on how they attend to patient


    /***********************************************
    * name of the function: releasePatient
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but sets patient
    * in HealthWorker object to null
    ************************************************/
    public void releasePatient()
    {
        Debug.Log("Releasing Patient");
        // sets priority to 0, so that patient will be released from the hospital
        patient.SetPriority(0);
        patient = null;
    }
}
