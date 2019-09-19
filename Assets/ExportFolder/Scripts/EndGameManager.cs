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
    [Header ("Penalties")]
    public GameObject BuildingIsHitPenalty;
    public GameObject AccidentWith004Penalty;
    public GameObject AccidentWithMediumAlcoholLevel;
    public GameObject ExtremelyDrunkPenalty;
    public GameObject TimesUp;
    public GameObject TrueFinish;
    public GameObject DieSober;
    public GameObject FinishWithAlcohol;
    public GameObject SimpleCarAccident;
    [Header("Particles")]
    public GameObject Explosion;
    public AudioClip AudioClip;
    public AudioSource AudioSource;
    
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
        if (playerCollisions.carIsHit)
        {
            SimpleCarAccident.SetActive(true);
            Explode();
        }
        if (playerCollisions.buildingIsHit)
        {
            BuildingIsHitPenalty.SetActive(true);
            Explode();
        }

       
        //For car accident with small alcohol levels
        if (playerCollisions.carIsHit && alcoholMeter.AlcoholLevel > 0 && alcoholMeter.AlcoholLevel < 40) 
        {
            AccidentWith004Penalty.SetActive(true);
            Explode();
        }
        //For car accident with medium alcohol levels
        if (playerCollisions.carIsHit && alcoholMeter.AlcoholLevel > 40 && alcoholMeter.AlcoholLevel < 80)
        {
            AccidentWithMediumAlcoholLevel.SetActive(true);
            Explode();
        }
        //For car accident with high alcohol levels
        if (playerCollisions.carIsHit && alcoholMeter.AlcoholLevel > 80)
        {
            ExtremelyDrunkPenalty.SetActive(true);
            Explode();
        }
        //For when the time is up
        if (playerCollisions.timeIsUp)
        {
            TimesUp.SetActive(true);
           
        }
        //For when really finish the game
        if (objectives.ThirdObjectiveIsEnabled)
        {
            TrueFinish.SetActive(true);
            
        } 
        //For when you finish the game but with level of alcohol
        if(objectives.ThirdObjectiveIsEnabled && alcoholMeter.AlcoholLevel > 0)
        {
            FinishWithAlcohol.SetActive(true);
            
        }
    }
    private void Explode()
    {
        
        Explosion.SetActive(true);
        AudioSource.PlayOneShot(AudioClip);
    }
  
}
