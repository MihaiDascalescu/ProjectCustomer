using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    public GameObject TopLid;
    public GameObject BottomLid;
    public GameObject PostProcessingEffect;
    public float timer;

    private Animation anim;
    
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Blinking();

    }

    void Blinking()
    {
        
        
        
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            PostProcessingEffect.SetActive(true);
        }

        if (timer < -2)
        {
            PostProcessingEffect.SetActive(false);
        }
        

    }
    
}
