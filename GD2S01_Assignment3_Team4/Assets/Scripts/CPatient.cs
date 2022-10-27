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

    // Awake is called when object is instantiated
    void Awake()
    {
        //Set Random Need
        SetNeedType((NeedType)UnityEngine.Random.Range(1, 4));
        SetPriority(UnityEngine.Random.Range(1, 4));

        //UnityEngine.Debug.Log("Patient enters ED: ");
        UnityEngine.Debug.Log("Patient Priority : " + GetPriority() + " || Patient Need     : " + GetNeedType());
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Need.m_Priority == 0)
        {
            Debug.Log("Destroying Patient");
            Destroy(this.gameObject);
        }
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
