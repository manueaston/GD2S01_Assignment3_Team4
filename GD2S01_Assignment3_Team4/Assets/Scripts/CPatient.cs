using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NeedType { 
    Type1 = 1,
    Type2 = 2,
    Type3 = 3,
};

public struct Need
{
    public int m_Priority;
    public NeedType m_Type;
};

public class CPatient : MonoBehaviour
{
   
    public GameObject newPatient;
    private Need m_Need;

    // Start is called before the first frame update
    void Start()
    {
        //Set Random Priority
        SetPriority(UnityEngine.Random.Range(0, 3));
        //Set Random Need
        SetNeedType((NeedType)UnityEngine.Random.Range(1, 3));
        
        //GetNeed(needType);
        //UnityEngine.Debug.Log("Patient enters ED: ");
        UnityEngine.Debug.Log("Patient Priority : " + m_Need.m_Priority + "||Patient Need     : " + m_Need.m_Type);
        //UnityEngine.Debug.Log("Patient Need     : " + m_Need.m_Type);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Need GetNeed() { return m_Need; }

    public void SetNeedType(NeedType _needtype)
    {
        m_Need.m_Type = _needtype;
    }

    public void SetPriority(int _priority)
    {
        m_Need.m_Priority = _priority;
    }

}
