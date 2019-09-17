using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    public Text scoreText;
    private ScoreCalculator scoreCalculator;
    // Start is called before the first frame update
    void Start()
    {
        scoreCalculator = FindObjectOfType<ScoreCalculator>();
    }
    private void OnEnable()
    {
        SetText();
    }
    private void SetText()
    {
        //scoreText.text = " " + scoreCalculator.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
