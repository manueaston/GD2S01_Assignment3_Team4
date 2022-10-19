using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NeedType { 
    Type1,
    Type2,
    Type3
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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Need GetNeed() { return m_Need; }

    public void SetNeedTypr(NeedType _needtype)
    {
        m_Need.m_Type = _needtype;
    }

    public void SetPriority(int _priority)
    {
        m_Need.m_Priority = _priority;
    }

}
