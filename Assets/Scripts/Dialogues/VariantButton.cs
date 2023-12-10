using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class VariantButton : MonoBehaviour //Button for selection
    //hasn't special voids, only comfortable text field link and on/off voids
{
    public TMP_Text textField;
    public Button button { get; private set; }
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void SetDisable()
    {
        button.interactable = false;
        textField.enabled = false;
    }
    public void SetEnable() 
    {
        button.interactable = true;
        textField.enabled = true;
    }
}
