using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CAdminNurse : CNurse
{
    void Start()
    {
        CAdminNurseBehaviour behaviour = new CAdminNurseBehaviour();
        SetBehaviour(behaviour);
    }
}
