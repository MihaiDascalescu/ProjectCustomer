using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public GameObject[] randomObjectSpawn;
   
    public Transform sphere;
    public int AlcoholCount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        while(AlcoholCount < 5)
        {
            Run();
        }
        
    }
    private Vector3 GetRandomAlcoholPosition()
    {
        Mesh planeMesh = gameObject.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;

        float minX = gameObject.transform.position.x - gameObject.transform.localScale.x * bounds.size.x * 0.5f;
        float minZ = gameObject.transform.position.z - gameObject.transform.localScale.z * bounds.size.z * 0.5f;

        Vector3 newVec = new Vector3(Random.Range(minX, minX+4), gameObject.transform.position.y, Random.Range(minZ, minZ+4));

        return newVec;
    }
    private void Run()
    {
        // todo: randomize on quad. Take scale into accound
        Vector3 sphereCenter = sphere.position;
        Vector3 direction = sphereCenter - GetRandomAlcoholPosition();
        Quaternion orientation = Quaternion.LookRotation(-direction);

        int objectIndex = Random.Range(0, randomObjectSpawn.Length);
        Instantiate(randomObjectSpawn[objectIndex], GetRandomAlcoholPosition(), orientation); // todo: make it child of a "pickups" gameobject 

        AlcoholCount++;
    }
}
