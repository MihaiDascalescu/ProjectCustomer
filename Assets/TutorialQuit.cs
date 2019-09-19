using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuit : MonoBehaviour
{
    public bool tutorialOff = false;
    private bool isTrue = false;
    

    private Objectives objectives;
    public GameObject warningPanel;
    // Start is called before the first frame update
    void Start()
    {
        objectives = FindObjectOfType<Objectives>();
    }

    // Update is called once per frame
    private void Update()
    {


       
       
        if (Input.GetMouseButtonDown(0))
        {
            
            tutorialOff = true;
            gameObject.SetActive(false);
            warningPanel.gameObject.SetActive(true);
            Destroy(warningPanel.gameObject, 2);
           
            
        }
       
           
        
    }
}
