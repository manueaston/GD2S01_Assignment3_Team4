using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NeedType { 
    Type0 = 0,
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
        //Set Random Need
        SetNeedType((NeedType)UnityEngine.Random.Range(0, 3));
        
        // if need 0 priority = 0
        /*if (GetNeedType() == GetNeedType(m_Type.Type0))
        {
            SetPriority(0);
        }
        else
        {
            //Set Random Priority
            SetPriority(UnityEngine.Random.Range(1, 3));
        }*/

        //Set Random Priority
        SetPriority(UnityEngine.Random.Range(0, 3));

        //UnityEngine.Debug.Log("Patient enters ED: ");
        UnityEngine.Debug.Log("Patient Priority : " + GetPriority() + " || Patient Need     : " + GetNeedType());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Need GetNeed() { return m_Need; }

    public NeedType GetNeedType() { return m_Need.m_Type; }

    public void SetNeedType(NeedType _needtype)
    {
        m_Need.m_Type = _needtype;
    }

    public int GetPriority() { return m_Need.m_Priority; }
    public void SetPriority(int _priority)
    {
        m_Need.m_Priority = _priority;
    }

}
