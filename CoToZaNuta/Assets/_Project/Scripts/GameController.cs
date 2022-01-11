using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [SerializeField] private Backgrounds backgrounds;
    [SerializeField] private Timer timer;
    [SerializeField] private Answers answers;

    public static bool isGameOver;

    private void SetCategoryBackground(int category)
    {
        foreach (var bg in backgrounds.GetBackgrounds())
        {
            bg.SetActive(false);
        }
        
        backgrounds.GetBackgrounds()[category].SetActive(true);
    }
}
