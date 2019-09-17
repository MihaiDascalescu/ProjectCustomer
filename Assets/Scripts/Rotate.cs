using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Transform tr;
    [SerializeField] float speed;
    [SerializeField] float sineSpeed=1;

    [SerializeField] bool sineEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tr.Rotate(0, speed*Time.deltaTime, 0);
        if(sineEnabled)
            tr.transform.position = new Vector3(tr.transform.position.x, tr.transform.position.y+Time.deltaTime*(Mathf.Sin(Time.time)/sineSpeed), tr.transform.position.z);

    }
}
