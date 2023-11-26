using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class VariantButton : MonoBehaviour
{
    public TMP_Text textField;
    public Button button { get; private set; }
    private void Awake()
    {
        button = GetComponent<Button>();
    }
}
