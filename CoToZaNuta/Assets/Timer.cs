using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Timer : MonoBehaviour
{
    [Inject] private Categories categories;

    [SerializeField] private TextMeshProUGUI timerTextTop;
    [SerializeField] private TextMeshProUGUI timerTextCenter;
    [SerializeField] private TextMeshProUGUI gameProgressText;
    [SerializeField] private GameObject logo;

    public int gameTimer;
    public int currentSong;
    public bool startGame;
    
    public static UnityAction showAnswers;
    public static UnityAction hideAnswers;

    private async void Awake()
    {
        Gameplay();
        // timerTextCenter.gameObject.SetActive(true);
        // timerTextTop.gameObject.SetActive(false);
        //
        // currentSong = 1;
        // SetTimer(16);
        // await Task.Delay(1000);
        // startGame = true;
        // setAnswers?.Invoke();
        //
        // Debug.Log(currentSong + AudioPlayer.currentSongName);
    }

    void Update()
    {
        // if (startGame)
        // {
        //     if (gameTimer > 0)
        //     {
        //         gameTimer -= Time.deltaTime;
        //     }
        //
        //     if (gameTimer < 0)
        //     {
        //         ResetGameTimer();
        //     }
        //
        //     if (gameTimer < 7)
        //     {
        //         if (currentSong < 11)
        //         {
        //             showAnswers?.Invoke();
        //         }
        //
        //         logo.SetActive(false);
        //         timerTextCenter.gameObject.SetActive(false);
        //         timerTextTop.gameObject.SetActive(true);
        //     }
        //
        //     DisplayTime(gameTimer);
        // }
    }

    private async void TimeCountDown()
    {
        SetTimer(15);

        while (gameTimer != 0)
        {
            await Task.Delay(1000);
            gameTimer -= 1;
            DisplayTime();

            if (gameTimer == 6)
            {
                if (currentSong < 11)
                {
                    showAnswers?.Invoke();
                }

                logo.SetActive(false);
                timerTextCenter.gameObject.SetActive(false);
                timerTextTop.gameObject.SetActive(true);
            }
        }
    }

    private async void Gameplay()
    {
        timerTextCenter.gameObject.SetActive(true);
        timerTextTop.gameObject.SetActive(false);
        await Task.Delay(1000);
        currentSong = 1;
        
        while (currentSong != 11)
        {
            gameProgressText.text = string.Format("{0}/10", currentSong);
            logo.SetActive(true);
            timerTextCenter.gameObject.SetActive(true);
            SetTimer(15);
            DisplayTime();
            
            while (gameTimer != 0)
            {
                await Task.Delay(1000);
                gameTimer -= 1;
                DisplayTime();

                if (gameTimer == 6)
                {
                    if (currentSong < 11)
                    {
                        showAnswers?.Invoke();
                    }

                    logo.SetActive(false);
                    timerTextCenter.gameObject.SetActive(false);
                    timerTextTop.gameObject.SetActive(true);
                }
            }
            
            Debug.Log(currentSong + AudioPlayer.currentSongName);
            await Task.Delay(2800);
            timerTextTop.gameObject.SetActive(false);
            hideAnswers?.Invoke();
            await Task.Delay(200);
            currentSong += 1;
        }
        
        SceneManager.LoadScene(0);
        timerTextTop.gameObject.SetActive(false);
        timerTextCenter.gameObject.SetActive(false);
    }

    private void DisplayTime()
    {
        timerTextCenter.text = gameTimer.ToString();
        timerTextTop.text = gameTimer.ToString();
        
        // float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // timerTextTop.text = string.Format("{0}", seconds);
        // timerTextCenter.text = string.Format("{0}", seconds);
    }

    private void SetTimer(int time)
    {
        gameTimer = time;
    }

    private async void ResetGameTimer()
    {
        SetTimer(15);
        await Task.Delay(3000);
        hideAnswers?.Invoke();

        if (currentSong <= 10)
        {
            logo.SetActive(true);
            timerTextCenter.gameObject.SetActive(true);
            timerTextTop.gameObject.SetActive(false);
            currentSong += 1;
            SetTimer(15);
            Debug.Log(currentSong + AudioPlayer.currentSongName);
        }

        if (currentSong == 11)
        {
            SceneManager.LoadScene(0);
            timerTextTop.gameObject.SetActive(false);
            timerTextCenter.gameObject.SetActive(false);
        }

        gameProgressText.text = string.Format("{0}/10", currentSong);
    }
}