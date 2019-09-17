using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    public string topLidAnimation;
    public string bottomLidAnimation;
    public GameObject PostProcessingEffect;

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
        PostProcessingEffect.SetActive(true);
    }

    void Blinking()
    {
        anim.Play(topLidAnimation);
        anim.Play(bottomLidAnimation);
        
        
    }
    
}
