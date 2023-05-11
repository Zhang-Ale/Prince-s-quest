using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriteEffect : MonoBehaviour
{
    [SerializeField]
    float delay = 0.03f;
    public string fullText;
    public string currentText = "";
    public UIAttachScript UAS;
    public ScriptStories SS;
    void OnEnable()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        if (UAS.currentScript.name == "Script1")
        {
            fullText = SS.ScriptOne;
        }
        if (UAS.currentScript.name == "Script2")
        {
            fullText = SS.ScriptTwo;
        }
        if (UAS.currentScript.name == "Script3")
        {
            fullText = SS.ScriptThree;
        }
        if (UAS.currentScript.name == "Script4")
        {
            fullText = SS.ScriptFour;
        }
        if (UAS.currentScript.name == "Script5")
        {
            fullText = SS.ScriptFive;
        }

        yield return new WaitForSeconds(1.25f);
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1f);
    }

    public void RefreshText()
    {
        this.GetComponent<TextMeshProUGUI>().text = null;
        fullText = null; 
    }
}
