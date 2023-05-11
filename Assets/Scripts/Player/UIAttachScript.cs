using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIAttachScript : Subject
{
    public GameObject ReadButton;
    public GameObject[] key;
    public GameObject currentScript; 
    public GameObject[] getKeyButton;
    public GameObject caveBlock;
    public GameObject enterCaveButton;
    public int keyNumber;
    public TextMeshProUGUI keyNoText;
    public Animator[] altarAnim;
    public ParticleSystem[] fog;
    public GameObject[] lightRay;
    int index;
    public bool dead;
    public GameObject finalDialogue; 
    
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex; 
        currentScript = null; 
    }

    public void GetKeyOne()
    {
        keyNumber += 1;
        keyNoText.text = keyNumber.ToString();
        key[0].SetActive(false);
        fog[0].Play();
        lightRay[0].SetActive(false);
        altarAnim[0].SetTrigger("_altarUp"); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        getKeyButton[0].SetActive(false);
    }
    public void GetKeyTwo()
    {
        keyNumber += 1;
        keyNoText.text = keyNumber.ToString();
        key[1].SetActive(false); 
        fog[1].Play();
        lightRay[1].SetActive(false);
        altarAnim[1].SetTrigger("_altarUp");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        getKeyButton[1].SetActive(false);
    }

    public void GetKeyThree()
    {
        keyNumber += 1;
        keyNoText.text = keyNumber.ToString();
        key[2].SetActive(false);
        fog[2].Play();
        lightRay[2].SetActive(false);
        altarAnim[2].SetTrigger("_altarUp");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        getKeyButton[2].SetActive(false);
    }

    public void GetKeyFour()
    {
        keyNumber += 1;
        keyNoText.text = keyNumber.ToString();
        key[3].SetActive(false);
        fog[3].Play();
        lightRay[3].SetActive(false);
        altarAnim[3].SetTrigger("_altarUp");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        getKeyButton[3].SetActive(false);
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

        if(index == 1)
        {
            if (key[0] != null && other.gameObject == key[0])
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                getKeyButton[0].SetActive(true);
            }

            if (key[1] != null && other.gameObject == key[1])
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                getKeyButton[1].SetActive(true);
            }

            if (key[2] != null && other.gameObject == key[2])
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                getKeyButton[2].SetActive(true);
            }

            if (key[3] != null && other.gameObject == key[3])
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                getKeyButton[3].SetActive(true);
            }
        }

        if(other.gameObject.tag == "ToCaveTeleport" || other.gameObject.tag == "ToFinalTeleport")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
        if (other.gameObject.tag == "ToGroundTeleport")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if(other.gameObject.tag == "Void")
        {
            dead = true; 
        }

        if(other.gameObject.tag == "Wand")
        {
            finalDialogue.SetActive(true); 
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

        if (index == 1)
        {
            if (other.gameObject == key[0])
            {
                getKeyButton[0].SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (other.gameObject == key[1])
            {
                getKeyButton[1].SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (other.gameObject == key[2])
            {
                getKeyButton[2].SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (other.gameObject == key[3])
            {
                getKeyButton[3].SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if (other.gameObject == caveBlock)
        {
            enterCaveButton.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
