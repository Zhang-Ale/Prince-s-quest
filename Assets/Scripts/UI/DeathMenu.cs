using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DeathMenu : MonoBehaviour
{
    public UIAttachScript UAS;
    public GameObject deathMenu;
    private bool mFaded = false;
    public float Duration = 1f;
    void Start()
    {
        
    }
    private void Update()
    {
        if (UAS.dead)
        {
            CanvasGroup CG = deathMenu.GetComponentInChildren<CanvasGroup>();
            StartCoroutine(ActionOne(CG, CG.alpha, mFaded ? 0 : 1, 0.01f));     
            deathMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1;
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
        Time.timeScale = 0;
    }
}
