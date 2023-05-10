using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttachScript : Subject
{
    public GameObject ReadButton;
    public GameObject key1, key2, key3, key4;
    GameObject currentKey;
    public GameObject getKeyButton; 
    void Start()
    {
        currentKey = null; 
    }

    void Update()
    {
        
    }

    public void GetKey()
    {
        currentKey.SetActive(false);
        currentKey = null;
        getKeyButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {

            Destroy(other.gameObject, 0.25f);
        }

        if (other.gameObject.tag == "Script")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ReadButton.SetActive(true);
        }

        if(other.gameObject == key1)
        {
            getKeyButton.SetActive(true); 
            key1 = currentKey; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Script")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ReadButton.SetActive(false);
        }
    }
}
