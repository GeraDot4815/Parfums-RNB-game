using UnityEngine;
[System.Serializable]
public class DialogueChooseVariant : IScoreChanger //Variant
{
    public bool isRight=true; //charge or deduct points
    public string variantText;
    [field:SerializeField] public int ScoreChanging { get ; set; } //what count we changing score

    private AudioManager am; //sound player link
    public void ChangeScore()
    {
        am = AudioManager.instance; 
        if (isRight)
        {
            ScoreManager.ChangeScoreOn(+ScoreChanging); //charge points
            DoRightFeedBack();
        }
        else
        {
            ScoreManager.ChangeScoreOn(-ScoreChanging); //deduct points
            DoWrongFeedBack();
        }
        DialogueManager.instance.OnSelestionComplete();//close panel in the end
    }

    //what are we doing, then player make choise
    public void DoRightFeedBack() 
    {
        am.audioSource.PlayOneShot(am.rightAnswerSound);
    }

    public void DoWrongFeedBack()
    {
        am.audioSource.PlayOneShot(am.wrongAnswerSound);
    }
}
