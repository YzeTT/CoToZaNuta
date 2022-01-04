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
        Timer.setAnswers += SetButtonText;
    } 

    private void OnDisable()
    {
        Timer.showAnswers -= ShowAnswers;
        Timer.hideAnswers -= HideAnswers;
        Timer.setAnswers -= SetButtonText;
    }

    public List<Answer> GetAnswersButtons()
    {
        return answers;
    }

    public void ShowAnswers()
    {
        foreach (var answer in answers)
        {
            answer.gameObject.SetActive(true);
        }
    }
    
    public void HideAnswers()
    {
        foreach (var answer in answers)
        {
            answer.gameObject.SetActive(false);
        }
    }

    private void SetButtonText()
    {
        Random random = new Random();
        answers = answers.OrderBy(a => random.Next()).ToList();
        var songsInRandomOrder = categories.GetCategories()[2].GetAudioClips().OrderBy(a => random.Next()).ToList();
        
        answers[0].SetAnswerText(AudioPlayer.currentSongName);
        
        for (int i = 1; i < answers.Count; i++)
        {
            answers[i].SetAnswerText(songsInRandomOrder[i].name);
        }
        
    }
}
