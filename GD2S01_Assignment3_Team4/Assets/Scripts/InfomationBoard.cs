using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InfomationBoard : MonoBehaviour
{

    
    [Header("Queue")]
    public Text QueueUpdate;
    public int QueueNum = 0;

    [Header("Nurses")]
    public Text AdminNurse;

    public Text Nurse1;
    public Text Nurse1Time;

    public Text Nurse2;
    public Text Nurse2Time;

    public Text Nurse3;
    public Text Nurse3Time;


    private int Nurse1Num, Nurse2Num, Nurse3Num;
    public bool Nur1 = false;
    public bool Nur2 = false;
    public bool Nur3 = false;


    [Header("Doctors")]
    public Text Doctor1;
    public Text Doctor1Time;
    
    public Text Doctor2;
    public Text Doctor2Time;

    public Text Doctor3;
    public Text Doctor3Time;
   
    private int Doctor1Num, Doctor2Num, Doctor3Num;
    public bool Doc1 = false;
    public bool Doc2 = false;
    public bool Doc3 = false;
    

    [Header("Released Patients")]
    public Text PatientReleased;
    public int ReleasedNum;

    [Header("Game Status")]
    public Text GameState;
    public string StateOfGame = "[Starting]";
    private int DebugStateNum;

   

    CHospitalFacade DebugHospitalFacade;
    CHospitalFacade DebugDoctors;
    CHospitalFacade DebugNurse;
    CPatientSpawner DebugQueue;
    CGameManager DebugGameManager;
    CHealthWorker HealthWorker;




    // Start is called before the first frame update
    void Start()
    {
        DebugHospitalFacade = GameObject.FindGameObjectWithTag("Tag_HospitalFacade").GetComponent<CHospitalFacade>();
        ReleasedNum = 0;

        

        DebugQueue = GameObject.FindGameObjectWithTag("Tag_PatientSpawner").GetComponent<CPatientSpawner>();
        QueueNum = 0;


        DebugGameManager = GameObject.FindGameObjectWithTag("Tag_GameManager").GetComponent<CGameManager>();
        StateOfGame = "[Starting]";
        DebugStateNum = 0;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(QueueNum != DebugQueue.m_iEmergencyQueue)
        {
            QueueNum = DebugQueue.m_iEmergencyQueue;
        }
        QueueUpdate.text = "Queue Size:" + QueueNum.ToString();

        if(DebugHospitalFacade.ReleasedCount != ReleasedNum)
        {
            ReleasedNum = DebugHospitalFacade.ReleasedCount;
        }
        PatientReleased.text = "Patients Released:" + ReleasedNum.ToString();

        if(DebugStateNum == DebugGameManager.StateNum)
        {
            StateOfGame = DebugGameManager.DebugGameState;
        }
        else
        {
            DebugStateNum = DebugGameManager.StateNum;
        }
        GameState.text = "Game State: " + StateOfGame.ToString();


        if (Doctor1Num != DebugHospitalFacade.DoctorSeen1)
        {
            Doctor1Num = DebugHospitalFacade.DoctorSeen1;
        }
        Doctor1.text = "Doctor 1: Seen " + Doctor1Num.ToString() + " Patients";

        if (Doc1)
        {
            Doctor1Time.text = "[    Finished Shift   ]".ToString();
        }
        else
        {
            Doctor1Time.text = "[Currently On Shift]".ToString();
        }


        if (Doctor2Num != DebugHospitalFacade.DoctorSeen2)
        {
            Doctor2Num = DebugHospitalFacade.DoctorSeen2;
        }
        Doctor2.text = "Doctor 2: Seen " + Doctor2Num.ToString() + " Patients";
       
        if (Doc2)
        {
            Doctor2Time.text = "[    Finished Shift   ]".ToString();
        }
        else
        {
            Doctor2Time.text = "[Currently On Shift]".ToString();
        }
        

        if (Doctor3Num != DebugHospitalFacade.DoctorSeen3)
        {
            Doctor3Num = DebugHospitalFacade.DoctorSeen3;
        }
        Doctor3.text = "Doctor 3: Seen " + Doctor3Num.ToString() + " Patients";

        if (Doc3)
        {
            Doctor3Time.text = "[    Finished Shift   ]".ToString();
        }
        else
        {
            Doctor3Time.text = "[Currently On Shift]".ToString();
        }


        if (Nurse1Num != DebugHospitalFacade.NurseSeen1)
        {
            Nurse1Num = DebugHospitalFacade.NurseSeen1;
        }
        Nurse1.text = "Nurse 1: Seen " + Nurse1Num.ToString() + " Patients";
       
        if (Nur1)
        {
            Nurse1Time.text = "[    Finished Shift   ]".ToString();
        }
        else
        {
            Nurse1Time.text = "[Currently On Shift]".ToString();
        }


        if (Nurse2Num != DebugHospitalFacade.NurseSeen2)
        {
            Nurse2Num = DebugHospitalFacade.NurseSeen2;
        }
        Nurse2.text = "Nurse 2: Seen " + Nurse2Num.ToString() + " Patients";
       
        if (Nur2)
        {
            Nurse2Time.text = "[    Finished Shift   ]".ToString();
        }
        else
        {
            Nurse2Time.text = "[Currently On Shift]".ToString();
        }


        if (Nurse3Num != DebugHospitalFacade.NurseSeen3)
        {
            Nurse3Num = DebugHospitalFacade.NurseSeen3;
        }
        Nurse3.text = "Nurse 3: Seen " + Nurse3Num.ToString() + " Patients";
        
        if (Nur3)
        {
            Nurse3Time.text = "[    Finished Shift   ]".ToString();
        }
        else
        {
            Nurse3Time.text = "[Currently On Shift]".ToString();
        }



    }





}

