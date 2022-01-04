using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class AudioPlayer : MonoBehaviour
{
    [Inject] private Categories categories;
    
    public AudioSource audioSource;
    
    public static string currentSongName;
    
    private void Awake()
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
            currentSongName = audioSource.clip.name;
            await Task.Delay(18000);
        }
        
    }
}
