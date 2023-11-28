using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour //omg
{
    public static DialogueManager instance;
    [SerializeField] private List<Dialogue> mDialogues; //all dialogs in this scene

    [field: SerializeField] public List<VariantButton> selectionButtons { get; private set; } //buttons, what we would use
    //WARNING the number of buttons should not be less than the number of selections

    //text fields
    [SerializeField] private TMP_Text spText; 
    [SerializeField] private TMP_Text phText;
    [SerializeField] private GameObject speakCanvas;

    [SerializeField] private GameObject variantsPanel;

    private int curPhrase;
    private int curDialogueIdx;
    private Dialogue curDialogue;
    private void Awake()
    {
        instance = this;
        variantsPanel.SetActive(false);
        StartNewDialogue(0);
    }
    public void DisplayNextSentense() //calls on screan click
    {
        if (curPhrase < curDialogue.sentenses.Count - 1)
        {
            curPhrase += 1;
            spText.text = curDialogue.sentenses[curPhrase].speaker;
            phText.text = curDialogue.sentenses[curPhrase].phrase;
        }
        else
        {
            OnDialogueEnds(curDialogueIdx); //call next event
        }
    }
    private void StartNewDialogue(int index) //run another dialogue sequence
    {
        curDialogueIdx= index;
        curDialogue= mDialogues[curDialogueIdx];
        curPhrase= 0;
        spText.text = curDialogue.sentenses[curPhrase].speaker;
        phText.text = curDialogue.sentenses[curPhrase].phrase;
    }
    private void OnDialogueEnds(int index) //what we want to do after last phrase
    {
        if ( mDialogues[index].selection.needToPlay) //if we have selection, we run it
        {
            OpenVariantsPanel(mDialogues[index].selection);
            curDialogueIdx = index; //on selection end this void will be called once again
            //but selestion will be already played
        }
        else if (index < mDialogues.Count - 1) //if we have another dialogues, we run it
        {
            StartNewDialogue(index+1);
        }
        else //all dialogues played
        {
            SceneManager.LoadScene("ParfumeMaker"); //it is better to use indexes or references
        }
    }
    public void OpenVariantsPanel(DialogueChoose dialogueChoose)
    {
        variantsPanel.SetActive(true);

        DisableButtons(); //buttons without selections will be invisible

        dialogueChoose.InitializeVariants();
    }
    private void DisableButtons()
    {
        foreach(VariantButton btn in selectionButtons)
            btn.SetDisable();
    }
    private void EnableButtons() //possibly it's useless void
    {
        foreach (VariantButton btn in selectionButtons)
            btn.SetEnable();
    }
    public void OnSelestionComplete()
    {
        variantsPanel.SetActive(false);
        OnDialogueEnds(curDialogueIdx);
    }
}
[System.Serializable]
public class Sentense
{
    public string speaker;
    public string phrase;
}
[System.Serializable]
public class Dialogue
{
    public List<Sentense> sentenses;
    public DialogueChoose selection;
}
