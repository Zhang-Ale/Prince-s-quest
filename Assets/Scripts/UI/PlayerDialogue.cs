using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class PlayerDialogue : Subject
{
    DialogueSystem dialogue;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogBoxText;
    public bool _isPlayerInside;
    public bool talked = false;
    public bool talkedWithKing;
    public GameObject acceptButton;
    TextMeshProUGUI acceptButtonText;
    bool canAccept;
    public GameObject princeName;
    public FinalEnding FE;
    public GameObject option1, option2, ending1, ending2;
    int sceneIndex; 

    private void Start()
    {
        dialogue = DialogueSystem.instance;
        talkedWithKing = false;
        acceptButtonText = acceptButton.GetComponentInChildren<TextMeshProUGUI>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex; 
    }

    public string[] s = new string[]
    {
        "",
    };

    int index = 0;

    void Update()
    {
        dialogBox.SetActive(true);
        NotifyObservers(PlayerActions.DialogueStart);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        if (_isPlayerInside)
        {  
            if (Input.GetMouseButtonDown(0))
            {
                if(!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
                {
                    if (sceneIndex == 0)
                    {
                        if (index == 0)
                        {
                            acceptButtonText.text = "My name is Astrid. ";
                            acceptButton.SetActive(true);
                            canAccept = false;
                        }
                        if (index == 1)
                        {
                            acceptButton.SetActive(false);
                        }

                        if (index == 8)
                        {
                            acceptButtonText.text = "I accept the quest. ";
                            acceptButton.SetActive(true);
                            canAccept = true;
                        }
                        else
                        {
                            if (index >= s.Length)
                            {
                                dialogBox.SetActive(false);
                                dialogBoxText.text = "- Teleporting -";
                                NotifyObservers(PlayerActions.DialogueOver);
                                talkedWithKing = true;
                                return;
                            }

                            Say(s[index]);
                            index++;
                        }
                    }
                    if(sceneIndex == 3)
                    {
                        if (index == 0)
                        {
                            acceptButtonText.text = "So this is the wand...";
                            acceptButton.SetActive(true);
                            canAccept = false;
                        }

                        if(index == 2)
                        {
                            FE.enabled = true; 
                        }

                        if (index == 9)
                        {
                            option1.SetActive(true);
                            option2.SetActive(true);
                            canAccept = true;
                        }

                        if (index >= s.Length)
                        {
                            dialogBox.SetActive(false);
                            NotifyObservers(PlayerActions.DialogueOver);
                            return;
                        }

                        Say(s[index]);
                        index++;
                    }
                                    
                }
            }
        }
    }


    public void AcceptQuest()
    {
        NotifyObservers(PlayerActions.Button);
        acceptButton.SetActive(false);
        if (canAccept)
        {
            Say(s[index]);
            index++;
        }
        else
        {
            index = index; 
        }
    }

    public void HandTheWand()
    {
        option1.SetActive(false);
        option2.SetActive(false);
        ending1.SetActive(true); 
    }

    public void KeepTheWand()
    {
        option1.SetActive(false);
        option2.SetActive(false);
        ending2.SetActive(true); 
    }

    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        dialogue.Say(speech, true, speaker);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(!talked && collision.gameObject.CompareTag("Player"))
        {
            _isPlayerInside = true;
            dialogBox.SetActive(true);
            NotifyObservers(PlayerActions.DialogueStart);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isPlayerInside = false;
            talked = true;
        }
    }

}
