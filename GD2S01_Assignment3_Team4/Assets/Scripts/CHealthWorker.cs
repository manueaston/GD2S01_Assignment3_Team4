using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CHealthWorker : MonoBehaviour
{
    public CPatient patient;
    public float m_fServiceTime;
    private float m_currentTime = 0;

    public CHospitalFacade hospital;
    // Hospital facade

    /*use Time.time(which tracks the total elapsed time since app or level startup - can't remember which) 
       or Time.deltaTime (which is the time elapsed since the last update).*/


    // Update is called once per frame
    void Update()
    {
    }



    private void Awake()
    {
        patient = null;
        // starts with no patient referenced
        m_fServiceTime = m_fServiceTime;
    }

    public abstract void attendToPatient(float _serviceTime);
    // to be overridden in derived classes, depending on how they attend to patient


    /***********************************************
    * name of the function: releasePatient
    * @author: Manu Easton
    * @parameter: N/A
    * @return: Function has no return but sets patient
    * in HealthWorker object to null
    ************************************************/
    //public void releasePatient()
    //{
    //    UnityEngine.Debug.Log("Releasing Patient");
    //    // sets priority to 0, so that patient will be released from the hospital
    //    patient.SetPriority(0);
    //    patient = null;
    //}

    // Moved to hospital facade class
}
