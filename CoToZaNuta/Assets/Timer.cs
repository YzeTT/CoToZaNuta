using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class Timer : MonoBehaviour
{
    [Inject] private Categories categories;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI gameProgressText;
    [SerializeField] private GameObject logo;

    public float gameTimer;
    public int currentSong;

    public static UnityAction setAnswers;
    public static UnityAction showAnswers;
    public static UnityAction hideAnswers;

    private void Start()
    {
        currentSong = 1;
        ResetGameTimer(9);
        setAnswers?.Invoke();

        Debug.Log(currentSong + AudioPlayer.currentSongName);
    }

    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }

        if (gameTimer < 7)
        {
            if (currentSong < 11)
            {
                showAnswers?.Invoke();
            }

            logo.SetActive(false);
            timerText.fontSize = 148;
            timerText.gameObject.transform.localPosition = Vector3.zero;
        }

        if (currentSong < 11)
        {
            DisplayTime(gameTimer);
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (gameTimer < 0)
        {
            ResetGameTimer();
        }

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0}", seconds);
    }

    private void ResetGameTimer(int time)
    {
        gameTimer = time;
    }

    private async void ResetGameTimer()
    {
        gameTimer = 0;
        await Task.Delay(3000);
        hideAnswers?.Invoke();
        logo.SetActive(true);

        timerText.gameObject.transform.localPosition = new Vector3(0, -585, 0);
        timerText.fontSize = 320;
        ResetGameTimer(9);
        setAnswers?.Invoke();
        currentSong += 1;
        Debug.Log(currentSong.ToString() + AudioPlayer.currentSongName);
        gameProgressText.text = string.Format("{0}/10", currentSong);
    }
}