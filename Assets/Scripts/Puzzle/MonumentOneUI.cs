using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentOneUI : MonoBehaviour
{
    public MonumentOneController MC1;
    public GameObject moveLeftButton;
    public GameObject moveRightButton;
    ThirdPersonMovement TPM; 
    void Start()
    {
        //TPM = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonMovement>();
        Transform monument = transform.parent.GetChild(0);
        MC1 = monument.GetComponent<MonumentOneController>();
    }

    void Update()
    {
        if (!MC1.hit)
        {
            if (MC1.m_canMoveLeft && MC1.touchingMonument)
            {
                moveLeftButton.SetActive(true);
            }
            else
            {
                moveLeftButton.SetActive(false);
            }

            if (MC1.m_canMoveRight && MC1.touchingMonument)
            {
                moveRightButton.SetActive(true);
            }
            else
            {
                moveRightButton.SetActive(false);
            }
        } 
    }
}
