using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/New Categories", fileName = "Categories")]
public class Categories : ScriptableObject
{
    [SerializeField] private List<CategorySongs> categories;
}
