using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public PlayerDialogue PD;
    Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (PD.talkedWithKing)
        {
            LoadNextScene(); 
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
