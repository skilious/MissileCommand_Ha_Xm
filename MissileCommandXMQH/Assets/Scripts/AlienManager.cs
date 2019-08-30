using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] _targets;
    public GameObject _missiles;
    public int MissilesOnScreen = 0;
    private int FiredMissiles = 0;
    private int totalMissiles = 0;
    protected int wave = 3;
    protected int randSplit = 0;
    public bool roundReady = false;
    public float Timer = 10.0f;
    void Update()
    {
        if(MissilesOnScreen <= 0)
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0)
            {
                roundReady = true;
                Debug.Log("ROUND STARTING!");
                Timer = 10.0f;
            }
        }

        if (roundReady == true) // loop to hold off each full wave
        {
            while (FiredMissiles > 0) // loop to count each missile fired
            {
                randSplit = Random.Range(1, 3);

                for (int i = 0; i < randSplit; i++) // loop to fire missiles in volleys based on random number
                {
                    MissilesOnScreen++;
                    StartCoroutine(waveSender());
                    FiredMissiles--;
                }

                if (FiredMissiles <= 0)
                {
                    roundReady = false;
                }
            }
            //This is where its supposed to be located.
            FiredMissiles += totalMissiles += wave + randSplit; // waves get harder each round
            Debug.Log("Total Missiles: " + totalMissiles);
        }
        //This is bad because it would keep looping non-stop until roundready is true.
        //else
        //{
        //    FiredMissiles += totalMissiles += wave * 3 + 10; // waves get harder each round
        //    Debug.Log("Total Missiles: " + totalMissiles);
        //}
    }


    IEnumerator waveSender()
    {
        float temp;
        temp = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(temp); // wait then fire

        //No longer needed but incase i fuck things up. This is our backup.
        //int RandSpawn = 0;
        //RandSpawn = Random.Range(0, 3);

        float RandomLocator;
        RandomLocator = Random.Range(-5.0f, 5.0f);
        Vector3 RandPos = new Vector3(RandomLocator, 5.5f, 0);
        Instantiate(_missiles, RandPos, Quaternion.identity);
    }
}
