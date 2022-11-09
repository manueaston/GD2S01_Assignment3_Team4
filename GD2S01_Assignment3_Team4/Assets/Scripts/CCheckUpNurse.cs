using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CCheckUpNurse : CNurse
{
    void Awake()
    {
        CCheckUpNurseBehaviour checkUpBehaviour = gameObject.AddComponent<CCheckUpNurseBehaviour>() as CCheckUpNurseBehaviour;
        // add checkup nurse behaviour as component
    }
}
