using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholMeter : MonoBehaviour
{
    public int AlcoholLevel = 0;
    public int AlcoholMaxLevel = 100;
    public bool isWhisky = false;
    public bool isBeer = false;
    public bool isWine = false;
    public bool isMartini = false;
    public float alcoholCounter = 3;
    void Start()
    {

    }

    // Update is called once per frame
    public void GetWhisky()
    {
        AlcoholLevel += 25;
        isWhisky = true;
    }
    public void GetBeer()
    {
        AlcoholLevel += 15;
        isBeer = true;
    }
    public void GetWine()
    {
        AlcoholLevel += 20;
        isWine = true;
    }
    public void GetMartini()
    {
        AlcoholLevel += 10;
        isMartini = true;
    }
    public void GetSober()
    {
        AlcoholLevel -= 10;
    }
    private void Update()
    {
        //Debug.Log(AlcoholLevel);
        /*if(AlcoholLevel > AlcoholMaxLevel - 2)
        {
            alcoholCounter = 3;
        }
        alcoholCounter -= Time.deltaTime;
        if(alcoholCounter > 0)
        {
            AlcoholLevel -= 5;
        }*/
    }
}


