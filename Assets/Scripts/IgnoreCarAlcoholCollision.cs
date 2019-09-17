using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCarAlcoholCollision : MonoBehaviour
{
    public GameObject alcoholPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Car")
        {
            //Physics.IgnoreCollision(alcoholPrefabs.collider);
        }
    }
}
