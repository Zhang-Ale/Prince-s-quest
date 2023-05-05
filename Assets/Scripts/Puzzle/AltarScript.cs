using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarScript : MonoBehaviour
{
    public bool getKey; 
    Animator anim;
    ParticleSystem fog; 
    void Start()
    {
        anim = GetComponent<Animator>();
        fog = GetComponentInChildren<ParticleSystem>(); 
    }

    void Update()
    {
        if (getKey)
        {
            anim.SetTrigger("_altarDown");
            fog.Play(); 
        }
    }
}
