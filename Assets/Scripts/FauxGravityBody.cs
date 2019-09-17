using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    // Start is called before the first frame update
    public FauxGravityAttract attractor;
    private Transform myTransform;
   
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
    }
    void Update()
    {
        attractor.Attract(myTransform);
    }
}
