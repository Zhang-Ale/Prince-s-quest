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


    private void Start()
    {
        dialogue = DialogueSystem.instance;
    }

    public string[] s = new string[]
    {
        "Benjamin opens his eyes, finds himself in a deserted alley.:Benjamin",
        "Who am I...",
        "Where is this place..."
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
                    if (index == 1)
                    {
                        
                    }

                    if (index == 2)
                    {

                    }

                    if (index == 3)
                    {

                    }

                    if (index >= s.Length)
                    {

                        dialogBox.SetActive(false);
                        dialogBoxText.text = "- Click to continue -";
                        //allow the player to move
                        return; 
                    }

                    Say(s [index]);
                    index++;
                }
            }
        }
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
            NotifyObservers(PlayerActions.Dialogue);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerInside = false;
            talked = true;
        }
    }

}
