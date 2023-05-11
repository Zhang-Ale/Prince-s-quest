using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarScript : MonoBehaviour
{
    public Animator[] anim;
    public GameObject[] fog;
    public MonumentOneController[] MC;
    
    void Start()
    {

    }

    void Update()
    {
        if (MC[0].hit)
        {
            anim[0].SetTrigger("_altarDown");
            fog[0].SetActive(true); 
        }
        if (MC[1].hit)
        {
            anim[1].SetTrigger("_altarDown");
            fog[1].SetActive(true);
        }
        if (MC[2].hit)
        {
            anim[2].SetTrigger("_altarDown");
            fog[2].SetActive(true);
        }
        if (MC[3].hit)
        {
            anim[3].SetTrigger("_altarDown");
            fog[3].SetActive(true);
        }
    }
}
