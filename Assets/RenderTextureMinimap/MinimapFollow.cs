using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public Transform Sphere;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 centerToPlayer = -Sphere.position + Player.position;
        //Vector3 newPosition = Player.position;
        //newPosition.y = transform.position.y;
        transform.position = Player.position + centerToPlayer;

        transform.LookAt(Player.position);
        //transform.rotation = Quaternion.Euler(90f, Player.eulerAngles.y, 0f);
    }
}
