using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarScript : MonoBehaviour
{
    bool getKey; 
    Animator anim; 
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (getKey)
        {
            anim.SetTrigger("_altarDown"); 
        }
    }
}
