using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    [SerializeField] private List<GameObject> answersButtons = new List<GameObject>();


    private void OnEnable()
    {
        Timer.showAnswers += ShowAnswers;
        Timer.hideAnswers += HideAnswers;
    }

    private void OnDisable()
    {
        Timer.showAnswers -= ShowAnswers;
        Timer.hideAnswers -= HideAnswers;
    }

    public List<GameObject> GetAnswersButtons()
    {
        return answersButtons;
    }

    public void ShowAnswers()
    {
        foreach (var answer in answersButtons)
        {
            answer.SetActive(true);
        }
    }
    
    public void HideAnswers()
    {
        foreach (var answer in answersButtons)
        {
            answer.SetActive(false);
        }
    }
}
