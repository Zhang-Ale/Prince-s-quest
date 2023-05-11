using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarScript : MonoBehaviour
{
    Animator anim;
    ParticleSystem fog;
    public MonumentOneController MC1; 
    void Start()
    {
        anim = GetComponent<Animator>();
        fog = GetComponentInChildren<ParticleSystem>(); 
    }

    void Update()
    {
        if (this.name == "Altar1" && MC1.hit)
        {
            anim.SetTrigger("_altarUp");
            fog.Play(); 
        }
    }
}
