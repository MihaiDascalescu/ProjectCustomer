using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    SceneManager sceneManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReplayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("NewPrototypeScene");
    }
    public void GoToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
