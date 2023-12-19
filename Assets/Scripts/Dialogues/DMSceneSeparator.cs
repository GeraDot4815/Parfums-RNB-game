using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DMSceneSeparator : DialogueManager
{
    [SerializeField] protected int GoodEndIndex;
    [SerializeField] protected int BadEndIndex;
    protected override void LoadNextScene()
    {
        if (ScoreManager.NowScore >= ScoreManager.NeedToWin)
        {
            SceneManager.LoadScene(GoodEndIndex);
        }
        else
        {
            SceneManager.LoadScene(BadEndIndex);
        }
    }
}
