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
    [SerializeField] private string nextScene;
    private int curPhrase;
    private int curDialogueIdx;
    private Dialogue curDialogue;

    [SerializeField] private DialogueAnimator characterAnimator;
    [SerializeField] private DialogueAnimator bgAnimator;
    private void Start()
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

        if (curDialogue.character.sprite != null)
        {
            curDialogue.character.anim = characterAnimator;
            curDialogue.character.Show(characterAnimator.sourseImg);
        }
        if (curDialogue.background.sprite != null)
        {
            curDialogue.background.anim = bgAnimator;
            curDialogue.background.Show(bgAnimator.sourseImg);
        }
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

            if (!mDialogues[index].sentenses[mDialogues[index].sentenses.Count-1].interact)
            {
                /*if (mDialogues[index+1].character.sprite != null && curDialogue.character.sprite != null)
                {
                    //curDialogue.character.anim = characterAnimator;
                    curDialogue.character.Hide(characterAnimator.sourseImg);
                }
                if (mDialogues[index+1].background.sprite != null && curDialogue.background.sprite != null)
                {
                    //curDialogue.background.anim = bgAnimator;
                    curDialogue.background.Hide(bgAnimator.sourseImg);
                }*/
                StartNewDialogue(index+1);
            }

        }
        else //all dialogues played
        {
            if (!mDialogues[index].sentenses[mDialogues[index].sentenses.Count-1].interact)
            {
                SceneManager.LoadScene(nextScene); //it is better to use indexes or references
            }
            else
            {
                speakCanvas.SetActive(false);
            }
        }
    }
    public void OpenVariantsPanel(DialogueChoose dialogueChoose)
    {
        DisableButtons();        //buttons without selections will be invisible

        variantsPanel.SetActive(true);

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
    public void EnableDialogue()
    {
        curPhrase++;
        spText.text = curDialogue.sentenses[curPhrase].speaker;
        phText.text = curDialogue.sentenses[curPhrase].phrase;
        speakCanvas.SetActive(true);
    }
    public void DisableDialogue()
    {
        speakCanvas.SetActive(true);
    }
    public void AddSentense(string speaker, string phrase)
    {
        curDialogue.sentenses.Add(new Sentense(speaker,phrase));
    }
    public void AddSentense(string speaker, string phrase, bool interact)
    {
        curDialogue.sentenses.Add(new Sentense(speaker,phrase,interact));
    }
}
[System.Serializable]
public class Sentense
{
    public string speaker;
    [TextArea(order =3)]
    public string phrase;
    public bool interact; //leads to interaction (like in parfumeMaker game). Because of it, the last sentense in a dialogue should have interact == false, or else you'll have to do everything you want by yourself
    public Sentense(string speaker, string phrase)
    {
        this.speaker = speaker;
        this.phrase = phrase;
        interact = false;
    }
    public Sentense(string speaker, string phrase, bool interact)
    {
        this.speaker = speaker;
        this.phrase = phrase;
        this.interact = interact;
    }
}
[System.Serializable]
public class Dialogue
{
    public Character character;
    public BackGround background;
    public List<Sentense> sentenses;
    public DialogueChoose selection;
}
