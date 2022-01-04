using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Random = System.Random;

public class LogoAnimation : MonoBehaviour
{
    [SerializeField] private List<GameObject> notes;

    private void Start()
    {
        AnimateNotesOnLogo();
    }

    private async void AnimateNotesOnLogo()
    {
        Random random = new Random();
        var notesInRandomOrder = notes.OrderBy(a => random.Next()).ToList();

        for (int i = 0; i < notes.Count; i++)
        {
            Sequence notesAnimation = DOTween.Sequence();
            
            notesAnimation.Append(notesInRandomOrder[i].transform.DOScale(1.5f, 1));
            notesAnimation.Append(notesInRandomOrder[i].transform.DOScale(1, 1));

            notesAnimation.SetLoops(-1);

            await Task.Delay(200);
            notesAnimation.Play();
        }
    }
}