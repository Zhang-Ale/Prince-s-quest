using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : Subject
{
    public PlayerDialogue PD;
    Scene scene;
    GameObject MenuCanvas;
    public GameObject kingTrigger;
    public Animator anim; 

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        MenuCanvas = GameObject.Find("Menu Canvas");
        NotifyObservers(PlayerActions.DialogueStart);
    }

    void Update()
    {
        if(PD != null)
        {
            if (PD.talkedWithKing)
            {
                LoadNextScene();
            }
        }
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame()
    {
        anim.enabled = true; 
        NotifyObservers(PlayerActions.Button);
        MenuCanvas.SetActive(false);
        kingTrigger.SetActive(true);
        kingTrigger.GetComponent<PlayerDialogue>()._isPlayerInside = true; 
    }


    public void QuitGame()
    {
        NotifyObservers(PlayerActions.Button);
        Application.Quit();
    }
}
