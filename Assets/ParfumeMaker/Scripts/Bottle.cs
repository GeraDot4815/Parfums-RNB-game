using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class Bottle : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ParfumeMakerGame game;
    [SerializeField] TMP_Text bottleName;
    [SerializeField] int number;
    // Start is called before the first frame update
    void Awake()
    {
        game = GameObject.FindWithTag("MainCamera").GetComponent<ParfumeMakerGame>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        game.addIngridient(number);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBottle(int n, string text)
    {
        bottleName.text = text;
        number = n;
    }
}
