using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CAdminNurse : CNurse
{
    void Awake()
    {
        CAdminNurseBehaviour adminBehaviour = gameObject.AddComponent<CAdminNurseBehaviour>() as CAdminNurseBehaviour;
        // add admin nurse behaviour as component
    }
}
