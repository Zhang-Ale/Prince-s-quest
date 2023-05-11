using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnding : MonoBehaviour
{
    private bool mFaded = false;
    public float Duration = 1f;
    public GameObject blackCanvas;
    CanvasGroup CG; 
    public GameObject PlayerMain;
    public GameObject Player2;
    public GameObject Nihil; 
    public GameObject option1, option2, ending1, ending2;
    bool done; 

    void OnEnable()
    {
        CG = blackCanvas.GetComponent<CanvasGroup>(); 
        StartCoroutine(ActionOne(CG, CG.alpha, mFaded ? 0 : 1, 0.01f));
    }

    private void Update()
    {
        if (done)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
            PlayerMain.SetActive(false);
            Player2.SetActive(true);
            Nihil.SetActive(true); 
            option1.SetActive(true);
            option2.SetActive(true);
            StartCoroutine(ActionOne(CG, CG.alpha, mFaded ? 1 : 0, 1f));
            blackCanvas.SetActive(false); 
        }
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
            done = true;
        }
        
    }

    public void EndOne()
    {
        ending1.SetActive(true);
    }
    public void CloseEndOne()
    {
        ending1.SetActive(false);
    }

    public void EndTwo()
    {
        ending2.SetActive(true);
    }

    public void CloseEndTwo()
    {
        ending2.SetActive(false);
    }
}
