using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UIManager : Subject
{
    private bool mFaded = false;
    public float Duration = 1f;
    public GameObject Story;
    public GameObject ReadScriptButton;
    public GameObject CloseScriptButton;
    public GameObject scriptText;
    public GameObject onClickEnterCave;
    public GameObject feedbackText;
    public UIAttachScript UAS;
    bool clickedOnce = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    void Update()
    {

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
        CloseScriptButton.SetActive(true);
        CanvasGroup canvGroup = Story.GetComponent<CanvasGroup>();
        StartCoroutine(ActionOne(canvGroup, canvGroup.alpha, mFaded ? 0 : 1, 0.25f));
    }

    public void FadeOut()
    {
        NotifyObservers(PlayerActions.DialogueOver);
        CloseScriptButton.SetActive(false);  
        CanvasGroup canvGroup = Story.GetComponent<CanvasGroup>();
        StartCoroutine(ActionOne(canvGroup, canvGroup.alpha, mFaded ? 1 : 0, 0.25f));
        Story.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public IEnumerator ActionOne(CanvasGroup canvGroup, float start, float end, float waitTime)
    {
        float counter = 0f;
        yield return new WaitForSeconds(waitTime);
        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);
            yield return null;
        }
    }

    public void EnterCaveButton()
    {
        onClickEnterCave.SetActive(true);
        CanvasGroup canvGroup = feedbackText.GetComponent<CanvasGroup>();
        StartCoroutine(ActionOne(canvGroup, canvGroup.alpha, mFaded ? 0 : 1, 0.25f));
        clickedOnce = true; 

        if(UAS.keyNumber != 4 && clickedOnce)
        {
            TextMeshProUGUI _text = feedbackText.GetComponentInChildren<TextMeshProUGUI>(); 
            _text.text = "Insufficient keys"; 
        }

        if(UAS.keyNumber == 4 && clickedOnce)
        {
            onClickEnterCave.SetActive(false);
            //cave block breaks
        }
        StartCoroutine(ActionOne(canvGroup, canvGroup.alpha, mFaded ? 1 : 0, 4f));
    }
}
