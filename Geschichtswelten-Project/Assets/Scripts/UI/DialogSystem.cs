using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class DialogSystem : MonoBehaviour
{
//based on this yt tutorial: https://youtu.be/8oTYabhj248?si=JnXvAmiuMDO14vIT
    [SerializeField] private TextMeshProUGUI textComponent;

    [SerializeField] private string[] dialogLines;

    [SerializeField] private float textDelay; //lower values mean faster typing of the words on screen
    [SerializeField] private float timeBeforeNextLine;

    private int curIndex;

    private int lastIndexToPlay;

    private bool currentlyTyping;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        curIndex = -1;
        lastIndexToPlay = -1;
        currentlyTyping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentlyTyping && curIndex < lastIndexToPlay) //all the current text is displayed and another text is in the queue
        {
            curIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
    
    //the next line will be queued and played once the current one is over
    public void QueueNextLine()
    {
        if (lastIndexToPlay < dialogLines.Length - 1) //there is another line to show
        {
            lastIndexToPlay++;
        }
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
        
        if(curIndex == dialogLines.Length - 1)
        {
            //giving some extra time on the last one (could be unnecessary)
            yield return new WaitForSeconds(timeBeforeNextLine);
            //no more need for the Dialog box (?)
            gameObject.SetActive(false);
        }
    }
}
