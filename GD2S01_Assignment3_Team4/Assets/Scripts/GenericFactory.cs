using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    protected T m_prefab;

    // Generic create function
    protected abstract T MakeInstance();    // function prototype

    // accessible
    public T GetSpawnedInstance()           // function that can be called by any factory
    {
        // 
        return this.MakeInstance();
    }


}