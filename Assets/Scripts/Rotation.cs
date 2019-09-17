using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] GameObject RotatingPlanet;
    [SerializeField] private float rotation;
    [SerializeField] private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeanTween.rotateY(RotatingPlanet, rotation, time);
    }
}
