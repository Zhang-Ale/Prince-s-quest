using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentTwoUI : MonoBehaviour
{
    public MonumentTwoController MC2;
    public GameObject moveLeftButton;
    public GameObject moveRightButton;
    ThirdPersonMovement TPM;
    void Start()
    {
        //TPM = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonMovement>();
        Transform monument = transform.parent.GetChild(0);
        MC2 = monument.GetComponent<MonumentTwoController>();
    }

    void Update()
    {
        if (!MC2.hit)
        {
            if (MC2.m_canMoveLeft && MC2.touchingMonument)
            {
                moveLeftButton.SetActive(true);
            }
            else
            {
                moveLeftButton.SetActive(false);
            }

            if (MC2.m_canMoveRight && MC2.touchingMonument)
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
