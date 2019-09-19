using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    public enum ObjectiveState
    {
        FirstObjective,
        SecondObjective,
        ThirdObjective,
        Tutorial,
        TimesUpEnding,
        EndGame
    }
    public GameObject FirstObjective;
    public GameObject SecondObjective;
    public GameObject ThirdObjective;
    private PlayerCollisions playerCollisions;
    private TutorialQuit tutorialQuit;
    // Start is called before the first frame update
    public bool FirstObjectiveIsEnabled = false;
    public bool SecondObjectiveIsEnabled = false; 
    public bool ThirdObjectiveIsEnabled = false;
    
    public float objectiveTimer;
    
    public ObjectiveState currentState = ObjectiveState.Tutorial;
    void Start()
    {
        objectiveTimer = 30f;
        playerCollisions = FindObjectOfType<PlayerCollisions>();
        tutorialQuit = FindObjectOfType<TutorialQuit>();
        currentState = ObjectiveState.Tutorial;
    }
    // Update is called once per frame
    private void Update()
    {
        if(currentState == ObjectiveState.EndGame || currentState == ObjectiveState.Tutorial)
        {

        }
        else 
        {
            objectiveTimer -= Time.deltaTime;
        }
        

        AllStates();
        SwitchStates();
        
        
    }
    
    private void AllStates()
    {
        if (currentState == ObjectiveState.FirstObjective)
        {
            FirstObjective.SetActive(true);
            SecondObjective.SetActive(false);
            ThirdObjective.SetActive(false);
            
            
        }
        if (currentState == ObjectiveState.SecondObjective)
        {
            FirstObjective.SetActive(false);
            SecondObjective.SetActive(true);
            ThirdObjective.SetActive(false);
            
        }
        if (currentState == ObjectiveState.ThirdObjective)
        {
            FirstObjective.SetActive(false);
            SecondObjective.SetActive(false);
            ThirdObjective.SetActive(true);
        }
    }
    private void SwitchStates()
    {
        if (tutorialQuit.tutorialOff)
        {
            currentState = ObjectiveState.FirstObjective;
        }
        if (FirstObjectiveIsEnabled == true)
        {
            currentState = ObjectiveState.SecondObjective;
            
        }
        if (SecondObjectiveIsEnabled == true)
        {
            currentState = ObjectiveState.ThirdObjective;
           
        }
        if (ThirdObjectiveIsEnabled == true)
        {
            currentState = ObjectiveState.EndGame;
            
            ThirdObjective.SetActive(false);
        }
        if( playerCollisions.buildingIsHit == true)
        {
            currentState = ObjectiveState.EndGame;
        }
        if (playerCollisions.carIsHit == true)
        {
            currentState = ObjectiveState.EndGame;
        }
        if(objectiveTimer < 0)
        {
            currentState = ObjectiveState.TimesUpEnding;
        }
        
    }

}

