using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPatientFactory : GenericFactory<CPatient>
{
    protected override CPatient MakeInstance()
    {
        
        CPatient newPatient = Instantiate(m_prefab);

        return newPatient;
    }
}
