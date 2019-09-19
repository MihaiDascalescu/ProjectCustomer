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

    public Text penaltyTimeText;
    public Text penaltyScoreText;

    public GameObject PanelTimeText;
    public GameObject PanelScoreText;
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
        if(objectives.currentState == Objectives.ObjectiveState.EndGame)
        {
            penaltyScoreText.text = "" + score.ToString("f0");
            penaltyTimeText.text = "" + objectives.objectiveTimer.ToString("f0");
            PanelScoreText.SetActive(true);
            PanelTimeText.SetActive(true);
            
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
