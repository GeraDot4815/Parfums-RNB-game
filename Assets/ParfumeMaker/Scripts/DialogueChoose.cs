using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoose : MonoBehaviour
{
    public bool isPlayed {  get; private set; }

    [SerializeField] private List<VariantButton> buttons = new List<VariantButton>();
    public List<DialogueChooseVariant> variants = new List<DialogueChooseVariant>();

    private void Start()
    {
        isPlayed = false;
    }
    public void InitializeVariants()
    {
        isPlayed = true;
        for (int i=0; i<buttons.Count; i+=1) 
        {
            buttons[i].textField.text = variants[i].variantText;
            buttons[i].button.onClick.RemoveAllListeners();
            buttons[i].button.onClick.AddListener(variants[i].ChangeScore);
        }
    }
}
