using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    private AlcoholMeter alcoholMeter;
    private Objectives objectives;
    private SpawnObject spawnAlcohol;
    private ScoreCalculator scoreCalculator;
    private PlayerCollisions playerCollisions;

    public GameObject Bubbles;
    public GameObject Blinking;
    public GameObject PostProcessingForAlcohol;


    private CarSound carSound;
    private BlinkingEffect blink;
    private AudioSource audioSource;
    public AudioClip audioClip;

    public AudioClip drinkingEffect;
    public float moveSpeed = 0.01f;
    private Vector3 moveDirection;
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    public float rotationRate = 90f;

    public float counterLimit = 2f;
    public float counterWine = 1f;
    public float counterMartini = 2f;
    public float counterBlink = 3f;
    public float counterPostProcess = 3f;

    private bool isActivated = false;

   

    private void Start()
    {
        alcoholMeter = FindObjectOfType<AlcoholMeter>();
        spawnAlcohol = FindObjectOfType<SpawnObject>();
        scoreCalculator = FindObjectOfType<ScoreCalculator>();
        playerCollisions = FindObjectOfType<PlayerCollisions>();
        objectives = FindObjectOfType<Objectives>();
        blink = FindObjectOfType<BlinkingEffect>();
        carSound = FindObjectOfType<CarSound>();
        audioSource = FindObjectOfType<AudioSource>();
        
    }
    private void Update()
    {
       
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);
        counterBlink -= Time.deltaTime;
        if(counterBlink < 0)
        {
            if (isActivated)
            {
                Blinking.SetActive(false);
            }
        }
        if (counterPostProcess < 0)
        {
            if (isActivated)
            {
                PostProcessingForAlcohol.SetActive(false);
            }
        }


        if (objectives.currentState == Objectives.ObjectiveState.EndGame || objectives.currentState == Objectives.ObjectiveState.Tutorial || objectives.currentState == Objectives.ObjectiveState.TimesUpEnding)
        {
            
        }
        else
        {
            audioSource.PlayOneShot(audioClip);
            ApplyInput(moveAxis, turnAxis);
            if (alcoholMeter.isWine)
            {
                counterWine -= Time.deltaTime;
            }
            if (alcoholMeter.isWhisky)
            {
                counterLimit -= Time.deltaTime;
            }
            if (alcoholMeter.isMartini)
            {
                counterMartini -= Time.deltaTime;
            }
        }
        
        //Debug.Log(counterLimit);
        //Debug.Log(counterWine);


    }
    private void ApplyInput(float moveInput, float turnInput)
    {
        
        Move(moveInput);
        if (alcoholMeter.isWine)
        {
            Turn(turnInput - 0.75f);
        }
        else
        {
            Turn(turnInput);
        }
        if (counterWine < 0)
        {
            alcoholMeter.isWine = false;
            if (alcoholMeter.isWine == false)
            {
                Turn(turnInput);
            }
            counterWine = 1;
        }





    }
    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed * Time.deltaTime);
        if (alcoholMeter.isWhisky == true)
        {
            transform.Translate(Vector3.forward * input * (moveSpeed * 1.25f) * Time.deltaTime);

        }
        if (counterLimit < 1)
        {
            alcoholMeter.isWhisky = false;
            if (alcoholMeter.isWhisky == false)
            {
                transform.Translate(Vector3.forward * input * moveSpeed * Time.deltaTime);
            }
            counterLimit = 2f;

        }
        if(alcoholMeter.isMartini == true)
        {

            moveSpeed = 1;
        }
        if(counterMartini < 0)
        {
            alcoholMeter.isMartini = false;
            if(alcoholMeter.isMartini == false)
            {
                moveSpeed = 5;
            }
            counterMartini = 1;
        }




    }
    private void Turn(float input)
    {
        /*if (alcoholMeter.isWine == true)
        {
            
        }
        else
        {
            transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
        }
        if(counterWine < 0)
        {
            alcoholMeter.isWine = false;
            if(alcoholMeter.isWine == false)
            {
                transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
            }
            counterWine = 1;
        }*/
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);

    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Whisky")
        {
            audioSource.PlayOneShot(drinkingEffect);
            Instantiate(Bubbles, other.gameObject.transform.position, Quaternion.identity);
            alcoholMeter.GetWhisky();

            Destroy(other.gameObject);
            
           


            spawnAlcohol.AlcoholCount--;
            scoreCalculator.score -= 15;
        }
        if (other.gameObject.tag == "Wine")
        {
            audioSource.PlayOneShot(drinkingEffect);
            alcoholMeter.GetWine();
            Instantiate(Bubbles, other.gameObject.transform.position, Quaternion.identity);

            Destroy(other.gameObject);


            spawnAlcohol.AlcoholCount--;
            scoreCalculator.score -= 10;
        }
        if (other.gameObject.tag == "Beer")
        {
            audioSource.PlayOneShot(drinkingEffect);
            alcoholMeter.GetBeer();
            Instantiate(Bubbles, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

            isActivated = true;
            Blinking.SetActive(true);
            PostProcessingForAlcohol.SetActive(true);
            counterBlink = 3f;

            
           
            spawnAlcohol.AlcoholCount--;
            scoreCalculator.score -= 5;
        }
        if (other.gameObject.tag == "Martini")
        {
            audioSource.PlayOneShot(drinkingEffect);
            alcoholMeter.GetMartini();
            Instantiate(Bubbles, other.gameObject.transform.position, Quaternion.identity);

            Destroy(other.gameObject);


            spawnAlcohol.AlcoholCount--;
            scoreCalculator.score -= 3;
        }
        if(other.gameObject.tag == "Water")
        {
            audioSource.PlayOneShot(drinkingEffect);
            alcoholMeter.GetSober();
            Destroy(other.gameObject);
            Instantiate(Bubbles, other.gameObject.transform.position, Quaternion.identity);
            spawnAlcohol.AlcoholCount--;
            scoreCalculator.score += 5;
        }
    }


}
