using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public bool buildingIsHit = false;
    public bool carIsHit = false;
    public bool treeIsHit = false;

    public GameObject BuildingIsHitPenalty;
    public GameObject AccidentWith004Penalty;
    public GameObject ExtremelyDrunkPenalty;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Building")
        {
            buildingIsHit = true;
            BuildingIsHitPenalty.SetActive(true);
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
