using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCarController : MonoBehaviour
{
    [Header("CarStats")]
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;
    private bool isWalking = false;
    private float countTime = 1.05f;

    private void Start()
    {

    }
    private void Update()
    {
        if (isRotatingRight || isRotatingLeft)
        {
            countTime -= Time.deltaTime;

        }

        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (countTime < 0)
        {
            isRotatingLeft = false;
            isRotatingRight = false;
            countTime = 1.05f;
        }



    }
    private IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkTime = Random.Range(1, 5);
        int walkWait = Random.Range(1, 4);

        isWalking = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RotateRight")
        {
            isRotatingRight = true;
            isRotatingLeft = false;

        }
        if (collision.gameObject.tag == "RotateLeft")
        {
            isRotatingLeft = true;
            isRotatingRight = false;
        }
    }
}
