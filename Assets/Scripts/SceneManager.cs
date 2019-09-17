using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;



public class SceneManager : MonoBehaviour
{
    public GameObject InstructionsImage;
    public GameObject StoryImage;
    public GameObject MainMenu;
    public GameObject MainMenuPlanet;
    
    // Start is called before the first frame update
    public void ShowStory()
    {
        StoryImage.SetActive(true);
        MainMenu.SetActive(false);
       
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("NewPrototypeScene");
    }
    

    public void Instructions()
    {
        StoryImage.SetActive(true);
        MainMenu.SetActive(false);
        MainMenuPlanet.SetActive(false);
    }

    public void GoToTutorial()
    {
        StoryImage.SetActive(false);
        InstructionsImage.SetActive(true);
    }

    public void BackToStory()
    {
        StoryImage.SetActive(true);
        InstructionsImage.SetActive(false);
    }

    public void GoToMain()
    {
        MainMenu.SetActive(true);
        InstructionsImage.SetActive(false);
        MainMenuPlanet.SetActive(true);
    }
}
