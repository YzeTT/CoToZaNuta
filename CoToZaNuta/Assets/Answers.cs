using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class Answers : MonoBehaviour
{
    [Inject] private Categories categories;
    [SerializeField] private List<Answer> answers = new List<Answer>();

    private void OnEnable()
    {
        Timer.showAnswers += ShowAnswers;
        Timer.hideAnswers += HideAnswers;
        AudioPlayer.setAnswers += SetButtonText;
    }

    private void OnDisable()
    {
        Timer.showAnswers -= ShowAnswers;
        Timer.hideAnswers -= HideAnswers;
        AudioPlayer.setAnswers -= SetButtonText;
    }

    public List<Answer> GetAnswersButtons()
    {
        return answers;
    }


    private void ShowAnswers()
    {
        foreach (var answer in answers)
        {
            answer.gameObject.SetActive(true);
        }
    }

    private void HideAnswers()
    {
        foreach (var answer in answers)
        {
            answer.gameObject.SetActive(false);
        }
    }

    private void SetButtonText()
    {
        var random = new Random();
        answers = answers.OrderBy(a => random.Next()).ToList();
        var songsInRandomOrder = categories.GetCategories()[MenuController.currentCategory].GetAudioClips().OrderBy(a => random.Next()).ToList();

        var titles = new List<string> {AudioPlayer.currentSongName};

        var i = 0;
        while (titles.Count != 4)
        {
            if (titles.Contains(songsInRandomOrder[i].name))
            {
                i++;
            }
            else
            {
                titles.Add(songsInRandomOrder[i].name);
            }
        }

        for (int j = 0; j < titles.Count; j++)
        {
            answers[j].SetAnswerText(titles[j]);
        }

        foreach (var answer in answers)
        {
            answer.SetNeutralAnswer();
        }

        titles.Clear();
    }
}