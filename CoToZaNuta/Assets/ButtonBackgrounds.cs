using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBackgrounds : MonoBehaviour
{
    [SerializeField] private List<Image> backgrounds = new List<Image>();

    private void Start()
    {
        SetButtonBackground();
    }

    private List<Image> GetBackgrounds()
    {
        return backgrounds;
    }
    
    private void SetButtonBackground()
    {
        foreach (var bg in backgrounds)
        {
            bg.gameObject.SetActive(false);
        }
        
        backgrounds[MenuController.currentCategory].gameObject.SetActive(true);
    }
}
