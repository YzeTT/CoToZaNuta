using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class AudioPlayer : MonoBehaviour
{
    [Inject] private Categories categories;
    
    public AudioSource audioSource;
    
    private void Start()
    {
        PlayCategorySongs(2);
    }

    private async void PlayCategorySongs(int category)
    {
        var audios = categories.GetCategories()[category].GetAudioClips();
        
        foreach (var audio in audios)
        {
            audioSource.clip = audio;
            audioSource.Play();
            await Task.Delay(18000);
        }
        
    }

}
