using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bottle : MonoBehaviour
{
    [SerializeField] ParfumeMakerGame game;
    [SerializeField] TMP_Text bottleName;
    // Start is called before the first frame update
    void Awake()
    {
        game = GameObject.FindWithTag("Camera").GetComponent<ParfumeMakerGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetText(string text)
    {
        bottleName.text = text;
    }
}
