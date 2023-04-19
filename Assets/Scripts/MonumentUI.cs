using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentUI : MonoBehaviour
{
    MonumentController MC;
    public GameObject moveLeftButton;
    public GameObject moveRightButton;
    ThirdPersonMovement TPM; 
    void Start()
    {
        //TPM = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonMovement>();
        Transform monument = transform.parent.GetChild(0);
        MC = monument.GetComponent<MonumentController>();
    }

    void Update()
    {

            if (MC.m_canMoveLeft && MC.touchingMonument)
            {
                moveLeftButton.SetActive(true);
            }
            else
            {
                moveLeftButton.SetActive(false);
            }

            if (MC.m_canMoveRight && MC.touchingMonument)
            {
                moveRightButton.SetActive(true);
            }
            else
            {
                moveRightButton.SetActive(false);
            }
        
    }
}
