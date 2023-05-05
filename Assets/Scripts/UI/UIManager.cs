using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UIManager : Subject
{
    public bool animationStart;
    private bool mFaded = false;
    public float Duration = 1f;
    public GameObject Story;
    public GameObject ReadScriptButton;
    public GameObject CloseScriptButton;
    public GameObject scriptText;
    ScriptStories SS; 
    void Start()
    {
        SS = GetComponent<ScriptStories>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    void Update()
    {
        if (animationStart)
        {
            PlayAnimation(); 
        }
    }

    public void PlayAnimation()
    {
        //play the intro video animation 
        //if left two times click, esc button appears, press it to skip animation
    }

    public void SkipAnimation()
    {
        //call the gameobject with VideoPlayer
        //set the video of gameobject to null
        //set disactive the gameobject with VideoPlayer 
    }

    public void FadeIn()
    {
        NotifyObservers(PlayerActions.Button);
        NotifyObservers(PlayerActions.DialogueStart);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ReadScriptButton.SetActive(false);
        Story.SetActive(true);
        TextMeshProUGUI script = scriptText.GetComponent<TextMeshProUGUI>();
        script.text = SS.ScriptOne;
        CloseScriptButton.SetActive(true);
        CanvasGroup canvGroup = Story.GetComponent<CanvasGroup>();
        StartCoroutine(ActionOne(canvGroup, canvGroup.alpha, mFaded ? 0 : 1));
    }

    public void FadeOut()
    {
        NotifyObservers(PlayerActions.DialogueOver);
        CloseScriptButton.SetActive(false);
        CanvasGroup canvGroup = Story.GetComponent<CanvasGroup>();
        StartCoroutine(ActionOne(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));
        Story.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public IEnumerator ActionOne(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        yield return new WaitForSeconds(0.25f);
        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);
            yield return null;
        }
    }
}
