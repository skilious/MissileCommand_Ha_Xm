using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreTrack : MonoBehaviour
{
    public Text ScoreUI;
    public Text Bonus;
    public int score;
    private int bonusPoints;
    private int prevScore;
    public GameObject overlord;
    public bool _roundFinish = false;

    public GameObject gameOver;
    public int _citiesHit = 0;
    // Start is called before the first frame update
    void Start()
    {
        // set score
        score = 0;
        Bonus.enabled = false;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        AlienManager gameCheck = overlord.GetComponent<AlienManager>(); // create new variable to access the script
        if (gameCheck.MissilesOnScreen <= 0 && _roundFinish == true) // when the round ends
        {
            Bonus.enabled = true;
            bonusPoints = ((score - prevScore) / 5) * 2; // 10 bonus points per rocket, 10 is 2/5ths of 25
            Debug.Log(bonusPoints);
            score += bonusPoints;
            Bonus.text = "Bonus points: " + bonusPoints;
            // for some reason the bonus gets added continuously beacuse roundReady is always on despite it saying it isnt
            Debug.Log("Results after: " + bonusPoints);
            prevScore = score; // saves the current rounds score so it is taken off for bonus points calculating next round
            _roundFinish = false;
        }

        if (gameCheck.MissilesOnScreen >= 1)
        {
            _roundFinish = true;
            Bonus.enabled = false;
        }

        if (_citiesHit >= 6)
        {
            gameOver.SetActive(true);
            gameCheck.Timer = 10.0f;
            if(Input.GetMouseButtonDown(0))
            {
                gameOver.SetActive(false);
                _citiesHit = 0;
                gameCheck.FiredMissiles = 0;
                gameCheck.Timer = 0;
                gameCheck.totalMissiles = 0;
                gameCheck.MissilesOnScreen = 0;
                score = 0;
                prevScore = 0;
            }
        }
        // displays score
        ScoreUI.text = "Score: " + score;

    }
}
