using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHospitalFacade : MonoBehaviour
{
    public CAdminNurse nurseAdmin;
    public CRegisteredNurse nurseNeed1;
    public CRegisteredNurse nurseNeed2;
    public CRegisteredNurse nurseNeed3;
    public CDoctor doctorNeed1;
    public CDoctor doctorNeed2;
    public CDoctor doctorNeed3;

    public Queue<CPatient> patientQueue;

    //


    // Start is called before the first frame update
    void Start()
    {
       
    }

    void AdmitPatient(ref CPatient _newPatient) // takes in a reference to a patient
    {
        nurseAdmin.patient = _newPatient;
        nurseAdmin.triagePatient();
    }

}
