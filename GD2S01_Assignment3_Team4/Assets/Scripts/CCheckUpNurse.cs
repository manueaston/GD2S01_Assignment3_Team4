using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CCheckUpNurse : CNurse
{
    void Start()
    {
        CCheckUpNurseBehaviour behaviour = new CCheckUpNurseBehaviour();
        SetBehaviour(behaviour);
    }
}
