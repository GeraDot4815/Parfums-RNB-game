using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Dialogue : MonoBehaviour
{
    [SerializeField] List<string> speaker;
    [SerializeField] List<string> phrase;
    [SerializeField] TMP_Text spText;
    [SerializeField] TMP_Text phText;
    [SerializeField] GameObject speakCanvas;
    [SerializeField] int curPhrase;
    public void onClick() {
        if (!speakCanvas.activeSelf && speaker.Count > 0) {
            curPhrase++;
            spText.text = speaker[curPhrase];
            phText.text = phrase[curPhrase];
            speakCanvas.SetActive(true);
        }
        else if (curPhrase < speaker.Count-1) {
            curPhrase++;
            spText.text = speaker[curPhrase];
            phText.text = phrase[curPhrase];
        }
        else {
            SceneManager.LoadScene("ParfumeMaker");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        curPhrase = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}