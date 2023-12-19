public static class ScoreManager //it will be updated
{
    public static int NowScore {  get; private set; }
    public const int NeedToWin = 100;
    public static void SetZeroScore() //we need to run it on START (in some "Game manager" script)
    {
        NowScore = 0;
    }
    public static void ChangeScoreOn(int score)
    {
        NowScore += score;
        UnityEngine.Debug.Log("Score changed on " + score.ToString());
        UnityEngine.Debug.Log("YourScore "+NowScore.ToString());
    }
}