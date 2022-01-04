using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private GameObject neutralAnswer;
    [SerializeField] private GameObject goodAnswer;
    [SerializeField] private GameObject badAnswer;
    [SerializeField] private TextMeshProUGUI answerText;

    public void SetAnswerText(string answer)
    {
        answerText.text = answer;
    }

    public void SetCorrectAnswer()
    {
        goodAnswer.gameObject.SetActive(true);
        badAnswer.gameObject.SetActive(false);
        neutralAnswer.gameObject.SetActive(false);
    }

    public void SetWrongAnswer()
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
