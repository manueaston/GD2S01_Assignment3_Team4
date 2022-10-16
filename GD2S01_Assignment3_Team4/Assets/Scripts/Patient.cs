using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public GameObject newPatient;
    public int m_iPriority = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Patient Spawned: ");
        // Determine Patient priority
        m_iPriority = (Random.Range(0, 4));
        Debug.Log("Patient Spawned! Priority: " + m_iPriority);

    }

    // Update is called once per frame
    void Update()
    {
        if (m_iPriority == 0)
        {
            //Debug.Log("Patient Released: ");
            Destroy(newPatient);
        }

    }
}
