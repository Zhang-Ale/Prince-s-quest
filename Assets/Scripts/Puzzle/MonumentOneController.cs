using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentOneController : MonoBehaviour
{
    public float m_Speed;
    Vector3 currentPosition; 
    public bool m_canMoveLeft;
    public bool m_canMoveRight;
    bool moveLeft;
    bool moveRight;
    public GameObject LightSensor;
    public LayerMask layerMask;
    public bool hit; 
    public Material normalMat, greenMat;
    public bool touchingMonument; 

    void Start()
    {
        hit = false; 
        currentPosition = transform.position;
    }

    void Update()
    {
        RayCasting(); 
       
        if (moveLeft)
        {
            Vector3 endPosition = currentPosition + Vector3.right * 10;
            if (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, m_Speed * Time.deltaTime);
            }
            else
            {
                moveLeft = false;
                currentPosition = transform.position;
            }
        }

        if (moveRight)
        {
            Vector3 endPosition = currentPosition + Vector3.right * -10;
            if (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, m_Speed * Time.deltaTime);
            }
            else
            {
                moveRight = false;
                currentPosition = transform.position;
            }
        }
    }

    public void MoveToLeftPosition()
    {
        moveLeft = true; 
    }

    public void MoveToRightPosition()
    {
        moveRight = true; 
    }

    void RayCasting()
    {
        Ray ray = new Ray(LightSensor.transform.position, transform.forward);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 10, layerMask))
        {
            hit = true;
            LightSensor.GetComponent<MeshRenderer>().material = greenMat; 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            touchingMonument = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "LeftPosition")
        {
            m_canMoveRight = true;
            m_canMoveLeft = false;
        }
        
        if (other.tag == "RightPosition")
        {
            m_canMoveLeft = true;
            m_canMoveRight = false;
        }
        
        if (other.tag == "MiddlePosition")
        {
            m_canMoveLeft = true;
            m_canMoveRight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LeftPosition")
        {
            m_canMoveRight = false;
        }

        if (other.tag == "RightPosition")
        {
            m_canMoveLeft = false;
        }

        if (other.tag == "MiddlePosition")
        {
            m_canMoveLeft = false;
            m_canMoveRight = false;
        }

        if (other.gameObject.tag == "Player")
        {
            touchingMonument = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
