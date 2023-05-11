using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIAttachScript : Subject
{
    public GameObject ReadButton;
    public GameObject key1, key2, key3, key4;
    public GameObject currentScript; 
    GameObject currentKey;
    public GameObject getKeyButton;
    public GameObject caveBlock;
    public GameObject enterCaveButton;
    public int keyNumber;
    public TextMeshProUGUI keyNoText;
    public Animator altarAnim1, altarAnim2, altarAnim3, altarAnim4;
    public ParticleSystem fog1, fog2, fog3, fog4;
    void Start()
    {
        currentKey = null;
        currentScript = null; 
    }

    void Update()
    {
        
    }

    public void GetKey()
    {
        if(currentKey = key1)
        {
            altarAnim1.SetTrigger("_altarUp");
            fog1.Play(); 
        }
        if (currentKey = key2)
        {
            altarAnim2.SetTrigger("_altarUp");
            fog2.Play();
        }
        if (currentKey = key3)
        {
            altarAnim3.SetTrigger("_altarUp");
            fog3.Play();
        }
        if (currentKey = key4)
        {
            altarAnim4.SetTrigger("_altarUp");
            fog4.Play();
        }

        currentKey.SetActive(false); 
        currentKey = null; 
        getKeyButton.SetActive(false);
        keyNumber += 1;
        keyNoText.text = keyNumber.ToString(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == caveBlock)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            enterCaveButton.SetActive(true);
        }

        if (other.gameObject.tag == "Script")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            currentScript = other.gameObject; 
            ReadButton.SetActive(true);         
        }

        if(other.gameObject == key1)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            getKeyButton.SetActive(true); 
            key1 = currentKey; 
        }
        if (other.gameObject == key2)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            getKeyButton.SetActive(true);
            key2 = currentKey;
        }
        if (other.gameObject == key3)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            getKeyButton.SetActive(true);
            key3 = currentKey;
        }
        if (other.gameObject == key4)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            getKeyButton.SetActive(true);
            key4 = currentKey;
        }

        if(other.gameObject.tag == "ToCaveTeleport" || other.gameObject.tag == "ToFinalTeleport")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
        if (other.gameObject.tag == "ToGroundTeleport")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Script")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ReadButton.SetActive(false);
            currentScript = null;
        }

        if (other.gameObject == key1 || key2 || key3 ||key4)
        {
            currentKey = null;
            getKeyButton.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (other.gameObject == caveBlock)
        {
            enterCaveButton.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
