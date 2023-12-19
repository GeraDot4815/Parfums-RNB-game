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
    [SerializeField] int curIngr;
    [SerializeField] string speaker;
    [SerializeField] GameObject bottleHolder;
    [SerializeField] GameObject bottle;
    [SerializeField] DialogueManager dialManager;
    void Awake()
    {
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
    public void Start()
    {
        dialManager.AddSentense("Профессор",ingrPhrases[recipe[0]], true);
    }
    public void addIngridient(int ingr) 
    {
        if (recipe[curIngr] == ingr)
        {
            if (curIngr == recipe.Count-1)
            {
                dialManager.AddSentense("Профессор","У вас получилось! Спасибо вам!");
                dialManager.EnableDialogue();
            }
            else
            {
                curIngr++;
                dialManager.AddSentense("Профессор",ingrPhrases[curIngr], true);
                dialManager.EnableDialogue();
            }
        }
        else
        {
            dialManager.AddSentense("Профессор", "Попробуйте еще раз.");
            dialManager.AddSentense("Профессор", ingrPhrases[curIngr], true);
            dialManager.EnableDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
