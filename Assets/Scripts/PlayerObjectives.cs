using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectives : MonoBehaviour
{
    // Start is called before the first frame update
    private Objectives objectives;
    void Start()
    {
        objectives = FindObjectOfType<Objectives>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FirstObjective")
        {
            objectives.objectiveTimer = 30;
            objectives.FirstObjectiveIsEnabled = true;

        }
        if (collision.gameObject.tag == "SecondObjective")
        {
            objectives.objectiveTimer = 30;
            objectives.SecondObjectiveIsEnabled = true;

        }
        if (collision.gameObject.tag == "ThirdObjective")
        {
            objectives.ThirdObjectiveIsEnabled = true;

        }
    }
}

