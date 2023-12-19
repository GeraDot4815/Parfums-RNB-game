public interface IScoreChanger //interface for all cases of mini games
{ 
    int ScoreChanging { get; set; }
    void ChangeScore();
    void DoRightFeedBack();
    void DoWrongFeedBack();
}