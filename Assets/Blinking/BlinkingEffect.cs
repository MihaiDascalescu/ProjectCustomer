using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    public GameObject TopLid;
    public GameObject BottomLid;
    public GameObject PostProcessingEffect;
    public float timer;
    private float activateTimer = 3;
    public bool isActivated = false;
    

    private Animation anim;
    
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        activateTimer -= Time.deltaTime;
        if(activateTimer < 0)
        {
            if (isActivated)
            {
                Blinking();
            }
        }
            
        
       

    }

    void Blinking()
    {


        timer -= Time.deltaTime;
        activateTimer = 3f;
        isActivated = true;
        if (timer <= 0)
        {
            PostProcessingEffect.SetActive(true);

        }

        if (timer < -2)
        {
            PostProcessingEffect.SetActive(false);
        }




    }
    void PostProcessing()
    {
    }
    
}
