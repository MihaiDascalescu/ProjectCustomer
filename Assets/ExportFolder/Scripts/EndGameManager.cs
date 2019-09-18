using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerCollisions playerCollisions;
    private AlcoholMeter alcoholMeter;
    private Objectives objectives;

    public GameObject BuildingIsHitPenalty;
    public GameObject AccidentWith004Penalty;
    public GameObject ExtremelyDrunkPenalty;
    //public  GameObject
    void Start()
    {
        playerCollisions = FindObjectOfType<PlayerCollisions>();
        alcoholMeter = FindObjectOfType<AlcoholMeter>();
        objectives = FindObjectOfType<Objectives>();
    }

    // Update is called once per frame
    void Update()
    {
        //For building accident
        if (playerCollisions.buildingIsHit)
        {

        }    
        //For car accident with small alcohol levels
        if (playerCollisions.carIsHit && alcoholMeter.AlcoholLevel > 0 && alcoholMeter.AlcoholLevel < 40) 
        {

        }
        //For car accident with medium alcohol levels
        if (playerCollisions.carIsHit && alcoholMeter.AlcoholLevel > 40 && alcoholMeter.AlcoholLevel < 80)
        {

        }
        //For car accident with high alcohol levels
        if (playerCollisions.carIsHit && alcoholMeter.AlcoholLevel > 80)
        {

        }
        //For when the time is up
        if (playerCollisions.timeIsUp)
        {

        }
        //For when really finish the game
        if (objectives.ThirdObjectiveIsEnabled)
        {

        } 
        //For when you finish the game but with level of alcohol
        if(objectives.ThirdObjectiveIsEnabled && alcoholMeter.AlcoholLevel > 0)
        {

        }
    }
  
}
