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
    GameObject currentKey;
    public GameObject getKeyButton;
    public GameObject caveBlock;
    public GameObject enterCaveButton;
    public int keyNumber;
    public TextMeshProUGUI keyNoText;
    public Animator[] altarAnim;
    public ParticleSystem[] fog;
    public GameObject[] lightRay; 
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
        keyNumber += 1;
        keyNoText.text = keyNumber.ToString();
        currentKey.SetActive(false);
        if (currentKey = key[0])
        {
            altarAnim[0].SetTrigger("_altarUp");
            fog[0].Play();
            lightRay[0].SetActive(false); 
        }
        if (currentKey = key[1])
        {
            altarAnim[1].SetTrigger("_altarUp");
            fog[1].Play();
            lightRay[1].SetActive(false);
        }
        if (currentKey = key[2])
        {
            altarAnim[2].SetTrigger("_altarUp");
            fog[2].Play();
            lightRay[2].SetActive(false);
        }
        if (currentKey = key[3])
        {
            altarAnim[3].SetTrigger("_altarUp");
            fog[3].Play();
            lightRay[3].SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        getKeyButton.SetActive(false);

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

        if(other.gameObject == key[0])
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            getKeyButton.SetActive(true);
            currentKey = other.gameObject;
        }
        if (other.gameObject == key[1])
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            getKeyButton.SetActive(true);
            currentKey = other.gameObject;
        }
        if (other.gameObject == key[2])
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            getKeyButton.SetActive(true);
            currentKey = other.gameObject;
        }
        if (other.gameObject == key[3])
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            getKeyButton.SetActive(true);
            currentKey = other.gameObject;
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

        if (other.gameObject.tag == "Key")
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
