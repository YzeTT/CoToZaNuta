using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI gameProgressText;
    [SerializeField] private GameObject logo;

    public float gameTimer;
    public int currentSong;

    public static UnityAction endOfTime;
    public static UnityAction showAnswers;
    public static UnityAction hideAnswers;

    private void Start()
    {
        gameTimer = 15;
        currentSong = 1;
    }

    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }

        if (gameTimer < 7)
        {
            showAnswers?.Invoke();
            logo.SetActive(false);
            timerText.fontSize = 148;
            timerText.gameObject.transform.localPosition = Vector3.zero;
        }

        DisplayTime(gameTimer);
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (gameTimer < 0)
        {
            endOfTime?.Invoke();
            ResetGameTimer();
        }

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0}", seconds);
    }

    private void ResetGameTimer()
    {
        hideAnswers?.Invoke();

        logo.SetActive(true);
        timerText.gameObject.transform.localPosition = new Vector3(0, -585, 0);
        timerText.fontSize = 320;
        gameTimer = 15;
        currentSong += 1;
        gameProgressText.text = string.Format("{0}/10", currentSong);
    }
}