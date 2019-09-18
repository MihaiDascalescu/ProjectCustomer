using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkEffect : MonoBehaviour
{
    public ParticleSystem BubbleEffect; //assign prefab in editor or elsewhere
    //in code
    void Bubble()
    {
        //Instantiate our one-off particle system
        ParticleSystem drinkEffect = Instantiate(BubbleEffect) 
            as ParticleSystem;
        drinkEffect.transform.position = transform.position;
        //play it
        drinkEffect.loop = false;
        drinkEffect.Play();
 
        //destroy the particle system when its duration is up, right
        //it would play a second time.
        Destroy(drinkEffect.gameObject, drinkEffect.duration);
        //destroy our game object
        Destroy(gameObject);
     
    }
}
