using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttachScript : Subject
{
    public GameObject ReadButton;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            NotifyObservers(PlayerActions.Collect);
            Destroy(other.gameObject, 0.25f);
        }

        if (other.gameObject.tag == "Script")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ReadButton.SetActive(true);
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
