using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NeedType { 
    Type1,
    Type2,
    Type3
};

struct Need {
    int m_Priority;
    NeedType m_Type;
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

    Need GetNeed() { return m_Need; }

    void SetNeed(int _priority, NeedType _needtype)
    {
        //m_Priority  = _priority;
        //m_Type = _needtype;
    }

}
