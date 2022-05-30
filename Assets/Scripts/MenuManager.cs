using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPage;
    [SerializeField] private GameObject creditsPage;
    [SerializeField] private GameObject pageOne;
    [SerializeField] private Button buttonOne;

    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start() 
    {
        creditsPage.SetActive(true);
        mainMenuPage.SetActive(false);
        if(pageOne.activeSelf && creditsPage.activeSelf)
        {
            buttonOne.Select();
        }
        mainMenuPage.SetActive(true);
        creditsPage.SetActive(false);
    }
}
