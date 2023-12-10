using System.Collections.Generic;

[System.Serializable]
public class DialogueChoose //What answers we can give 
{
    public bool needToPlay = false; //If you don't want to add a choice in this dialog, leave FALSE

    public List<DialogueChooseVariant> variants = new List<DialogueChooseVariant>();

    public void InitializeVariants()
    {
        needToPlay = false; //We don't need to play this choise anymore
        List<VariantButton> buttons = DialogueManager.instance.selectionButtons;
        for (int i=0; i<variants.Count; i+=1) 
        {
            //we don't change buttons objects, so we can clean last choises cash
            buttons[i].SetEnable();
            buttons[i].button.onClick.RemoveAllListeners();
            buttons[i].textField.text = variants[i].variantText;
            buttons[i].button.onClick.AddListener(variants[i].ChangeScore);
        }
    }
}
