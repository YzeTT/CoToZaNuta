using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = System.Random;

public class AudioPlayer : MonoBehaviour
{
    [Inject] private Categories categories;

    [SerializeField] private GameObject note;

    public AudioSource audioSource;
    
    public static UnityAction setAnswers;

    public static string currentSongName;

    private async void Awake()
    {
        await Task.Delay(1000);
        note.transform.localPosition = new Vector3(-422, 29, 0);
        PlayCategorySongs(MenuController.currentCategory);
    }

    private async void PlayCategorySongs(int category)
    {
        var random = new Random();
        var allAudios = categories.GetCategories()[category].GetAudioClips();

        var randomTenAudios = new List<AudioClip>();

        var i = 0;
        while (i != 9 && randomTenAudios.Count != 10)
        {
            var randomIndex = random.Next(0, allAudios.Count);
            if (randomTenAudios.Contains(allAudios[randomIndex]))
            {
                i++;
            }
            else
            {
                randomTenAudios.Add(allAudios[randomIndex]);
            }
        }

        foreach (var audio in randomTenAudios)
        {
            if (audioSource == null) return;
            audioSource.clip = audio;
            currentSongName = audioSource.clip.name;
            audioSource.Play();
            setAnswers?.Invoke();
            await Task.Delay(18000);
            note.transform.localPosition += new Vector3(96, 0, 0);
        }

        randomTenAudios.Clear();
    }
}