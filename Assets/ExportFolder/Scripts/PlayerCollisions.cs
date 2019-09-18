using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public bool buildingIsHit = false;
    public bool carIsHit = false;
    public bool treeIsHit = false;
    public bool timeIsUp = false;

    

    private Objectives objectives;
    
    
    void Start()
    {
        objectives = FindObjectOfType<Objectives>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectives.objectiveTimer < 0)
        {
            timeIsUp = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Building")
        {
            buildingIsHit = true;
            
        }
        if(collision.gameObject.tag == "Car")
        {
            carIsHit = true;
            
        }
        if(collision.gameObject.tag == "Tree")
        {
            treeIsHit = true;
        }
    }
}
