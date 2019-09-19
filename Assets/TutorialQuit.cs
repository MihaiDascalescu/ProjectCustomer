using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuit : MonoBehaviour
{
    public bool tutorialOff = false;
    private float timer = 2;
    public GameObject warningPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tutorialOff = true;
            gameObject.SetActive(false);
            warningPanel.gameObject.SetActive(true);
            timer -= Time.deltaTime;
            Debug.Log(warningPanel);
        }
        if(timer < 0)
        {
            warningPanel.gameObject.SetActive(false);
        }
    }
}
