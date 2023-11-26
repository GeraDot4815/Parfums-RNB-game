using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    //[SerializeField] List<string> speaker;
    //[SerializeField] List<string> phrase;
    [SerializeField] private List<Dialogue> mDialogues;

    [SerializeField] TMP_Text spText;
    [SerializeField] TMP_Text phText;
    [SerializeField] GameObject speakCanvas;

    [SerializeField] private GameObject variantsPanel;

    [SerializeField] int curPhrase;
    [SerializeField] int curDialogueIdx;
    private Dialogue curDialogue;
    private void Awake()
    {
        instance = this;
        variantsPanel.SetActive(false);
        StartNewDialogue(0);
    }
    public void DisplayNextSentense()
    {
        if (curPhrase < curDialogue.sentenses.Count - 1)
        {
            curPhrase += 1;
            spText.text = curDialogue.sentenses[curPhrase].speaker;
            phText.text = curDialogue.sentenses[curPhrase].phrase;
        }
        else
        {
            OnDialogueEnds(curDialogueIdx);
        }
    }
    private void StartNewDialogue(int index)
    {
        curDialogueIdx= index;
        curDialogue= mDialogues[curDialogueIdx];
        curPhrase= 0;
        spText.text = curDialogue.sentenses[curPhrase].speaker;
        phText.text = curDialogue.sentenses[curPhrase].phrase;
    }
    private void OnDialogueEnds(int index)
    {
        if (mDialogues[index].choose != null && !mDialogues[index].choose.isPlayed)
        {
            OpenVariantsPanel(mDialogues[index].choose);
            curDialogueIdx = index;
        }
        else if (index < mDialogues.Count - 1)
        {
            StartNewDialogue(index+1);
        }
        else
        {
            SceneManager.LoadScene("ParfumeMaker");
        }
    }
    public void OpenVariantsPanel(DialogueChoose dialogueChoose)
    {
        variantsPanel.SetActive(true);
        dialogueChoose.InitializeVariants();
    }
    public void CloseVariantsPanel()
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
    public DialogueChoose choose=null;
}
