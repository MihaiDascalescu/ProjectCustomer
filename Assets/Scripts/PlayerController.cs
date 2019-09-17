﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AlcoholMeter alcoholMeter;

    private SpawnObject spawnAlcohol;
    private ScoreCalculator scoreCalculator;


    public float moveSpeed = 0.01f;
    private Vector3 moveDirection;
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    public float rotationRate = 90f;

    public float counterLimit = 5f;
    public float counterWine = 1f;




    private void Start()
    {
        alcoholMeter = FindObjectOfType<AlcoholMeter>();
        spawnAlcohol = FindObjectOfType<SpawnObject>();
        scoreCalculator = FindObjectOfType<ScoreCalculator>();
    }
    private void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);
        if (alcoholMeter.isWine)
        {
            counterWine -= Time.deltaTime;
        }
        if (alcoholMeter.isWhisky)
        {
            counterLimit -= Time.deltaTime;
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
            alcoholMeter.GetWhisky();
            Destroy(other.gameObject);


            spawnAlcohol.AlcoholCount--;
            scoreCalculator.score -= 15;
        }
        if (other.gameObject.tag == "Wine")
        {
            alcoholMeter.GetWine();
            Destroy(other.gameObject);


            spawnAlcohol.AlcoholCount--;
            scoreCalculator.score -= 10;
        }
        if (other.gameObject.tag == "Beer")
        {
            alcoholMeter.GetBeer();
            Destroy(other.gameObject);


            spawnAlcohol.AlcoholCount--;
            scoreCalculator.score -= 5;
        }
        if (other.gameObject.tag == "Martini")
        {
            alcoholMeter.GetMartini();
            Destroy(other.gameObject);


            spawnAlcohol.AlcoholCount--;
            scoreCalculator.score -= 3;
        }
    }


}