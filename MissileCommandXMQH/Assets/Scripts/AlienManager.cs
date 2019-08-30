using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] _targets;
    public GameObject _missiles;
    private int FiredMissiles = 0;
    private int totalMissiles = 0;
    public int wave = 5;
    private int randSplit = 0;
    public bool roundReady = false;

    void Start()
    {

    }

    

    void Update()
    {


        if (roundReady == true) // loop to hold off each full wave
        {
            while (FiredMissiles > 0) // loop to count each missile fired
            {
                randSplit = Random.Range(1, 3);

                for (int i = 0; i < randSplit; i++) // loop to fire missiles in volleys based on random number
                {
                    StartCoroutine(waveSender());
                    FiredMissiles--;
                }

                Debug.Log(FiredMissiles);
            }
            if (FiredMissiles <= 0)
            {
                roundReady = false;
            }

        }
        else
        {
            FiredMissiles = totalMissiles = wave * 3 + 10; // waves get harder each round

        }

        new WaitForSeconds(10.0f);
    }


    IEnumerator waveSender()
    {
        yield return new WaitForSecondsRealtime(2.0f); // wait then fire

        int RandSpawn = 0;
        RandSpawn = Random.Range(0, 3);
        Instantiate(_missiles, spawnPoints[RandSpawn].transform.position, Quaternion.identity);
        //Debug.Log(" Random Building: " + RandSpawn);
    }
}
