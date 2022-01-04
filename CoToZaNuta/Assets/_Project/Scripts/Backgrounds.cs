using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrounds : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgrounds = new List<GameObject>();
    
    public List<GameObject> GetAnswersButtons()
    {
        return backgrounds;
    }
}
