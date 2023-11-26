using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreChanger
{ 
    int RightScore { get; set; }
    int WrongScore { get; set; }

    void ChangeScore();
    void DoRightFeedBack();
    void DoWrongFeedBack();
}
