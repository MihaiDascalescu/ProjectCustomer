using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class spawnCars : MonoBehaviour
{
    public GameObject[] randomObjectSpawn;
    private int objectIndex;
   
    private int waitTime;
    private int carNumber = 1000;
    public int carCount = 0;
    public float timer = 5;
    public float controlTimer;
    [Header("Choose One")]
    public bool rightDirection = false;
    public bool leftDirection = false;
    public bool upDirection = false;
    public bool downDirection = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
        timer-=Time.deltaTime; 
        
            if (timer < 1)
            {
                if (carCount != carNumber)
                {
                    if (rightDirection == true)
                    {

                        Spawn();
                        timer = 5;
                    }
                    if (leftDirection == true)
                    {

                        Spawn2();
                        timer = 5;
                    }
                    if (upDirection == true)
                    {
                        Spawn3();

                        timer = 5;
                    }
                    if (downDirection == true)
                    {
                        Spawn1();

                        timer = 5;
                    }


                }

            }


        

    }
  
    
    private void Spawn()
    {
        
        objectIndex = Random.Range(0, randomObjectSpawn.Length);
        Instantiate(randomObjectSpawn[objectIndex], transform.position, transform.rotation);
        carCount++;
        
    }
    private void Spawn1()
    {

        objectIndex = Random.Range(0, randomObjectSpawn.Length);
        Instantiate(randomObjectSpawn[objectIndex], transform.position,transform.rotation * Quaternion.Euler(0,90,0));
        carCount++;

    }
    private void Spawn2()
    {

        objectIndex = Random.Range(0, randomObjectSpawn.Length);
        Instantiate(randomObjectSpawn[objectIndex], transform.position, transform.rotation * Quaternion.Euler(0,180,0));
        carCount++;

    }
    private void Spawn3()
    {

        objectIndex = Random.Range(0, randomObjectSpawn.Length);
        Instantiate(randomObjectSpawn[objectIndex], transform.position, transform.rotation * Quaternion.Euler(0,270,0));
        carCount++;

    }
}
