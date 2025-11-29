using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{

    [SerializeField] private GameObject creditsPanel;
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void CreditsShow()
    {
        creditsPanel.SetActive(true);
    }

    public void CreditsHide()
    {
        creditsPanel.SetActive(false);
    }
    
}
