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
        float distance = Vector3.Distance(_player.position, transform.position);
        if (distance <= lookRadius)
        {
            currentState = PoliceState.Track;

        }
        else
        {
            currentState = PoliceState.Wait;
        }
        if(distance <= lookRadius && alcoholMeter.AlcoholLevel > alcoholAdmited)
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


    /*Transform target;
    NavMeshAgent agent;
    void Start()
    {
        target = PlayerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }*/
}
   

