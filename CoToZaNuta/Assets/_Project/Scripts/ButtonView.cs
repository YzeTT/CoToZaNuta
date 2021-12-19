using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private Image background = null;
    [SerializeField] private TextMeshProUGUI buttonText = null;
    [SerializeField] private Button button = null;

    public void SetClickAction(UnityAction onClickAction)
    {
        button.onClick.AddListener(onClickAction);
    }
    
}