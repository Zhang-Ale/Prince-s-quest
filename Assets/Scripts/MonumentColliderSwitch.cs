using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentColliderSwitch : MonoBehaviour
{
    Transform g_Monument;
    MonumentController MC; 

    private void Start()
    {
        Transform t_Monument = transform.parent.GetChild(0);
        MC = t_Monument.GetComponent<MonumentController>();
        MC.m_moveLeft = true; 
    }

    void Update()
    {
        
    }
}
