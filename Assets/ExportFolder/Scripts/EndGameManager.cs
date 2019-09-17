using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerCollisions playerCollisions;
    //public  GameObject
    void Start()
    {
        playerCollisions = FindObjectOfType<PlayerCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCollisions.buildingIsHit)
        {

        }
        if (playerCollisions.carIsHit)
        {
            
        }
    }
  
}
