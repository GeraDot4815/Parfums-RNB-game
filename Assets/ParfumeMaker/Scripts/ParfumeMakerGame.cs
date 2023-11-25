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
    [SerializeField] int curIngr;
    [SerializeField] string speaker;
    [SerializeField] GameObject bottleHolder;
    [SerializeField] GameObject bottle;
    public void onClick() {
        if (curPhrase < phrase.Count) {
            if (curPhrase > 0)
            {
                speakCanvas.SetActive(false);
            }
            if (curPhrase < phrase.Count-1)
            {
                curPhrase++;
                phText.text = phrase[curPhrase];
            }
        }
    }
    void Awake()
    {
        spText.text = speaker;
        phText.text = phrase[0];
        curPhrase = 0;
        for (int i = 0; i < unused.Count; i++)
        {
            unused[i] = i;
        }
        List <int> recipeCopy = new List<int>(0);
        for (int i = 0; i < recipe.Count; i++)
        {
            int cur = Random.Range(0, unused.Count);
            recipe[i] = unused[cur];
            recipeCopy.Add(unused[cur]);
            phrase.Add(ingrPhrases[unused[cur]]);
            unused.RemoveAt(cur);
        }
        for (int i = 0; i < recipe.Count; i++)
        {
            int cur = Random.Range(0, recipeCopy.Count);
            GameObject curBottle = Instantiate(bottle, bottleHolder.transform);
            curBottle.GetComponent<Bottle>().SetBottle(recipeCopy[cur], bottleNames[recipeCopy[cur]]);
            recipeCopy.RemoveAt(cur);
        }
    }
    public void addIngridient(int ingr) 
    {
        if (recipe[curIngr] == ingr)
        {
            if (curIngr == recipe.Count-1)
            {
                SceneManager.LoadScene("Congratulations");
            }
            else
            {
                speakCanvas.SetActive(true);
                curIngr++;
            }
        }
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
