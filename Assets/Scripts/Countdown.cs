using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Countdown : MonoBehaviour
{
    public float timeStart = 4;
    

    // Use this for initialization
    void Start()
    {
        
    }
    private void Update()
    {
        //timeStart -= 1;
    }
    // Update is called once per frame
   
    public void StopCountdown()
    {
        timeStart = 4;
    }
       
        
    
}
