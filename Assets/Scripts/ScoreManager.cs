using System.Diagnostics;
using UnityEngine;
public static class ScoreManager 
{
    public static int NowScore {  get; private set; }
    public const int NeedToWin = 100;
    public static void SetZeroScore()
    {
        NowScore = 0;
    }
    public static void ChangeScoreOn(int score)
    {
        NowScore += score;
        UnityEngine.Debug.Log("YourScore "+NowScore.ToString());
    }
}
