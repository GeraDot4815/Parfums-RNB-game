using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ParfumeMakerGame : MonoBehaviour
{
    [SerializeField] List<string> phrase;
    [SerializeField] List<string> ingrPhrases = new List<string> {"Композиции надо придать свежести и сочности. Подай-ка бутылек. Только нос заткни...", 
    "Надо, чтоб духи лучше распространялись... Советую закрыть нос...", 
    "Любишь запах амбра и табака? Думаю, он бы тут помог. Подай-ка ингридиент"};
    [SerializeField] List<string> bottleNames = new List<string> {"Цис-3 Гексенол", "Геосмин", "Амбринол"};
    [SerializeField] List<int> recipe;
    [SerializeField] List<int> unused;
    [SerializeField] TMP_Text spText;
    [SerializeField] TMP_Text phText;
    [SerializeField] GameObject speakCanvas;
    [SerializeField] int curPhrase;
    [SerializeField] string speaker;
    public void onClick() {
        if (curPhrase < phrase.Count-1) {
            speakCanvas.SetActive(false);
            curPhrase++;
            phText.text = phrase[curPhrase];
        }
        else {
            SceneManager.LoadScene("Congratulations!");
        }
    }
    void Awake()
    {
        for (int i = 0; i < unused.Count; i++)
        {
            unused[i] = i;
        }
        for (int i = 0; i < recipe.Count; i++)
        {
            int cur = Random.Range(0, unused.Count);
            recipe[i] = unused[cur];
            unused.RemoveAt(cur);
        }
    }
    public void addIngridient(int ingr) {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
