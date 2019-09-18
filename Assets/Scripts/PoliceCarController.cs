using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceCarController : MonoBehaviour
{
    public enum PoliceState
    {
        Wait,
        Track,
        Follow
    }
    // Start is called before the first frame update
    public float lookRadius = 10;
    Transform _player;
    private AlcoholMeter alcoholMeter;
    private float _rotSpeed = 3f;
    public float moveSpeed = 1f;
    private int alcoholAdmited = 50;
    public int state = 0;
    public PoliceState currentState = PoliceState.Wait;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        alcoholMeter = FindObjectOfType<AlcoholMeter>();
    }
    private void Update()
    {
        alcoholAdmited = alcoholMeter.AlcoholLevel;
        float distance = Vector3.Distance(_player.position, transform.position);
        if (distance <= lookRadius)
        {
            currentState = PoliceState.Track;

        }
        if(distance <= lookRadius  && alcoholMeter.AlcoholLevel > 90)
        {
            currentState = PoliceState.Follow;
        }
        else
        {
            currentState = PoliceState.Wait;
        }
        //if(distance <= lookRadius)
        if (currentState == PoliceState.Follow)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            lookAt();
        }
        if (currentState == PoliceState.Track)
        {
            lookAt();
        }
        if (currentState == PoliceState.Wait)
        {

        }

        
    }
    private void lookAt()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_player.position - transform.position), _rotSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Building")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
        }
    }



}
   

