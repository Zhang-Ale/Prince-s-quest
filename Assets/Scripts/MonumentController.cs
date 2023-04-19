using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentController : MonoBehaviour
{
    public Material normalMat, greenMat, redMat;
    Rigidbody m_Rb;
    public float m_Speed = 2f;

    public bool m_moveLeft;
    [SerializeField]
    bool m_moveRight;
    [SerializeField]
    bool canMove; 
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canMove)
        {
            m_Speed = 2; 
            if (m_moveLeft)
            {
                MoveToLeftPosition();
            }
            if (m_moveRight)
            {
                MoveToRightPosition();
            }
        }
        else
        {
            m_Speed = 0;
        }
        
    }

    public void MoveToLeftPosition()
    {
        Vector3 m_Translate = new Vector3(1, 0, 0);
        m_Rb.transform.Translate(m_Translate * Time.deltaTime * m_Speed);
    }

    public void MoveToRightPosition()
    {
        Vector3 m_Translate = new Vector3(-1, 0, 0);
        m_Rb.transform.Translate(m_Translate * Time.deltaTime * m_Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LeftPosition" && other.tag == "RightPosition")
        {
            canMove = false; 
            Destroy(other.gameObject, 2f); 
        }
    }
}
