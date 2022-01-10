using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPanel : MonoBehaviour
{
    [SerializeField] private List<ButtonView> categoryButtons = new List<ButtonView>();

    public List<ButtonView> GetCategoryButtons()
    {
        return categoryButtons;
    }
}
