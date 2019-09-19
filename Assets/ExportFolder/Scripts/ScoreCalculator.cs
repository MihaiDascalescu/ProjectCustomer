using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public float score = 0;
    public Image AlcoholBar;
    private AlcoholMeter alcoholMeter;
    private Objectives objectives;
    public Text scoreText;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        alcoholMeter = FindObjectOfType<AlcoholMeter>();
        objectives = FindObjectOfType<Objectives>();

    }

    // Update is called once per frame
    void Update()
    {
        if(objectives.currentState == Objectives.ObjectiveState.EndGame || objectives.currentState == Objectives.ObjectiveState.Tutorial)
        {
            scoreText.text = "" + score.ToString("f0");
            timerText.text = "" + objectives.objectiveTimer.ToString("f0");
        }
        else
        {
            score += Time.deltaTime;

            UpdateBar();
            scoreText.text = "" + score.ToString("f0");
            timerText.text = "" + objectives.objectiveTimer.ToString("f0");
        }
        

    }
    private void UpdateBar()
    {
        if (AlcoholBar != null)
        {

            AlcoholBar.fillAmount = (float)alcoholMeter.AlcoholLevel / (float)alcoholMeter.AlcoholMaxLevel;
            
        }
    }
}
