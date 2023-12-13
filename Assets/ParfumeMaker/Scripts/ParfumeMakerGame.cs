using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ParfumeMakerGame : MonoBehaviour
{
    [SerializeField] List<string> phrase;
    [SerializeField] List<string> ingrPhrases;
    [SerializeField] List<string> bottleNames;
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
                dialManager.AddSentense("Профессор",ingrPhrases[recipe[curIngr]], true);
                dialManager.EnableDialogue();
            }
        }
        else
        {
            dialManager.AddSentense("Профессор", "Попробуйте еще раз.");
            dialManager.AddSentense("Профессор", ingrPhrases[recipe[curIngr]], true);
            dialManager.EnableDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
