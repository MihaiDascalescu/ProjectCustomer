using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    public AudioSource carNoise;
    // Start is called before the first frame update
    public void PlayCarNoise()
    {
        //Choose a random number 
        
        carNoise.Play();
    }
}
