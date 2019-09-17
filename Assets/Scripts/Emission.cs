using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission : MonoBehaviour
{
    public Material materialRedLight;
    public Material materialBlueLight;

    private bool redLight;
    private bool blueLight;
    void Start()
    {
        //materialRedLight.EnableKeyword("_EMISSION");
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchingLights();

    }


    private void SwitchingLights()
    {
        if (redLight == true)
        {
            materialRedLight.EnableKeyword("_EMISSION");
            blueLight = false;
        }
        
        if (blueLight == true)
        {
            materialBlueLight.EnableKeyword("_EMISSION");
            redLight = false;
        }

        redLight = true;
    }

}
