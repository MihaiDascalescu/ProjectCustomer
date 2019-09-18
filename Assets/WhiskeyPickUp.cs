using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiskeyPickUp : MonoBehaviour
{
    public GameObject Blinking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        Blinking.SetActive(true);
    }
}
