using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    [SerializeField] private GameObject neutralAnswer;
    [SerializeField] private GameObject goodAnswer;
    [SerializeField] private GameObject badAnswer;
    [SerializeField] private TextMeshProUGUI answerText;

    private void Start()
    {
        SetClickAction(CheckIfCorrectAnswer);
    }

    private void SetClickAction(UnityAction action)
    {
        gameObject.GetComponent<Button>().onClick.AddListener(action);
    }
    
    public void SetAnswerText(string answer)
    {
        answerText.text = answer;
    }

    public string GetAnswerText()
    {
        return answerText.text;
    }

    private void CheckIfCorrectAnswer()
    {
        if (answerText.text == AudioPlayer.currentSongName)
        {
            SetCorrectAnswer();
        }
        else
        {
            SetWrongAnswer();
        }
    }
    
    private void SetCorrectAnswer()
    {
        goodAnswer.gameObject.SetActive(true);
        badAnswer.gameObject.SetActive(false);
        neutralAnswer.gameObject.SetActive(false);
    }

    private void SetWrongAnswer()
    {
        badAnswer.gameObject.SetActive(true);
        goodAnswer.gameObject.SetActive(false);
        neutralAnswer.gameObject.SetActive(false);
    }

    public void SetNeutralAnswer()
    {
        badAnswer.gameObject.SetActive(false);
        goodAnswer.gameObject.SetActive(false);
        neutralAnswer.SetActive(true);
    }
    
}
