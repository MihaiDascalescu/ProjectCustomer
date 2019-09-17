using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyer : MonoBehaviour
{
    private spawnCars spawncars;
    
    // Start is called before the first frame update
    void Start()
    {
        spawncars = FindObjectOfType<spawnCars>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Car")
        {
            spawncars.carCount--;
            Destroy(other.gameObject);
        }
    }
}
