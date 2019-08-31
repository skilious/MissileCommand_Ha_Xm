using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreTrack : MonoBehaviour
{
    public GameObject ScoreUI;
    public GameObject Bonus;
    public int score;
    private int bonusPoints;
    private int prevScore;
    public GameObject overlord;

    // Start is called before the first frame update
    void Start()
    {
        // set score
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // access the big boy and check the state of the game
        overlord = GameObject.Find("GameManager");
        AlienManager gameCheck = overlord.GetComponent<AlienManager>(); // create new variable to access the script
        
        if (gameCheck == true) // when the round ends
        {
            bonusPoints = ((score - prevScore)/5)*3;

            Bonus.GetComponent<Text>().text = "Bouns points " + bonusPoints; // 10 bonus points per rocket, 10 is 3/5ths of 25
            //score += bonusPoints;

            prevScore = score; // saves the current rounds score so it is taken off for bonus points calculating next round
        }

        // displays score
        ScoreUI.GetComponent<Text>().text = "Score: " + score;

    }
}
