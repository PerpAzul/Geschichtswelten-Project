using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class DialogSystem : MonoBehaviour
{
//based on this yt tutorial: https://youtu.be/8oTYabhj248?si=JnXvAmiuMDO14vIT and adapted
    [SerializeField] private TextMeshProUGUI textComponent;

    private List<string> dialogLines;

    [SerializeField] private float textDelay; //lower values mean faster typing of the words on screen
    [SerializeField] private float timeBeforeNextLine;

    private int curIndex;

    private bool currentlyTyping;
    
    // Start is called before the first frame update
    void Start()
    {
       // the Dialog System should start disabled. Can easily be changed
       this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentlyTyping && curIndex < dialogLines.Count - 1) //all the current text is displayed and another text is in the queue
        {
            curIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    private void OnEnable()
    {
        textComponent.text = string.Empty;
        curIndex = -1;
        currentlyTyping = false;
        dialogLines = new List<string>();
    }
    
    public void AddMultipleLines(List<string> nextLines)
    {
        dialogLines.AddRange(nextLines);
    }

    //types the next line, one by one character at textSpeed
    IEnumerator TypeLine()
    {
        currentlyTyping = true;
        foreach (char c in dialogLines[curIndex])
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textDelay);
        }
        //text stays around for a bit longer before next text block appears to give the reader time to catch up
        yield return new WaitForSeconds(timeBeforeNextLine);
        currentlyTyping = false;
        
        if(curIndex == dialogLines.Count - 1)
        {
            //giving some extra time on the last one (could be unnecessary)
            yield return new WaitForSeconds(timeBeforeNextLine);
            //no more need for the Dialog box currently, so it will disappear from the screen
            gameObject.SetActive(false);
        }
    }
}
