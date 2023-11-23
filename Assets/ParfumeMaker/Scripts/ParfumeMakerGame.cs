using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParfumeMakerGame : MonoBehaviour
{
    [SerializeField] List<int> curRecipe;
    [SerializeField] List<int> realRecipe;
    public void reset() {
        for (int i = 0; i < curRecipe.Count; i++) {
            curRecipe[i] = 0;
        }
    }
    public void addIngridient(int ingr) {
        curRecipe[ingr]++;
        bool ok = true;
        for (int i = 0; i < curRecipe.Count; i++) {
            if (curRecipe[i] != realRecipe[i]) {
                ok = false;
            }
        }
        if (ok) {
            SceneManager.LoadScene("Congratulations");
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
