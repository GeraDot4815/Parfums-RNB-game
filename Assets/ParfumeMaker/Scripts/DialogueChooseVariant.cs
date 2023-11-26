using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class DialogueChooseVariant : IScoreChanger
{
    public bool isRight;
    public string variantText;
    [field:SerializeField] public int RightScore { get ; set; }
    [field: SerializeField] public int WrongScore { get ; set ; }

    private AudioManager am;
    public void ChangeScore()
    {
        am = AudioManager.instance;
        if (isRight)
        {
            ScoreManager.ChangeScoreOn(RightScore);
            DoRightFeedBack();
        }
        else
        {
            ScoreManager.ChangeScoreOn(WrongScore);
            DoWrongFeedBack();
        }
        DialogueManager.instance.CloseVariantsPanel();
    }

    public void DoRightFeedBack()
    {
        am.audioSource.PlayOneShot(am.rightAnswerSound);
    }

    public void DoWrongFeedBack()
    {
        am.audioSource.PlayOneShot(am.wrongAnswerSound);
    }
}
