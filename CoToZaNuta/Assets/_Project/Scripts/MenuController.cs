using System.Threading.Tasks;
using kropeczki.engine;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private ButtonView playButton;
    [SerializeField] private GameObject categoryPanel;

    private void Start()
    {
        InitPlayButton();
    }

    private void InitPlayButton()
    {
        playButton.SetClickAction(MoveToPickingCategory);
    }
    
    private async void MoveToPickingCategory()
    {
        logo.SetActive(false);
        playButton.gameObject.SetActive(false);
        await Task.Delay(40);
        EnableCategoryPanel();
    }

    private void EnableCategoryPanel()
    {
        categoryPanel.SetActive(true);
    }

    private void DisableCategoryPanel()
    {
        categoryPanel.SetActive(false);
    }

    public async void MoveToSplashScreen()
    {
        DisableCategoryPanel();
        await Task.Delay(40);
        logo.SetActive(true);
        playButton.gameObject.SetActive(true);
    }
}
