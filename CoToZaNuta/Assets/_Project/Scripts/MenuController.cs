using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private ButtonView playButton;
    [SerializeField] private CategoryPanel categoryPanel;

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
    
    private async void EnableCategoryPanel()
    {
        categoryPanel.gameObject.SetActive(true);

        for (int i = 0; i < categoryPanel.GetCategoryButtons().Count; i++)
        {
            categoryPanel.GetCategoryButtons()[i].GetBackground().color = new Color(255,255,255,0);
        }
        
        for (int i = 0; i < categoryPanel.GetCategoryButtons().Count; i++)
        {
            Sequence categoryPanelAnimation = DOTween.Sequence();
            
            categoryPanelAnimation.Append(categoryPanel.GetCategoryButtons()[i].GetBackground().DOFade(255, 800));

            await Task.Delay(200);
            categoryPanelAnimation.Play();
        }
    }

    private void DisableCategoryPanel()
    {
        for (int i = 0; i < categoryPanel.GetCategoryButtons().Count; i++)
        {
            categoryPanel.GetCategoryButtons()[i].GetBackground().color = new Color(255,255,255,0);
        }
        
        categoryPanel.gameObject.SetActive(false);
    }

    public async void MoveToSplashScreen()
    {
        DisableCategoryPanel();
        await Task.Delay(40);
        logo.SetActive(true);
        playButton.gameObject.SetActive(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}


