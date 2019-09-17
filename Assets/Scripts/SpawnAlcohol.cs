using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlcohol : MonoBehaviour
{
    public GameObject Alcohol;
    public GameObject Planet;
    private int xPos;
    private int zPos;
    private float yPos;
    public int AlcoholCount;
    
    // Start is called before the first frame update
    private void Start()
    {
       
    }
    private void Update()
    {
        StartCoroutine(spawnAlcohol());
        /*while(AlcoholCount < 5)
        {
            Run();
        }*/
       
    }
    private IEnumerator spawnAlcohol()
    {
        while (AlcoholCount < 5)
        {
            Run();
        }
        
        yield return new WaitForSeconds(5);
    }

    // Update is called once per frame
    private void Run()
    {
            Vector3 spawnPosition = Random.onUnitSphere * ((Planet.transform.localScale.x / 2) + Alcohol.transform.localScale.y * 0.5f) + Planet.transform.position;
            Quaternion spawnRotation = Quaternion.identity;//todo;adjustrotationbasedonposition
            GameObject newAlcohol = Instantiate(Alcohol, spawnPosition, spawnRotation) as GameObject;

            newAlcohol.transform.LookAt(Planet.transform);
            newAlcohol.transform.Rotate(-90, 0, 0);
           
            AlcoholCount++;
        
    }
}
