using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBackgrounds : MonoBehaviour
{
    [SerializeField] private List<Image> backgrounds = new List<Image>();

    private List<Image> GetBackgrounds()
    {
        return backgrounds;
    }
}
