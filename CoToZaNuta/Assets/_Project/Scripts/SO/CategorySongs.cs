using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/New Category Songs", fileName = "CategorySongs")]
public class CategorySongs : ScriptableObject
{
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
}
