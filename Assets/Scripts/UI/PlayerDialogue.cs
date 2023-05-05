using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDialogue : Subject
{
    DialogueSystem dialogue;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogBoxText;
    private bool _isPlayerInside;
    public bool talked = false;
    public bool talkedWithKing;
    public GameObject acceptButton; 
    private void Start()
    {
        dialogue = DialogueSystem.instance;
        talkedWithKing = false; 
    }

    public string[] s = new string[]
    {
        "",
    };

    int index = 0;

    void Update()
    {
        if (_isPlayerInside)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
                {
                    if (index == 8)
                    {
                        acceptButton.SetActive(true); 
                    }
                    else
                    {
                        if (index >= s.Length)
                        {
                            dialogBox.SetActive(false);
                            dialogBoxText.text = "- Click to continue -";
                            NotifyObservers(PlayerActions.DialogueOver);
                            talkedWithKing = true;
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
        Say(s[index]);
        index++; 
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

    private void OnTriggerExit2D(Collider2D collision)
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
